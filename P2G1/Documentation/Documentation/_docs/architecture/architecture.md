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

#### Logstash, ElasticSearch and Kibana

#### Relational Data Base

#### Dashboard

This is the part of the architecture that the user interacts with. The user is presented to a video or game, which he will react to. The reaction, measured in beats per minute, is presented live.

#### Deployment (Jenkins and Docker)