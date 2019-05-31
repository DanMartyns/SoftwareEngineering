package Service;

import org.apache.kafka.clients.producer.ProducerRecord;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.kafka.core.KafkaTemplate;
import org.springframework.stereotype.Service;

@Service
public class Producer {

    private static final Logger logger = LoggerFactory.getLogger(Producer.class);
    private static final String TOPIC = "bpmi-topic";
    
    public Producer() {}
    
    @Autowired
    private KafkaTemplate kafkaTemplate;

    public void sendMessage(String from,Integer message) {
        //logger.info(String.format("%s -> Producing message -> %s",from, message));
        
        this.kafkaTemplate.send(new ProducerRecord<String,Integer>(TOPIC, from, message));
    } 
}
