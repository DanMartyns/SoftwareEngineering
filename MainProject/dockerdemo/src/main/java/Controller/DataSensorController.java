/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.kafka.annotation.KafkaListener;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.beans.factory.annotation.Autowired;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import Service.ECGServiceImpl;
import Service.StreamService;
import org.apache.kafka.clients.consumer.ConsumerRecord;
import org.elasticsearch.client.Client;
import org.json.JSONObject;
import org.springframework.data.elasticsearch.core.ElasticsearchTemplate;

import Model.ECG;
import Model.Stream;
import java.sql.Timestamp;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.List;
import org.springframework.kafka.annotation.EnableKafka;
/**
 *
 * @author danielmartins
 */
@RestController
@EnableKafka
public class DataSensorController {
    
    private static final Logger logger = LoggerFactory.getLogger(DataSensorController.class);

    private static final String INDEX_NAME = "data";
    private static final String INDEX_TYPE = "ecg";
    
    
    private long last_timestamp = System.currentTimeMillis();
    
    private List<Integer> heartbeats = new ArrayList<>();
    
    private int i = 0;
    
    @Autowired
    private ElasticsearchTemplate elasticsearchTemplate;

    @Autowired
    private StreamService streamService;

    @Autowired
    private Client client;
     
    @Autowired
    ECGServiceImpl ecgService;  
    

    @ModelAttribute
    public void before() {
        elasticsearchTemplate.deleteIndex(Stream.class);
        elasticsearchTemplate.createIndex(Stream.class);
        elasticsearchTemplate.putMapping(Stream.class);
        elasticsearchTemplate.refresh(Stream.class);
        
    }
        
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
    public JSONObject dataReceiver(ConsumerRecord<String,Integer> cr) throws ParseException{
        logger.info("Message received from {}: {} .", cr.key(), cr.value());
        long timestamp = System.currentTimeMillis();
        Date d = new Date(timestamp);
        DateFormat df = new SimpleDateFormat("dd:MM:yy:HH:mm:ss");     
        heartbeats.add(cr.value());
        i++;
        if (timestamp - last_timestamp >= 10000 && !heartbeats.isEmpty()){
            int maxValue = Collections.max(heartbeats);
            ecgService.save(new ECG((String) cr.key(), "heartbeat",maxValue,new Timestamp(last_timestamp),new Timestamp(timestamp)));
            last_timestamp = timestamp;
            heartbeats.clear();
        }
        JSONObject json = new JSONObject();
        json.put("sensor_name", cr.key());
        int value = cr.value();
        json.put("current_value_bpm", value);
        return json;        
    }   
    
}
