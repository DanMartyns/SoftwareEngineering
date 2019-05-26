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
import org.json.JSONObject;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import AccessData.ECGServiceImpl;
import Model.Stream;
import Service.Producer;
import Service.StreamService;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import org.elasticsearch.client.Client;
import org.elasticsearch.index.mapper.ObjectMapper;
import org.json.JSONArray;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.elasticsearch.core.ElasticsearchTemplate;
import org.springframework.data.elasticsearch.core.query.IndexQuery;
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
    private static final String INDEX_NAME = "data";
    private static final String INDEX_TYPE = "ecg";    
    
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
    
    @Scheduled(fixedRate = 5000)
    public void infoToElasticSearch() throws ParseException, InterruptedException, Exception  {
        JSONObject jsonObject = (JSONObject) dataSensor.processFile(path);
        List<Stream> s = new ArrayList<>();
        JSONArray values = (JSONArray) jsonObject.get("stream");
        for (int i = 0; i < values.length(); i++) {
            JSONObject tmp = (JSONObject) values.get(i);
            //logger.info("1. Values : "+tmp);
            double mean = ecgService.mean(tmp);
            //logger.info("2. Mean : "+mean);
            Date timestamp = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss").parse(tmp.get("timestamp").toString());
            //logger.info("3. Timestamp "+timestamp+" "+timestamp.getClass().getName());
            Stream stream = new Stream(i,mean,timestamp);
            //logger.info(stream.toString());
            s.add(stream);
        }   
        
        try {
            if (!elasticsearchTemplate.indexExists(INDEX_NAME)) {
                elasticsearchTemplate.createIndex(INDEX_NAME);
            }
            ObjectMapper mapper = new ObjectMapper();
            List<IndexQuery> queries = new ArrayList<>();
            s.stream().map((se) -> {
                IndexQuery indexQuery = new IndexQuery();
                indexQuery.setId(se.getId()+"");
                indexQuery.setSource(mapper.writeValueAsString(se));
                return indexQuery;
            }).map((indexQuery) -> {
                indexQuery.setIndexName(INDEX_NAME);
                return indexQuery;
            }).map((indexQuery) -> {
                indexQuery.setType(INDEX_TYPE);
                return indexQuery;
            }).forEach((indexQuery) -> {
                queries.add(indexQuery);
            });
            if (queries.size() > 0) {
                elasticsearchTemplate.bulkIndex(queries);
            }
            elasticsearchTemplate.refresh(INDEX_NAME);
        } catch (Exception e) {
            logger.error("Error bulk index", e);
        }
    }
    
    
    @GetMapping(value = "/read")
    @CrossOrigin(origins = "http://172.16.238.40:3001/")
    //@CrossOrigin(origins = "http://localhost:3001/")
    public String read() throws Exception {
        List<Stream> s = new ArrayList<>();
        JSONObject jsonObject = (JSONObject) dataSensor.processFile(path);
        producer.sendMessage(jsonObject.get("sensor").toString());
        logger.info("Data sensor was displayed");
        logger.info("information to Elastic Search added");
        if (dataSensor.exists(path)) {
            ecgService.save(jsonObject);
            JSONArray values = (JSONArray) jsonObject.get("stream");
            for (int i = 0; i < values.length(); i++) {
                JSONObject tmp = (JSONObject) values.get(i);
                //logger.info("1. Values : "+tmp);
                double mean = ecgService.mean(tmp);
                //logger.info("2. Mean : "+mean);
                Date timestamp = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss").parse(tmp.get("timestamp").toString());
                //logger.info("3. Timestamp "+timestamp+" "+timestamp.getClass().getName());
                Stream stream = new Stream(i,mean,timestamp);
                //logger.info(stream.toString());
                s.add(stream);
            }          
            streamService.saveAll(s);
        }
        else{
            logger.info("File Not Found");
        }   
        return jsonObject.toString();
    }
    
    
}
