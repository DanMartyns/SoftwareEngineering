#!/bin/bash

MODULES=(
    MainProject
)

FOLDERS=(
    MainProject-0.0.1-SNAPSHOT
)

DEPLOY_FOLDER=project_modules
DEPLOY_PATH=jenkins

MACHINE_USERNAME=p2g1
MACHINE_HOSTNAME=192.168.160.80

mkdir -p $DEPLOY_FOLDER

for i in ${!MODULES[@]}; do
    # Join jar and build in one folder
    cp -r ${MODULES[$i]}/target/${FOLDERS[$i]} $DEPLOY_FOLDER
    cp ${MODULES[$i]}/target/${FOLDERS[$i]}.jar $DEPLOY_FOLDER
done

# Copy dashboard to deploy folder
cp -r Dashboard/interface $DEPLOY_FOLDER

# Compress folder and send it to the deploy machine
tar -zcvf $DEPLOY_FOLDER.tgz $DEPLOY_FOLDER
scp -o StrictHostKeyChecking=no $DEPLOY_FOLDER.tgz $MACHINE_USERNAME@$MACHINE_HOSTNAME:~/$DEPLOY_PATH

# Decompress builded modules and restart docker container
ssh -o StrictHostKeyChecking=no $MACHINE_USERNAME@$MACHINE_HOSTNAME "mkdir -p $DEPLOY_PATH &&
    rm -rf $DEPLOY_PATH/$DEPLOY_FOLDER &&
    tar -zxvf $DEPLOY_PATH/$DEPLOY_FOLDER.tgz -C $DEPLOY_PATH &&
    docker restart softwareengineering_main_1 &&
    docker restart softwareengineering_dashboard_1 &&
    rm $DEPLOY_PATH/$DEPLOY_FOLDER.tgz"

# Clean up things
rm -rf $DEPLOY_FOLDER
rm $DEPLOY_FOLDER.tgz
