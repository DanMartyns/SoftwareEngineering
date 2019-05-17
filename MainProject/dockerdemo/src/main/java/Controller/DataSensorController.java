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
import Service.Producer;
import org.springframework.beans.factory.annotation.Autowired;
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
    
    @GetMapping(value = "/read")
    public String read() throws JSONException, Exception {
        //final String path = "src/main/java/Data/ecg_3219.json";
        final String path = "Data/ecg_3219.json";
        
        if (dataSensor.exists(path)) {
            JSONObject jsonObject = (JSONObject) dataSensor.processFile(path);
            ecgService.save(jsonObject);
            producer.sendMessage(jsonObject.get("sensor").toString());
            logger.info("Data sensor was displayed");
            return jsonObject.toString();
        }
            logger.info("File not Found");
            return "File not Found "+dataSensor.contentFolder().toString()+"end content";
       
    }
    
    
}
