/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.es.esproject;

import java.io.Serializable;
import org.json.simple.JSONObject;

/**
 *
 * @author danielmartins
 */
public class Message implements Serializable {
    
    /**
     * ECG type
     */
    private String datatype;
    
    /**
     * id of the Message
     */
    private int id;    
    
    /**
     * Data Stream
     */
    private JSONObject stream;
    
    /**
     * start timestamp
     */
    private String start;
    
    /**
     * Name of the sensor
     */
    private String sensor;
    
    /**
     * end timestamp
     */
    private String end;
    
}
