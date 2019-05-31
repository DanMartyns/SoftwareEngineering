/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import java.util.Date;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.DateFormat;
import org.springframework.data.elasticsearch.annotations.Document;
import org.springframework.data.elasticsearch.annotations.Field;
import org.springframework.data.elasticsearch.annotations.FieldType;
/**
 *
 * @author danielmartins
 */
@Document(indexName = "data", type = "ecg")
public class Stream {
 
    @Id
    private int id;
    
    @Field(type = FieldType.Double, store = true)
    private Double value;

    @Field(
        type = FieldType.Date, 
        store = true, 
        format = DateFormat.custom, pattern = "dd:MM:yy:HH:mm:ss"
    )
    private Date timestamp;


    public Stream() {
    }

    public Stream(int id, Double value, Date timestamp) {
        this.id = id;
        this.value = value;
        this.timestamp = timestamp;
    }

    public long getId() {
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
