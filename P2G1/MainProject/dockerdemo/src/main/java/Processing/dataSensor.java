/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Processing;


import Model.ECG;
import Model.LoggerMessage;
import Model.Stream;
import Service.ECGServiceImpl;
import Service.ProducerBPMI;
import Service.ProducerLOG;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.sql.Timestamp;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.List;
import java.util.concurrent.TimeUnit;
import org.apache.kafka.clients.consumer.ConsumerRecord;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;

/**
 *
 * @author danielmartins
 */
@Component
public class dataSensor {
    
    private static final Logger logger = LoggerFactory.getLogger(dataSensor.class);   
    
    @Autowired
    private ProducerBPMI<String,Stream> producer;
    
    @Autowired
    private ProducerLOG<String,LoggerMessage> producerLog;

    @Autowired
    ECGServiceImpl ecgService;
    
    private long last_timestamp = System.currentTimeMillis();
    private String sensor_name;
    
    private List<Double> heartbeats = new ArrayList<>();
    
//    @Scheduled(fixedRate = 1000)
//    public void dataTest(){
//        Random r = new Random();
//        int low = -200;
//        int high = 200;
//        int result = r.nextInt(high - low) + low;
//        Stream obj = new Stream(result);
//        producer.sendMessage("1LN1200065", obj);
//    }
    
    @Scheduled(fixedDelay = 1000, initialDelay = 1000)
    public void dataTestFile() throws InterruptedException{
        try (FileReader reader = new FileReader("Data/ecg.txt");
             BufferedReader br = new BufferedReader(reader)) {
            while(true){
                String line;
                while ((line = br.readLine()) != null) {
                    logger.info("line :"+line);
                    String[] array = line.split(" ");
                    for(int i= 0; i < array.length; i++){
                        Stream obj = new Stream(Double.parseDouble(array[i]));
                        producer.sendMessage("1LN1200065", obj);
                        TimeUnit.SECONDS.sleep(1);
                        producerLog.sendMessage(new LoggerMessage("INFO","Data Sending..."));
                    }
                }
                if ((line = br.readLine()) == null){
                    RandomAccessFile raf = new RandomAccessFile("ecg.txt", "r");
                    raf.seek(0);
                }
               producerLog.sendMessage(new LoggerMessage("INFO","Data Sending..."));
               logger.info("Data Sending...");
            }
        } catch (IOException e) {
            producerLog.sendMessage(new LoggerMessage("ERROR",String.format("IOException: %s%n", e)));
            logger.error(String.format("IOException: %s%n", e));
        }        
    }
    
    
    @KafkaListener(topics = "bpmi-topic")
    public void registerHeartBeat(ConsumerRecord<?,?> cr) throws ParseException {
        double value = Double.parseDouble(cr.value().toString().split(":")[1].replace("}", ""));
        heartbeats.add(value);
        sensor_name = (String) cr.key();
    }
    
    @Scheduled(fixedRate = 2000)  
    public void DBsave() throws ParseException  {
        long timestamp = System.currentTimeMillis();
        
        Date d = new Date(timestamp);
        DateFormat df = new SimpleDateFormat("dd:MM:yy:HH:mm:ss");

        if (!heartbeats.isEmpty()){
            double maxValue = Collections.max(heartbeats);
            logger.info("Max Value ",maxValue);
            ecgService.save(new ECG( sensor_name, "heartbeat",maxValue,new Timestamp(last_timestamp),new Timestamp(timestamp)));
            last_timestamp = timestamp;
            heartbeats.clear();
            producerLog.sendMessage(new LoggerMessage("INFO",String.format("Updating the Database with value: %s",maxValue)));
            logger.info(String.format("Updating the Database with value: %s",maxValue));
        }        
    }
    
    
}