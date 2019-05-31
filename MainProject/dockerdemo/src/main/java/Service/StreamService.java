/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Service;

import Model.Stream;
import java.util.Optional;

/**
 *
 * @author danielmartins
 */

public interface StreamService {
    
    Stream save(Stream stream);

    Optional<Stream> findOne(int id);

    Iterable<Stream> findAll();

    long count();

    void delete(Stream stream);
}