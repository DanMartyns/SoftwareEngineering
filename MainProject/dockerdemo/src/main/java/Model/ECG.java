/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import java.io.Serializable;
import java.util.Date;
import javax.persistence.Column;
import javax.persistence.Entity;
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
    @Column(name="id")
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
    
    public ECG(){}
    
    public ECG (int id,String sensor,String datatype,Date start,Date end) {
        this.id = id;
        this.sensor = sensor;
        this.datatype = datatype;
        this.start = start;
        this.end = end;
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

    @Override
    public String toString() {
        return "ECG{" + "id=" + id + ", sensor=" + sensor + ", datatype=" + datatype + ", start=" + start + ", end=" + end + '}';
    }
    
}
