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
import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.beans.factory.annotation.Autowired;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import org.apache.kafka.clients.consumer.ConsumerRecord;

import org.json.JSONObject;

import Service.ProducerLOG;
import Service.TopicServiceKafkaImpl;
import java.text.ParseException;
import java.util.Set;
import org.springframework.kafka.annotation.EnableKafka;
/**
 *
 * @author danielmartins
 */
@RestController
@EnableKafka
public class DataSensorController {
    
    private static final Logger logger = LoggerFactory.getLogger(DataSensorController.class);
    
    @Autowired
    private ProducerLOG<String,LoggerMessage> producerLOG;
    
    @Autowired
    private TopicServiceKafkaImpl topic;
    
    @Autowired
    ECGServiceImpl ecgService;
        
    @KafkaListener(topics = "bpmi-topic")
    @GetMapping("/")  
    public String read(ConsumerRecord<?, ?> cr) throws Exception {
        return "Welcome to ES Project";
    }
    
    /**
     * Listen for messages on the kafka broker and saves it into the messageRepository.
     * @param cr Consumer record fetched from the message bus
     */
    @KafkaListener(topics = "bpmi-topic")
    @CrossOrigin(origins = "http://172.16.238.40:42002/")
    public JSONObject dataReceiver(ConsumerRecord<?,?> cr) throws ParseException{
        
        String key = "";
        int value = 0;
        Set<String> topicos = topic.getTopics();
        if (!topicos.contains("bpmi-topic")){
            producerLOG.sendMessage(new LoggerMessage("ERROR","Kafka doesn't have the bpmi-topic"));
        }
        
        if (topicos.isEmpty() && topicos.contains("bpmi-topic") ){
            ECG e = ecgService.lastRegistry().get(0);
            key = e.getSensor();
            value = e.getMaxValue();
            producerLOG.sendMessage(new LoggerMessage("INFO","The information comes from the Database"));
        } else {
            key = (String) cr.key();
            value = Integer.parseInt(cr.value().toString().split(":")[1].replace("}", ""));
            producerLOG.sendMessage(new LoggerMessage("INFO","The information comes from the kafka"));
        }
        
        JSONObject json = new JSONObject();
        json.put("sensor_name", key);
        json.put("current_value_bpm", value);
        
        producerLOG.sendMessage(new LoggerMessage("INFO","Send information to DashBoard"));
        
        return json;        
    }   
    
}
