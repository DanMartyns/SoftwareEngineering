---
layout: documentation-default
category: Developer
order: 8
---

## Gateway/Sensor

On our system we have two types of gateways:

* the gateways that receive values from the sensor and send them to the platform;
* the gateways that receive values from the platform and send them to a sensor.

Our gateways are deployed using *Python3*. On the first case, they emulate
the polling of a value from a sensor and send the to the platform.
On the second case, the gateways receive the value from the sensor by push
method and send them to a sensor.

In both cases, the gateways connect directly to a *Kafka* broker, which allows
stability and resilience in the case of platform failure.