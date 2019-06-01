package Service;

import org.apache.kafka.clients.producer.ProducerRecord;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.kafka.core.KafkaTemplate;
import org.springframework.stereotype.Service;

@Service
public class ProducerBPMI<K,V> {

    private static final Logger logger = LoggerFactory.getLogger(ProducerBPMI.class);
    private static final String TOPIC = "bpmi-topic";
    
    public ProducerBPMI() {}
    
    @Autowired
    private KafkaTemplate<K,V> kafkaTemplate;

    public void sendMessage(K from,V message) {
        //logger.info(String.format("%s -> Producing message -> %s",from, message));
        
        this.kafkaTemplate.send(new ProducerRecord<>(TOPIC, from, message));
    } 
}
