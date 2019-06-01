#!/usr/bin/env bash
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

done
