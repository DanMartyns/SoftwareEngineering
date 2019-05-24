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
import java.security.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.concurrent.TimeUnit;
import java.util.stream.Collectors;
import org.elasticsearch.client.Client;
import org.json.JSONArray;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.elasticsearch.core.ElasticsearchTemplate;
import org.springframework.scheduling.annotation.Scheduled;
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
    
    //final String path = "src/main/java/Data/ecg_3219.json";
    final String path = "Data/ecg_3219.json";
    
    private JSONObject jsonObject;
    
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
    public void before() throws JSONException, Exception {
        elasticsearchTemplate.deleteIndex(Stream.class);
        elasticsearchTemplate.createIndex(Stream.class);
        elasticsearchTemplate.putMapping(Stream.class);
        elasticsearchTemplate.refresh(Stream.class);
        
        if (dataSensor.exists(path)) {
            jsonObject = (JSONObject) dataSensor.processFile(path);
            ecgService.save(jsonObject);
        }
        else{
            logger.info("File Not Found");
        }
        infoToElasticSearch();    
        
    }
    
    @Scheduled(fixedRate = 433000)
    public void infoToElasticSearch() throws ParseException  {
        logger.info("information to Elastic Search added");
        List<Double> metrics = new ArrayList<>();
        try{
            JSONArray values = (JSONArray) jsonObject.get("stream");
            for (int i = 0; i < values.length(); i++) {
                JSONObject tmp = (JSONObject) values.get(i);
                double mean = ecgService.mean(tmp);
                Date timestamp = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss").parse(tmp.get("timestamp").toString());
                streamService.save(new Stream(1,mean,timestamp));
                TimeUnit.SECONDS.sleep(1);
            }       
        } catch (Exception e){
            logger.error("Error :"+e.getMessage());
        }
    }
    
    
    @GetMapping(value = "/read")
    @CrossOrigin(origins = "http://172.16.238.40:3001/")
    //@CrossOrigin(origins = "http://localhost:3001/")
    public String read() {
        producer.sendMessage(jsonObject.get("sensor").toString());
        logger.info("Data sensor was displayed");
        return jsonObject.toString();
    }
    
    
}
