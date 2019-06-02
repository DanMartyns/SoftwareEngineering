package MainPackage;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;

import Controller.DataSensorController;
import Model.LoggerMessage;
import Model.Stream;
import Processing.dataSensor;
import Service.ProducerBPMI;
import Service.ProducerLOG;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.util.concurrent.TimeUnit;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.data.jpa.repository.config.EnableJpaAuditing;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.scheduling.annotation.EnableScheduling;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

@SpringBootApplication(scanBasePackages={"AccessData", "Controller","Model","Processing","Repository","Service"})
@ComponentScan(basePackageClasses = DataSensorController.class)
@ComponentScan(basePackageClasses = ConfigKafka.class)
@ComponentScan(basePackageClasses = ProducerBPMI.class)
@ComponentScan(basePackageClasses = dataSensor.class)
@ComponentScan(basePackageClasses = SimpleCORSFilter.class)
@EnableJpaAuditing
@EnableScheduling
@EnableJpaRepositories("Repository")
@EntityScan("Model")
public class ESApplication {

    private static final Logger logger = LoggerFactory.getLogger(ESApplication.class);
    
    @Autowired
    private static ProducerLOG<String,LoggerMessage> producerLog;
    
    @Autowired
    private ProducerBPMI<String,Stream> producer;    
    
    public static void main(String[] args) {
        SpringApplication.run(ESApplication.class, args);
        producerLog.sendMessage(new LoggerMessage("INFO","Initiating Application"));
    }
        
    public WebMvcConfigurer corsConfigurer() {
        return new WebMvcConfigurer() {
            @Override
            public void addCorsMappings(CorsRegistry registry) {
                registry.addMapping("/**").allowedOrigins("*");
            }
        };
    }
    @Scheduled(fixedDelay = 1000, initialDelay = 1000)
    public void dataTestFile() throws InterruptedException{
        try (FileReader reader = new FileReader("Data/ecg.txt");
             BufferedReader br = new BufferedReader(reader)) {
            while(true){
                String line;
                while ((line = br.readLine()) != null) {
                    String[] array = line.split(" ");
                    for(int i= 0; i < array.length; i++){
                        Stream obj = new Stream(Double.parseDouble(array[i]));
                        producer.sendMessage("1LN1200065", obj);
                        TimeUnit.SECONDS.sleep(1);
                    }

                }
                if ((line = br.readLine()) == null){
                    RandomAccessFile raf = new RandomAccessFile("ecg.txt", "r");
                    raf.seek(0);
                }
            }
        } catch (IOException e) {
            producerLog.sendMessage(new LoggerMessage("ERROR",String.format("IOException: %s%n", e)));
            logger.error(String.format("IOException: %s%n", e));
        }        
    }        
        
}
