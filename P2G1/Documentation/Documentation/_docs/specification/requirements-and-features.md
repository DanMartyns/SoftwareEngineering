---
layout: documentation-default
category: Specification
order: 2
---

## Features

**SmartFarm** platform includes the following features:

* Providing **real-time values** for each sensor;
* Through the values obtained from the sensors, allow the user to know the the **sensors' location and display it in a map**;
* Present to the user the environmental metrics from its farms on **charts**;
* Allow the user to see the **average measurements** from the data received;
* Allow the user to **define thresholds and associate alerts** when the obtained values from the sensors exceed them;
* Allow the user to send values to **actuators**;
* Allow the user to program the platform to **automatically send values to actuators when alerts are triggered**;
* Allow the user to know the **current state** of the sensor (OK, broken, ...)
* **Easily** add new sensors;
* CRUD operations on **farms, sensors and streams**;
* Interactive and responsive **UI**.

## Requirements

The following requirements are needed form the **SmartFarm** system:

* The platform needs at least one server with public access to the internet;
* The platform will need, at last, 8GB of RAM memory and 4GB of disk memory (across all servers used);
* The area where the system will be implemented needs to have at least one
type of sensors (temperature, humidity, pressure, CO2, ...) available,
with internet access;
* The Web Portal, as well as the REST API, should require user authentication;
* Sensors may have a static or dynamic location;
* Sensors may change his state (OK, broken, ...) with a message;
* When an alarm is triggered, if an actuator is associated to that event,
the IoT platform should trigger it in less than one minute;
* When a sensor sends a value, the average value from the sensor must be calculated within one minute;
* A user can only monitor his farms.

