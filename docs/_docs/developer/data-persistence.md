---
layout: documentation-default
category: Developer
order: 4
---

## Heartrate Monitor Data Persistence

The **Heartrate Monitor Data Persistence** contains the historic values from the sensors,
for every 5 seconds, as well sensor who send the values and the average timestamps for the value.
Its persistence uses the *MySQL* technology to allow the storage of large amounts of data fast
and reliably.

We opted by a MySQL database due to its performance in insert operations
(most of the operations on this database are inserts and deletes).

This module has an HTTP API that allows for queries of values and averages from
a sensor. The data coming from the sensor and the averages are gathered directly
from the *Kafka* topics.