#!/usr/bin/env bash
RESPONSE="HTTP/1.1 200 OK\r\nConnection: keep-alive\r\n\r\n${2:-"OK"}\r\n"
while { echo -en "$RESPONSE"; } | nc -l "${1:-8080}"; do
	rm -f SoftwareEngineering  
	git clone https://github.com/DanMartyns/SoftwareEngineering.git > logGit.txt
	cd SoftwareEngineering 
	docker-compose up > logCompose.txt 
done
