package Processing;

import Model.LoggerMessage;
import Service.ProducerLOG;
import Service.TopicServiceKafkaImpl;
import static org.junit.Assert.assertTrue;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

@RunWith(SpringRunner.class)
@SpringBootTest
public class DataSensor {

    @Autowired
    private ProducerLOG<String,LoggerMessage> producerLog;

    @Autowired
    private TopicServiceKafkaImpl topic;	

    @Test
    public void contextLoads() {
    }

    public void topics(){
        assertTrue(topic.getTopics().contains("bpmi-topic") );
    }
}