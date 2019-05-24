/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import Processing.dataSensor;
import org.json.JSONException;
import org.json.JSONObject;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import AccessData.ECGServiceImpl;
import Model.Stream;
import Service.Producer;
import Service.StreamService;
import java.text.SimpleDateFormat;
import java.util.Date;
import org.elasticsearch.client.Client;
import org.json.JSONArray;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.elasticsearch.core.ElasticsearchTemplate;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.ModelAttribute;
/**
 *
 * @author danielmartins
 */
@RestController
@RequestMapping("/data")
public class DataSensorController {
    
    private static final Logger logger = LoggerFactory.getLogger(DataSensorController.class);
    
    @Autowired
    Producer producer;
    
    @Autowired
    ECGServiceImpl ecgService;
    
    @Autowired
    private ElasticsearchTemplate elasticsearchTemplate;

    @Autowired
    private StreamService streamService;

    @Autowired
    private Client client;

    @ModelAttribute
    public void before() {
        elasticsearchTemplate.deleteIndex(Stream.class);
        elasticsearchTemplate.createIndex(Stream.class);
        elasticsearchTemplate.putMapping(Stream.class);
        elasticsearchTemplate.refresh(Stream.class);
    }
    
    
    @GetMapping(value = "/read")
    @CrossOrigin(origins = "http://172.16.238.40:3000/")
    //@CrossOrigin(origins = "http://localhost:3000/")
    public String read() throws JSONException, Exception {
        //final String path = "src/main/java/Data/ecg_3219.json";
        final String path = "Data/ecg_3219.json";
        
        if (dataSensor.exists(path)) {
            JSONObject jsonObject = (JSONObject) dataSensor.processFile(path);
            ecgService.save(jsonObject);
            
            JSONArray values = (JSONArray) jsonObject.get("stream");
            for (int i = 0; i < values.length(); i++) {
                JSONObject tmp = (JSONObject) values.get(i);
                double mean = ecgService.mean(tmp);
                Date timestamp = new SimpleDateFormat("YYYY-MM-dd'T'HH:mm:ss").parse(tmp.get("timestamp").toString());
                //2016-11-09T19:29:44+0000
                streamService.save(new Stream(mean,timestamp));
            }
            
            producer.sendMessage(jsonObject.get("sensor").toString());
            logger.info("Data sensor was displayed");
            return jsonObject.toString();
        }
            logger.info("File not Found");
            return null;
       
    }
    
    
}
