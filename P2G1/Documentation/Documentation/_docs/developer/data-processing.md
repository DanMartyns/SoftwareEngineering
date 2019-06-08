---
layout: documentation-default
category: Developer
order: 3
---

## Heartrate Monitor Data Processing

This module stores the information comming from the broker. 
Everytime a sensor sends a new value to the platform,
some processing is made by this module, using *Streams*:

1. The sensor sends values every one second, for every five seconds is calculated
the average and send to a relational database, to be stored;
2. The idea is to create a delay, so that it can be received and processed by the dashboard;

#### Problems and features not implemented in Data Processing

1. The main objective was to classify the heartbeats, assuming that horror videos would create more frequent beats, facilitating classification.
2. The data processing will detect an high heart beat value, from the values sent by sensor, classify depending on how much higher is the value and send to a new topic.
