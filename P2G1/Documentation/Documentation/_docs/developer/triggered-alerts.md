---
layout: documentation-default
category: Developer
order: 6
---

## SmartFarm Triggered Alerts

The **SmartFarm Triggered Alerts** module stores the alerts that were triggered
by the SmartFarm data processing. The alerts are stored in a *PostgreSQL* database,
and it is available an HTTP API to query the module for the alerts occurred.
The alerts are gathered by a listener attached to a *Kafka* topic.