#!/bin/bash

#Here we will have the essential directories for the entire project 
MODULES=(
    MainProject/dockerdemo
)

for i in ${!MODULES[@]}; do
    # Go to module project folder
    cd ${MODULES[$i]}
    
    mvn test
done
