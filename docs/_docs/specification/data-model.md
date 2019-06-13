---
layout: documentation-default
category: Specification
order: 4
---

## Data Model


The information retrieved from the sensors reaches to the main application in a JSON format, allowing fast and uniform data processing.
The following message is an example of a message sent by the sensor to the main application:

**{'key': 'IL0111111', 'value': '100', 'timestamp’: ‘2018-06-02T10:27:19.053371’,}**

Where:
* *value* is a numeric value representing the current bpm measured by the sensor;
* *timestamp* is the sensor timestamp as a string;
* *key* is the id of the sensor.