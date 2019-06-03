#!/usr/bin/env bash
######### Content of the server when i need make pull of the images ##########
RESPONSE="HTTP/1.1 200 OK\r\nConnection: keep-alive\r\n\r\n${2:-"OK"}\r\n"
while { echo -en "$RESPONSE"; } | nc -l "${1:-8080}"; do
	rm -f SoftwareEngineering  
	git clone https://github.com/DanMartyns/SoftwareEngineering.git > logGit.txt
	cd SoftwareEngineering
	mvn -f MainProject/dockerdemo/pom.xml -Dmaven.test.failure.ignore=false package
	docker pull 192.168.160.86:5000/p2g1_mysql
	docker container kill p2g1_mysql
	docker container rm p2g1_mysql
	docker run -d --name p2g1_mysql -p 42306:3306 192.168.160.86:5000/p2g1_mysql

	docker pull 192.168.160.86:5000/p2g1_dashboard
	docker container kill p2g1_dashboard
	docker container rm p2g1_dashboard
	docker run -d --name p2g1_dashboard -p 42002:3000 192.168.160.86:5000/p2g1_dashboard

	docker pull 192.168.160.86:5000/p2g1_main
	docker container kill p2g1_main
	docker container rm p2g1_main
	docker run -d --name p2g1_main -p 42020:8080 192.168.160.86:5000/p2g1_main

	docker pull 192.168.160.86:5000/p2g1_kibana
	docker container kill p2g1_kibana
	docker container rm p2g1_kibana
	docker run -d --name p2g1_kibana -p 42560:5601 192.168.160.86:5000/p2g1_kibana

	docker pull 192.168.160.86:5000/p2g1_elasticsearch
	docker container kill p2g1_elasticsearch
	docker container rm p2g1_elasticsearch
	docker run -d --name p2g1_elasticsearch -p 42920:9200 -p 42930:9300 192.168.160.86:5000/p2g1_elasticsearch

	docker pull 192.168.160.86:5000/p2g1_logstash
	docker container kill p2g1_logstash
	docker container rm p2g1_logstash
	docker run -d --name p2g1_logstash -p 5000:5000 192.168.160.86:5000/p2g1_logstash
done

######### Content of the server when i need make push of the images ##########
#!/usr/bin/env bash
RESPONSE="HTTP/1.1 200 OK\r\nConnection: keep-alive\r\n\r\n${2:-"OK"}\r\n"
while { echo -en "$RESPONSE"; } | nc -l "${1:-8080}"; do
	echo "\nSoftwareEngineering folder removed\n"
	rm -rf SoftwareEngineering  
	echo "\nSoftwareEngineering folder cloned\n"
	git clone https://github.com/DanMartyns/SoftwareEngineering.git
	echo "\nEntering inside folder\n"
	cd SoftwareEngineering/P2G1 
	echo "\nSoftwareEngineering build package\n"
	mvn -f MainProject/dockerdemo/pom.xml -Dmaven.test.failure.ignore=false package	
	echo "\nDocker Compose up and build\n"  
	docker-compose up -f docker-compose_without_portainer.yml --build 
	docker image tag p2g1_dashboard 192.168.160.86:5000/p2g1_dashboard
  	docker push 192.168.160.86:5000/p2g1_dashboard
        docker image tag p2g1_main 192.168.160.86:5000/p2g1_main
        docker push 192.168.160.86:5000/p2g1_main
        docker image tag p2g1_mysql 192.168.160.86:5000/p2g1_mysql
        docker push 192.168.160.86:5000/p2g1_mysql	
        docker image tag p2g1_logstash 192.168.160.86:5000/p2g1_logstash
        docker push 192.168.160.86:5000/p2g1_logstash
        docker image tag p2g1_kibana 192.168.160.86:5000/p2g1_kibana
        docker push 192.168.160.86:5000/p2g1_kibana
        docker image tag p2g1_elasticsearch 192.168.160.86:5000/p2g1_elasticsearch
        docker push 192.168.160.86:5000/p2g1_elasticsearch
done

