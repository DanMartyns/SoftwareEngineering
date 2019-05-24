/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AccessData;

import java.text.ParseException;
import org.json.JSONObject;

/**
 *
 * @author danielmartins
 */
public interface ECGService {
    void save(JSONObject obj) throws ParseException;
    
    double mean(JSONObject values);
}
