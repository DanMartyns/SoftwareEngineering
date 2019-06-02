/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Service;

import Model.ECG;
import Repository.ECGRepository;
import java.text.ParseException;
import java.util.Arrays;
import java.util.List;
import org.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Configurable;
import org.springframework.stereotype.Service;


/**
 *
 * @author danielmartins
 */
@Service
@Configurable
public class ECGServiceImpl implements ECGService{
    
    @Autowired
    ECGRepository ecgRepository;
    
    @Override
    public void save(ECG e) throws ParseException{
        try {
            ecgRepository.saveAndFlush(e);
        } catch (Exception ex) {
            System.out.println("Message : "+ex.getMessage());
        }
    }

    @Override    
    public double mean(JSONObject values){
        List<String> list = Arrays.asList(values.getString("values").split(" "));
        return list.stream().mapToDouble(Double::parseDouble).average().getAsDouble();
    }
    
    @Override
    public List<ECG> lastRegistry(){
        return ecgRepository.lastValue();
    }
    
    @Override
    public List<ECG> allValues(){
        return ecgRepository.allValues();
    }
}
