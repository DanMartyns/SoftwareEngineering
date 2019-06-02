/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Model.ECG;
import Model.LoggerMessage;
import Service.ECGServiceImpl;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.beans.factory.annotation.Autowired;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import Service.ProducerLOG;
import Service.TopicServiceKafkaImpl;
import java.io.IOException;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import org.json.JSONObject;
import org.springframework.kafka.annotation.EnableKafka;
/**
 *
 * @author danielmartins
 */
@RestController
@EnableKafka
public class DataSensorController {
    
    private static final Logger logger = LoggerFactory.getLogger(DataSensorController.class);
    
    private static final String TOPIC = "bpmi-topic";
    
    @Autowired
    private ProducerLOG<String,LoggerMessage> producerLOG;
    
    @Autowired
    private TopicServiceKafkaImpl topic;
    
    @Autowired
    ECGServiceImpl ecgService;
        
    @GetMapping("/")  
    public String home() {
        return "Welcome to ES Project";
    }
    
    @GetMapping("/data")
    @CrossOrigin(origins = "http://172.16.238.40:42002/")
    public String dataReceiver() throws ParseException, IOException{
        
        double value = 0;
        List<ECG> e = null;
        Set<String> topicos = topic.getTopics();
        if (!topicos.contains("bpmi-topic")){
            producerLOG.sendMessage(new LoggerMessage("ERROR","Kafka doesn't have the bpmi-topic"));
            logger.info("Kafka doesn't have the bpmi-topic");
        }
        
        if (!topicos.isEmpty() && topicos.contains("bpmi-topic") ){
            e = ecgService.allValues();
            producerLOG.sendMessage(new LoggerMessage("INFO","The information comes from the Database"));
        } else {
            producerLOG.sendMessage(new LoggerMessage("ERROR","Cannot acess to database"));
        }
        
        JSONObject obj = new JSONObject();
        ArrayList array = new ArrayList();
        
        for(ECG ecg : e){
            array.add(ecg.getMaxValue());
        }
        obj.put("sensor_name", e.get(0).getSensor());
        obj.put("values", array);
        obj.put("current_value",array.get(array.size() -1));
        
        producerLOG.sendMessage(new LoggerMessage("INFO","Send information to Dashboard"));
        logger.info("Send information to Dashboard");
        
        return obj.toString();        
    }   
    
}
