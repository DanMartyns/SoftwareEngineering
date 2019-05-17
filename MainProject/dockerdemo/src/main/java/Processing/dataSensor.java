/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Processing;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import org.json.JSONObject;
import org.springframework.kafka.annotation.KafkaListener;
import org.apache.kafka.clients.consumer.ConsumerRecord;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.kafka.core.KafkaTemplate;
import org.springframework.stereotype.Component;

/**
 *
 * @author danielmartins
 */
@Component
public class dataSensor {
    
    private static final Logger logger = LoggerFactory.getLogger(dataSensor.class);
    
    @Autowired
    private KafkaTemplate<String, String> template;
    
    /**
     * Listen for messages on the kafka broker and saves it into the messageRepository.
     * @param cr Consumer record fetched from the message bus
     */
    @KafkaListener(topics = "sensor_data")    
    public static void dataReceiver(ConsumerRecord<?, ?> cr){
        logger.info("Message received from {}: {} .", cr.key(), cr.value());
    }
    
    
    public static String readFile(String filename) {
        String result = "";
        try {
            BufferedReader br = new BufferedReader(new FileReader(filename));
            StringBuilder sb = new StringBuilder();
            String line = br.readLine();
            while (line != null) {
                sb.append(line);
                line = br.readLine();
            }
            result = sb.toString();
        } catch(Exception e) {}
        return result;
    }

    public static JSONObject processFile(String filename) throws Exception {  
        String jsonData = readFile(filename);
        JSONObject jobj = new JSONObject(jsonData);
        return jobj;
    }
    
    public static boolean exists(String filename) {
        File f = new File(filename);
        if(f.exists() && !f.isDirectory()) { return true; }
        return false;
    }
    
    public static String contentFolder() {
        String content = "";
        File dir = new File(".");
        File[] filesList = dir.listFiles();
        for (File file : filesList) {
            if (file.isFile()) {
                content += file.getName();
            }
        }
        return content;
    }
}
