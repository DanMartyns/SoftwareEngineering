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
public class Stream {

    private double value;

    public Stream(){}
    
    public Stream(double value){
        this.value = value;
    }
    
    public double getValue(){
        return value;
    }
    public void setValue(double value){
        this.value = value;
    }
}
