/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

/**
 *
 * @author danielmartins
 */
public class LoggerMessage {
    
    private String logType;
    private String logMessage;

    public LoggerMessage(){}
    
    public LoggerMessage(String logType, String logMessage) {
        this.logType = logType;
        this.logMessage = logMessage;
    }

    public String getLogType() {
        return logType;
    }

    public String getMessage() {
        return logMessage;
    }

    public void setLogType(String logType) {
        this.logType = logType;
    }

    public void setMessage(String logMessage) {
        this.logMessage = logMessage;
    }
    
  
}
