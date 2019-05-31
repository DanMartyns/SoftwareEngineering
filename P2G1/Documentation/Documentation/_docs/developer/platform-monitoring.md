---
layout: documentation-default
category: Developer
order: 8
---

## Platform Monitoring (ELK & TICK)

To monitor the platform, our choice was to integrate the system with two
technology stacks (ELK - *Elastic Search, Logstash* and *Kibana* -
and TICK - *Telegraf, InfluxDB, Chronograf* and *Kapacitor*) to take advantage
of each one key points.

### Log Monitoring

To enable the log monitoring, all the component logs are sent to the *Docker*
container. From the *Docker* container all logs are redirected using *GELF*
driver - *Graylog Extended Log Format* - to the logstash instance.
Another option considered was FileBeat, which we didn’t use due to the ease
of use and simplicity of the *GELF* driver.

On the *Logstash* instance, the logs were appended with a common index (`es_202`)
to identify all the logs coming from our system. We also applied filters to
the relevant component logs, to be able to parse the values sent by the sensors,
the averages, the alarms and other applicational metrics.

The *Logstash* instance is connected to an *ElasticSearch* instance to save
and query the incoming data. The *Kibana* UI is also connected to an
*ElasticSearch* instance, making it possible to debug all the components by
reading its logs in *Kibana* UI.

### Containers monitoring

To monitor the containers individually, we used *MetricBeat*, a lightweight
shipper for metrics to *ElasticSearch*. We installed it on the host systems
and enabled the modules used (*NGINX*, *MongoDB*, *Docker*, System, *PostgreSQL*).
On *Kibana*, the dashboards were automatically created on the dashboards tab,
making the visualization and the configuration of the dashboard easier.

### System Monitoring

To monitor the system, we relied on the TICK stack to gather the system metrics
and show them in the *Chronograf* UI. It could be also done by the ELK stack
using the *MetricBeat* plugin, but the TICK stack allows us to easily define
alerts and system dashboards, which is an advantage over the *Kibana* UI.

### System alerts

Using the TICK stack we defined three alerts:

* High CPU Usage - Whenever the CPU usage is above 90%, triggers an alert;
* High RAM Usage - Whenever the RAM usage is above 90%, triggers an alert;
* High Disk Usage - Whenever the disk usage is above 80%, triggers an alert.

Every alert sends an e-mail to one element of the team, with the information
of the alert. In that way, whenever our system is overloaded we immediately
receive an e-mail.
