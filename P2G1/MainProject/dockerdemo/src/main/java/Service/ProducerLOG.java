package Service;

import org.apache.kafka.clients.producer.ProducerRecord;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.kafka.core.KafkaTemplate;
import org.springframework.stereotype.Service;

@Service
public class ProducerLOG<K,V> {

    private static final Logger logger = LoggerFactory.getLogger(ProducerBPMI.class);
    private static final String TOPIC = "p2g1-logs";
    
    public ProducerLOG() {}
    
    @Autowired
    private KafkaTemplate<K,V> kafkaTemplate;

    public void sendMessage(V message) {
        this.kafkaTemplate.send((ProducerRecord<K, V>) new ProducerRecord<>(TOPIC, "LOG", message));
    } 
}