/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import java.util.Date;
import javax.persistence.Id;
import org.springframework.data.elasticsearch.annotations.Document;

/**
 *
 * @author danielmartins
 */
@Document(indexName = "data", type = "ecg")
public class Stream {
 
    @Id
    private String id;
     
    private Double value;
     
    private Date timestamp;

    public Stream() {
    }

    public Stream(Double value, Date timestamp) {
        this.value = value;
        this.timestamp = timestamp;
    }

    public String getId() {
        return id;
    }

    public Double getValue() {
        return value;
    }

    public Date getTimestamp() {
        return timestamp;
    }

    public void setValue(Double value) {
        this.value = value;
    }

    public void setTimestamp(Date timestamp) {
        this.timestamp = timestamp;
    }

    @Override
    public String toString() {
        return "Stream{" + "id=" + id + ", value=" + value + ", timestamp=" + timestamp + '}';
    }
    
    
}
