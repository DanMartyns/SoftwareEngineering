/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import java.io.Serializable;
import java.sql.Timestamp;
import java.util.Date;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotBlank;

/**
 *
 * @author danielmartins
 */
@Entity
@Table(name  = "ECG", schema="ES")
@JsonIgnoreProperties(value = {"createdAt", "updatedAt"}, allowGetters = true)
public class ECG implements Serializable {
   
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private int id;

    @NotBlank
    @Column(name = "sensor")    
    private String sensor;
    
    @NotBlank
    @Column(name = "datatype")    
    private String datatype;
    
    @Column(nullable = false, updatable = false)
    @Temporal(TemporalType.TIMESTAMP)    
    private Date start;
    
    @Column(nullable = false, updatable = false)
    @Temporal(TemporalType.TIMESTAMP)    
    private Date end;
    
    @Column(name = "maxValue")      
    private double maxValue;
    
    public ECG(){}
    
    public ECG (String sensor,String datatype,double maxValue, Timestamp start,Timestamp end) {
        this.sensor = sensor;
        this.datatype = datatype;
        this.maxValue = maxValue;
        this.start = new Date(start.getTime());
        this.end = new Date(end.getTime());
    }

    public int getId() {
        return id;
    }

    public String getSensor() {
        return sensor;
    }

    public String getDatatype() {
        return datatype;
    }

    public Date getStart() {
        return start;
    }

    public Date getEnd() {
        return end;
    }

    public double getMaxValue() {
        return maxValue;
    }
    

    @Override
    public String toString() {
        return "ECG{" + "id=" + id + ", sensor=" + sensor + ", datatype=" + datatype + ", start=" + start + ", end=" + end + '}';
    }
    
}
