---
layout: documentation-default
category: Specification
order: 3
---

## Scenarios

This section describes three important scenarios where the platform can be be useful to answer the user needs.

**Farm daily monitoring**

Bob is a farmer who has multiple lands, on which he built farms, and who doesn’t have the time neither the human resources to take care of all of them. He needs to monitor the temperature and humidity of all his plants, so that they can grow in good conditions. He uses SmartFarm to monitor all his farms and the environmental conditions they’re exposed to, watching real-time and past values from the sensors distributed in the farm.

**Farm notification awareness**

Bob needs to monitor the extreme temperatures in his farms, since these extreme conditions can ruin all his plantation. He uses Smartfarm to define alerts in charge of notifying him whenever an extreme weather condition occurs.

**Farm automated actuation**

Bob installed a physical infrastructure on his farm that acts similar to a greenhouse and that is fully automated. This infrastructure can avoid that the plants suffer from extreme weather conditions. The greenhouse can also irrigate the plants whenever needed. To monitor the watering of the plants, Bob uses SmartFarm to set actions so that, when extreme temperatures arise, the plantation will automatically be watered.



## Use Cases

The following section describes the most important use cases targeted in the system. **All use cases described were tested** and are part of the build pipeline. According to its scope, the use cases are divided in three subsections: Sensor persistence, sensor state and alarms & actuators.

**Sensor Persistence**

| Use case              | Read Sensor Last Values       |
| --------------------- | ---------------------------------------------------- |
| Description           | Read last value sent from sensor |
| Given            | the sensor id 5672 |
| When              | the sensor 5672 sends the value 15.2 to the platform |
| Then     | the value 15.2 is available on the platform |
{: .docs-table .use-cases-table}


| Use case              | Read Sensor Historic Values              |
| --------------------- | ---------------------------------------------------- |
| Description           | Read historic values from sensor |
| Given            | the sensor id 9373 |
| When              | the sensor 9373 sends the values -1, 15 and 0 to the platform |
| Then     | the values -1, 15 and 0 is available on the platform |
{: .docs-table .use-cases-table}


**Sensor State**


| Use case              | Change Sensor State                |
| --------------------- | ---------------------------------------------------- |
| Description           | Sensor changes his state by sending a message        |
| Given            | the sensor id 666 |
| When              | the sensor 666 sends data to the platform with status:"broken" |
| Then     |  the sensor status should be broken|
{: .docs-table .use-cases-table}


| Use case              | Visualize farm location            |
| --------------------- | ---------------------------------------------------- |
| Description           | Visualize farm sensors’ location on a map |
| Given            | a new sensor with latitude 37.5 and longitude 23.6 |
| When              | the user checks the sensor description |
| Then     | the sensor latitude and longitude should be 37.5 and 23.6, respectively |
{: .docs-table .use-cases-table}


| Use case              | Sensor average value            |
| --------------------- | ---------------------------------------------------- |
| Description           | Read the average value from a sensor |
| Given            | a new sensor with id 4746 |
| When              | the sensor 4746 sends values 13.5, 16.5 and 15.0 to the platform |
| Then     | the average value of the sensor should be 15.0 |
{: .docs-table .use-cases-table}


**Alarms & Actuators**

| Use case              | Trigger an alert            |
| --------------------- | ---------------------------------------------------- |
| Description           | Sensor sends a value that triggers an alert |
| Given            | an alert of type "min" and threshold 20 for the sensor 1234 |
| When              | the sensor 1234 sends to the platform the value 21 |
| Then     | an alert is triggered |
{: .docs-table .use-cases-table}


| Use case              | Actuator sends value            |
| --------------------- | ---------------------------------------------------- |
| Description           |Sensor sends a value that triggers an alert that has an actuator |
| Given            | an alert defined with id of type "max" and threshold 10 for the sensor 4321 with an actuator defined for the sensor 29 with the value "ON" |
| When              | the sensor 4321 sends the value 15 to the platform |
| Then     | the sensor 29 will receive a message with the value "ON" |
{: .docs-table .use-cases-table}



