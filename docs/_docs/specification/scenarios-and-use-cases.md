---
layout: documentation-default
category: Specification
order: 3
---

## Scenarios

Dylan heard about our application from a collegue and wanted to give it a try. Knowing beforehand that he never liked spiders,
he wanted to know how his heart rate reacts to a video of spiders, in order to know if what he felt for them was fear.


## Use Cases

The following section describes the most important use cases targeted in the system. **All use cases described were tested** and are part of the build pipeline. According to its scope, the use cases are divided in three subsections: Sensor persistence, Main state .

**Sensor Persistence**

| Use case              | Read Sensor Values       |
| --------------------- | ---------------------------------------------------- |
| Description           | Read value sent from sensor |
| Given            | the sensor id IL0111111 |
| When              | the sensor IL0111111 sends the value 15.2 to the platform |
| Then     | the value 15.2 is available on the platform |
{: .docs-table .use-cases-table}

**Main State**


| Use case              | Change Main State                |
| --------------------- | ---------------------------------------------------- |
| Description           | Main changes his state when receive a value from the sensor       |
| Given            | the sensor id IL0111111 |
| When              | the sensor IL0111111 sends data to the platform with a value |
| Then     |  the main send a log message "Data processed and sended to dashboard"|
{: .docs-table .use-cases-table}


**Dashboard State**

| Use case              | Visualize real-time heartbeat            |
| --------------------- | ---------------------------------------------------- |
| Description           | Visualize heartbeat on the dashboard |
| Given            | a processed value from the main project |
| When              | the user checks his heartbeat |
| Then     | the dashboard gives him the exactly value received from sensor |
{: .docs-table .use-cases-table}




