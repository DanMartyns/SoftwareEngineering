/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccessData;

import Model.ECG;
import Repository.ECGRepository;
import java.lang.reflect.Array;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import java.util.stream.Collectors;
import org.json.JSONArray;
import org.json.JSONException;
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
    public void save(JSONObject obj) throws ParseException{
        try {
            DateFormat format = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss", Locale.ENGLISH);
            Date start = format.parse(obj.get("start").toString());
            Date end = format.parse(obj.get("end").toString());        
            ECG e = new ECG( (int) obj.get("id"), (String) obj.get("sensor"), (String) obj.get("datatype"), (Date) start, (Date) end);
            ecgRepository.saveAndFlush(e);
        } catch (JSONException | ParseException e) {
            System.out.println("Message : "+e.getMessage());
        }
    }

    @Override    
    public double mean(JSONObject values){
        List<String> list = Arrays.asList(values.getString("values").split(" "));
        return list.stream().mapToDouble(Double::parseDouble).average().getAsDouble();
    }
}
