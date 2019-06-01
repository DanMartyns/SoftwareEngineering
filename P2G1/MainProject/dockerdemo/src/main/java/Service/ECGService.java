/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Service;

import Model.ECG;
import java.text.ParseException;
import java.util.List;
import org.json.JSONObject;

/**
 *
 * @author danielmartins
 */
public interface ECGService {
    void save(ECG e) throws ParseException;
    
    double mean(JSONObject values);
    
    List<ECG> lastRegistry();
}
