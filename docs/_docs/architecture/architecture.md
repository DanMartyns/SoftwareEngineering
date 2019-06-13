---
layout: documentation-default
category: Architecture
order: 1
---

## System Architecture

![Architecture]({{ site.baseurl }}/images/docs/arch1.png)

#### Sensor, C# Application and Kafka

This part of our architecture is responsible for gathering, processing and transporting the data from its origin in the sensor to our main program.

#### Main Program
The **MainProgram** component is one of the central pieces of the platform; 
this module inspects all the data retrieved by the sensor spread, processes it (calculates averages) and streams it to **Dashboard** listening.
The **Main Program** module, provides
JPA operations over sensors. It is also coupled with the **Relational Data Base**
module, since all operations are done on the relational database

#### ELK Stack

The *Elastic Search*, *Logstash* and *Kibana* are also present in the platform
to monitor and centralize all the logs the platform may report.

It is also shows the heartbeat metrics, because wasn't possible to show on the Dashboard.

#### Relational Data Base

The **Relational database** is a *MySQl* database that is used to store the average values 
​​from the sensor each minute, in case, if the kafka fails. 
Works like a safe-guard, to the plataform do not stop working.

It is used to provide data persistence.

#### Dashboard

This is the part of the architecture that the user interacts with. The user is presented to a video or game, which he will react to. The reaction, measured in beats per minute, is presented live. This module is currently build using *ReactJS*.

#### Docker
Docker is a tool designed to make it easier to create, deploy, and run applications by using containers. Containers allow a developer to package up an application with all of the parts it needs, such as libraries and other dependencies, and ship it all out as one package.
The goal was use Docker to separate the technologies and simulate a distributed system with the technologies working independently.
For example, the relational database, works like a micro service accessed by main program.

### Jenkins
Jenkins is an open source automation tool written in Java with plugins built for Continuous Integration purpose. Jenkins is used to build and test your software projects continuously making it easier for developers to integrate changes to the project, and making it easier for users to obtain a fresh build.
After building each component, the jenkins is responsable to test and running each. Jenkins offer an access transparency and a position transparency, because doesn’t matter if the repository is local or remote and doesn’t matter the fisically location of the machines, the jenkins is capable of sending orders to each machine and run the components.