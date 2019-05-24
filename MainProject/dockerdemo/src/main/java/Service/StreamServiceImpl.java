/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Service;

import Model.Stream;
import Repository.StreamRepository;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 *
 * @author danielmartins
 */
@Service
public class StreamServiceImpl implements StreamService {
    
    private final StreamRepository streamRepository;
    
    @Autowired
    public StreamServiceImpl(StreamRepository streamRepository) {
        this.streamRepository = streamRepository;
    }

    @Override
    public Stream save(Stream stream) {
        return streamRepository.save(stream);
    }

    @Override
    public Optional<Stream> findOne(String id) {
        return streamRepository.findById(id);
    }

    @Override
    public Iterable<Stream> findAll() {
        return streamRepository.findAll();
    }


    @Override
    public long count() {
        return streamRepository.count();
    }

    @Override
    public void delete(Stream stream) {
        streamRepository.delete(stream);
    }    
}
