/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Repository;

import Model.ECG;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
/**
 *
 * @author danielmartins
 */
@Repository
public interface ECGRepository extends JpaRepository<ECG,Long>{
    /**
     * 
     * @return the last result
     */
    @Query("SELECT e FROM ECG e ORDER BY e.id DESC")
    public List<ECG> lastValue();
}
