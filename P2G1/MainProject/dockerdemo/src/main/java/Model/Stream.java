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

    private int value;

    public Stream(){}
    
    public Stream(int value){
        this.value = value;
    }
    
    public int getValue(){
        return value;
    }
    public void setValue(int value){
        this.value = value;
    }
}
