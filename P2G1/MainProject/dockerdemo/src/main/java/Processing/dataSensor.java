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
import java.sql.Timestamp;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.List;
import java.util.Random;
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
    
    private List<Integer> heartbeats = new ArrayList<>();
    
    @Scheduled(fixedRate = 1000)
    public void dataTest(){
        Random r = new Random();
        int low = -200;
        int high = 200;
        int result = r.nextInt(high - low) + low;
        Stream obj = new Stream(result);
        producer.sendMessage("1LN1200065", obj);
    }
    
    
    @KafkaListener(topics = "bpmi-topic")
    public void registerHeartBeat(ConsumerRecord<?,?> cr) throws ParseException {
        int value = Integer.parseInt(cr.value().toString().split(":")[1].replace("}", ""));
        heartbeats.add(value);
        sensor_name = (String) cr.key();
    }
    
    @Scheduled(fixedRate = 2000)  
    public void DBsave() throws ParseException  {
        long timestamp = System.currentTimeMillis();
        
        Date d = new Date(timestamp);
        DateFormat df = new SimpleDateFormat("dd:MM:yy:HH:mm:ss");

        if (timestamp - last_timestamp >= 10000 && !heartbeats.isEmpty()){
            int maxValue = Collections.max(heartbeats);
            ecgService.save(new ECG( sensor_name, "heartbeat",maxValue,new Timestamp(last_timestamp),new Timestamp(timestamp)));
            last_timestamp = timestamp;
            heartbeats.clear();
            producerLog.sendMessage(new LoggerMessage("INFO",String.format("Updating the Database with value: %s",maxValue)));
        }        
    }
    
    
}
