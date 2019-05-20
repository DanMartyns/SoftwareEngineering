package MainPackage;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;

import Controller.HomeController;
import Controller.DataSensorController;
import org.springframework.boot.autoconfigure.domain.EntityScan;
import org.springframework.context.annotation.Bean;
import org.springframework.data.jpa.repository.config.EnableJpaAuditing;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.scheduling.annotation.EnableScheduling;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurerAdapter;

@SpringBootApplication(scanBasePackages={
"AccessData", "Controller","Model","Processing","Repository","Service"})
@ComponentScan(basePackageClasses = HomeController.class)
@ComponentScan(basePackageClasses = DataSensorController.class)
@EnableJpaAuditing
@EnableScheduling
@EnableJpaRepositories("Repository")
@EntityScan("Model")
public class ESApplication {

	public static void main(String[] args) {
		SpringApplication.run(ESApplication.class, args);
	}
        
        public WebMvcConfigurer corsConfigurer() {
            return new WebMvcConfigurer() {
                @Override
                public void addCorsMappings(CorsRegistry registry) {
                    registry.addMapping("/**").allowedOrigins("*");
                }
            };
        }
        
        
}
