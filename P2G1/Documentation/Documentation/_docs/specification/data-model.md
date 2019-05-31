---
layout: documentation-default
category: Specification
order: 4
---

## Data Model


The information retrieved from the sensors may be different from one to another. To allow fast and uniform data processing, and scalability to add sensors from other types, it was estabilished an uniform syntax for the messages across all types of sensors.

The message should be formatted as a *JSON* message, as in the next example:
**{'value': '15.6', 'timestamp': '2018-06-02T10:27:19.053371', 'status': 'OK'}**

Where
* *value* is a numerical value that represents the value being sent. To allow the creation of charts and the calculation of averages, all values sent must be numeric. If there is a sensor with non-numeric data, it must be converted into a numeric format;
* *timestamp* is the sensor timestamp as a string;
* *status* is the current sensor status; if the sensor status didn't changed, this field will remain the same as in the last message.


The following diagram represents **SmartFarm** data model. The model is not deployed as is, because it is split between micro-services. Still, it is logically coupled as the next diagram shows.

![DataModel]({{ site.baseurl }}/images/docs/datamodel.png)


| Entity             	| Farms       |
| --------------------- | ---------------------------------------------------- |
| Description           | This entity will save information about a farm, storing his information such as name, address, area and localization |
| Module         | Farms Management |

| Entity             	| Sensors       |
| --------------------- | ---------------------------------------------------- |
| Description           | This entity represents the sensors in the system. A sensor is always associated with a farm and has attributes such as name, model, actuator (true if is an actuator, false otherwise), localization and others. |
| Module         | Sensors Management |

| Entity             	| Users       |
| --------------------- | ---------------------------------------------------- |
| Description           | This entity represents the users of the platform and stores the relevant information about the users. |
| Module         | Users Management |

| Entity             	| PermissionGroups       |
| --------------------- | ---------------------------------------------------- |
| Description           | This entity is associated with users and represents the permissions each user has to read data from sensors, write (send values to actuators) and others. |
| Module         | Users Management |

| Entity             	| Alerts       |
| --------------------- | ---------------------------------------------------- |
| Description           | This entity saves the alerts specified by the users for each sensor, having as important attributes the alert type and the threshold. |
| Module         | Alerts & Actuators Management |

| Entity             	| Actuators       |
| --------------------- | ---------------------------------------------------- |
| Description           | This entity represents the automated actuators that are associated with the alerts. Every time an alert is triggered, all actuators for that alert are activated, and the value in the actuator is sent to the sensor. |
| Module         | Alerts & Actuators Management |

| Entity             	| Triggered Alerts       |
| --------------------- | ---------------------------------------------------- |
| Description           | This entity represents the alerts that were triggered, with its ID and the timestamp of when it ocurred. |
| Module         | Alerts & Actuators Management |

| Entity             	| Values       |
| --------------------- | ---------------------------------------------------- |
| Description           | This entity represents the values sent by the sensors to the platform. It is implemented as a No-SQL database to accomodate very large loads of data without any additional delay and to accomodate changes in the format of the messages sent by the sensors without any refactoring. |
| Module         | SmartFarm Data Persistence |

