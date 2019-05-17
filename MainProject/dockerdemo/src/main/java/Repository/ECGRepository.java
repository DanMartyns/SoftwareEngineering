/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Repository;

import Model.ECG;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
/**
 *
 * @author danielmartins
 */
@Repository
public interface ECGRepository extends JpaRepository<ECG,Long>{
    /**
     * 
     * @param sensor
     * @return sensor's id 
     */
    @Query("SELECT e.id FROM ECG e WHERE e.sensor = :sensor")
    public int checkSensor(@Param("sensor") String sensor);
}
