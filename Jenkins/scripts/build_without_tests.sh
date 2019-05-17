#!/bin/bash

#Here we will have the essential directories for the entire project 
MODULES=(
    MainProject
)

for i in ${!MODULES[@]}; do
    # Go to module project folder
    cd ${MODULES[$i]}
    
    # Clean old build files
    rm -rf target

    # Build without tests 
    mvn -X -Dmaven.test.skip=true clean package
    
    # Go again to project root folder
    cd ..
done
