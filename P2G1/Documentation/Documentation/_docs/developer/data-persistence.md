---
layout: documentation-default
category: Developer
order: 7
---

## SmartFarm Data Persistence

The **SmartFarm Data Persistence** contains the historic values from the sensors,
as well as the calculated averages for each sensor. Its persistence uses the
*No-SQL MongoDB* technology to allow the storage of large amounts of data fast
and reliably.

We opted by a No-SQL database due to its performance in insert operations
(most of the operations on this database are inserts), his ability to store
large quantities of data with little overhead and eased scalability if we need
to change the sensor message format (no need to change the schema).

This module has an HTTP API that allows for queries of values and averages from
a sensor. The data coming from the sensor and the averages are gathered directly
from the *Kafka* topics.