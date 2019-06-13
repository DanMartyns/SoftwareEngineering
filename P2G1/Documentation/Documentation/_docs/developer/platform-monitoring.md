---
layout: documentation-default
category: Developer
order: 5
---

## Platform Monitoring (ELK)

To monitor the platform, our choice was to integrate the system with two
technology stacks (ELK - *Elastic Search, Logstash* and *Kibana*)

### Log Monitoring

To enable the log monitoring, all the component logs are sent to the *Docker*
container. From the *Docker* container all logs are redirected using *GELF*
driver - *Graylog Extended Log Format* - to the logstash instance.
Another option considered was FileBeat, which we didn’t use due to the ease
of use and simplicity of the *GELF* driver.

On the *Logstash* instance, the logs were appended with a common index (`es_index`)
to identify all the logs coming from our system. We also applied filters to
the relevant component logs, to be able to parse the values sent by the sensors,
the averages and other applicational metrics.

The *Logstash* instance is connected to an *ElasticSearch* instance to save
and query the incoming data. The *Kibana* UI is also connected to an
*ElasticSearch* instance, making it possible to debug all the components by
reading its logs in *Kibana* UI.
