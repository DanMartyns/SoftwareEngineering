---
layout: documentation-default
category: Developer
order: 5
---

## SmartFarm Data Processing

This module stores the alerts defined by the users, as well as the actuators
associated with the alerts. Everytime a sensor sends a new value to the platform,
some processing is made by this module, using *Kafka Streams*:

1. The new average value from the sensor is calculated and is sent to a
separated topic, to be stored by another module;
2. If any alert is triggered with the new value, the alert ID, the value sent
by the sensor and the timestamp are sent to a Kafka topic;
3. If any actuator is associated with the triggered alert, it is sent the
defined value for the sensors associated with the actuator.
4. If the sensor sends a new status, different from the previous one, stored
in a KTable, the new status is sent to a Kafka topic, to be updated by
the other modules.

This module also provides an HTTP API to allow the user to add alerts and actuators.
