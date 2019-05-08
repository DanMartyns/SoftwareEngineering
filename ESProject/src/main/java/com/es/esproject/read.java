package com.es.esproject;


import java.io.FileReader;
import java.util.Iterator;
 
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
/**
 *
 * @author danielmartins
 */
public class read {
    
    static JSONParser parser = new JSONParser();
    
    public static JSONObject readFromFile(String fileName) throws Exception 
    { 
        JSONObject jsonObject = new JSONObject();
        try {
 
            Object obj = parser.parse(new FileReader(fileName)); 
            jsonObject = (JSONObject) obj;
        
        } catch (Exception e) {
            System.err.println("There is a problem reading the file");
            e.printStackTrace();
            System.exit(1);
        }
        return jsonObject;
    }
}
