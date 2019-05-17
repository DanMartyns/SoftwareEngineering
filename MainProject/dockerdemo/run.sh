docker ps -a | awk '{ print $1,$2 }' | grep dockerdemo | awk '{print $1 }' | xargs -I {} docker rm {}
mvn clean
mvn install #This will create a "dockerdemo.jar" in the target directory of the working directory
docker build -f DockerFile -t dockerdemo .
docker run --name Projeto -p 8080:8080 dockerdemo
mvn test
