/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Processing;


import Service.Producer;
import java.util.Random;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
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
    private Producer producer;

    
    @Scheduled(fixedRate = 1000)
    public void dataTest(){
        Random r = new Random();
        int low = 0;
        int high = 200;
        int result = r.nextInt(high-low) + low;
        producer.sendMessage("1LN1200065", result);
    }
    
    
}
