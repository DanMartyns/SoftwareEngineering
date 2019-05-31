---
layout: documentation-default
category: Architecture
order: 2
---

## Deployment Architecture

The **SmartFarm** platform is currently composed of different interacting modules.
Each module is in charge of a different function.
The interaction between the different modules makes the **SmartFarm** a loosely
coupled, flexible, scalable and reliable platform.

The modules currently deployed are:

* SmartFarm Web Portal
* Reverse Proxy
* SmartFarm Service Layer
* SmartFarm Data Processing
* SmartFarm Triggered Alerts
* SmartFarm Persistence
* Relational Database
* NoSQL Database
* Broker
* ELK Stack
* TICK Stack
* Gateways

The continous integration and deployment is provided by *Jenkins* and all the components are containarized with the *Docker* platform.

![Architecture]({{ site.baseurl }}/images/docs/deployment.png)

### SmartFarm Web Portal

The **SmartFarm Web Portal** is the be the bridge between the user and the platform.

Since it's an independent system from the rest of the platform, it will consume
data from an HTTP API (using both REST and Web Sockets for live data consumption)
that the core platform provides.

This module is currently build using *ReactJS*, as represented in the diagram.

### Reverse Proxy

The **Reverse Proxy** can be seen as the API to external clients since it
aggregates all the necessary endpoints so that a web portal/frontend interface
can correctly integrate the SmartFarm core platform.

This module was designed using *Nginx*, as represented in the diagram.

### SmartFarm Service Layer

The **SmartFarm Service Layer** is the backbone of the platform relative to farms,
users and sensors management (implementing all of **SmartFarm Farms Management**,
**SmartFarm User Management** and **SmartFarm Sensors Management** components presented in the
SmartFarm architecture).

It also implements the and **SmartFarm AA** component, so that only authorized users access
private endpoints.

Currently, it is deployed using *Java*, with the *Spring Boot framework*.
The tests are done with the *Cucumber* library.

### SmartFarm Data Processing

The **SmartFarm Data Processing** receives the data coming from the sensors and
processes it in real-time.

This module integrates part of **SmartFarm Alerts & Actuators Management** and
**SmartFarm Sensor Analytics** architectural components in a single appliance.

Currently, the aggregation is done by gathering the new data coming from the sensors
from a broker, and after the aggregation is published into the broker again,
but transformed according to the processing.

It is deployed using *Java* with the *Spring Boot Framework* and uses the *Kafka Streams* library.

The given module also saves all the defined user alerts (similar to a rule, e.g.,
temperature cannot be higher than 30ºC) and all the values/events that triggered
those alerts.

Finally, upon the triggering of a given alert, some actions can be taken. This
module also manages the Actuators associate to the given sensors and provide
CRUD endpoints for them.

The tests are done with the *Cucumber* library and the *Junit* library.

### SmartFarm Triggered Alerts

This module registers and saves all the alerts that have been triggered,
so that the triggered alerts history can be accessed by the users.

This module represents part of the implementation of the **SmartFarm Alerts and Actuators Management**
component detailed in the SmartFarm architecture.

It is deployed using *Java* with the *Spring Boot Framework*.
The tests are done with the *Cucumber* library.

### SmartFarm Persistence

This module stores in a No-SQL database all the data coming from the sensors,
to later be acessed by the user. It represents part of the implementation of the **SmartFarm Data Persistence**.

It is deployed using *Java* with the *Spring Boot Framework*.
The tests are done with the *Cucumber* library.

### Relational Database

The **Relational database** is a *PostgreSQL* database that is used to store
the users, farms, sensors, authentication parameters, alert definition, triggered alerts and actuators.

It is used by most components to provide data persistence.

### NoSQL Database

The **NoSQL Database** is a *MongoDB* database used to store the data coming from the sensors.
It is designed to support the different formats of data that the sensors can send.

### Broker

The **Broker** module is a *Kafka* instance with multiple topics, and is used to
enable the communication between modules.

When a sensor sends data, posts it into the broker, that redistributes it according
to the defined listeners. The data processing also sends its processing outputs
to *Kakfa* topics that will be retrieved by the interested parties.

### ELK Stack

The *Elastic Search*, *Logstash* and *Kibana* are also present in the platform
to monitor and centralize all the logs the platform may report.

It is also used *MetricBeat* to gather the metrics from the virtual machines and the containers
which are essential to the correct functioning of the platform.

### TICK Stack

The *Telegraph*, *InfluxDB*, *Chronograph* and *Kapacitor* are deployed so that
the users/system admins can monitor the state of the machines where the platform
is deployed, giving all kinds of metrics (CPU usage, RAM Usage, Disk Usage, etc.).

### Gateways

The **Gateways** gather the data from multiple sensors of one type and
send them to the platform.

Currently, these gateways emulate the reception of values, and send them to
the platform. They are deployed using *Python 3*.
