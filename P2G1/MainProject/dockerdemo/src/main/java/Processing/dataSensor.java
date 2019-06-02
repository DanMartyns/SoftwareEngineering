/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Processing;


import Model.ECG;
import Model.LoggerMessage;
import Service.ECGServiceImpl;
import Service.ProducerLOG;
import java.sql.Timestamp;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import org.apache.kafka.clients.consumer.ConsumerRecord;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.scheduling.annotation.EnableScheduling;
import org.springframework.stereotype.Component;

/**
 *
 * @author danielmartins
 */
@Component
@EnableScheduling
public class dataSensor {
    
    private static final Logger logger = LoggerFactory.getLogger(dataSensor.class);
    
    @Autowired
    private ProducerLOG<String,LoggerMessage> producerLog;

    @Autowired
    ECGServiceImpl ecgService;
    
    private long last_timestamp = System.currentTimeMillis();
    private String sensor_name;
    

//    @Scheduled(fixedRate = 1000)
//    public void dataTest(){
//        Random r = new Random();
//        int low = -200;
//        int high = 200;
//        int result = r.nextInt(high - low) + low;
//        Stream obj = new Stream(result);
//        producer.sendMessage("1LN1200065", obj);
//    }
    
    
    @KafkaListener(topics = "bpmi-topic")
    public void registerHeartBeat(ConsumerRecord<?,?> cr) throws ParseException {
        long timestamp = System.currentTimeMillis();
        double value = Double.parseDouble(cr.value().toString().split(":")[1].replace("}", ""));
        sensor_name = (String) cr.key();
        logger.info(String.format("Sensor_name : %s",sensor_name));
        logger.info(String.format("Value : %s", value));
        Date d = new Date(timestamp);
        DateFormat df = new SimpleDateFormat("dd:MM:yy:HH:mm:ss");
        if (timestamp-last_timestamp > 10000){
            ecgService.save(new ECG( sensor_name, "heartbeat",value,new Timestamp(last_timestamp),new Timestamp(timestamp)));
            last_timestamp = timestamp;
            producerLog.sendMessage(new LoggerMessage("INFO",String.format("Updating the Database with value: %s",value)));
            logger.info(String.format("Updating the Database with value: %s",value));
        }
    }
    
    
}