---
layout: documentation-default
category: Developer
order: 3
---

## NGINX Reverse Proxy

So that all endpoints of the different modules could be centralized, an *NGINX*
reverse proxy server was created. Furthermore, *NGINX* is heavily optimized for
distributing and scheduling HTTP requests across a pool of servers (although we
don't use multiple instances of the different microservices, in much bigger
platform, it could be easily added to the configuration of *NGINX* more servers
and load balancing across a range of servers those requests).

The **SmartFarm NGINX Proxy** is running on port 80 and provides the following
endpoints:

* `/`: for user, farm and sensors management as well as for a web socket for
consuming data (points to the SmartFarm Management/Service Layer API);
* `/persistence`: for accessing long term data form sensors (points to the
SmartFarm Data Persistence API);
* `/alerts/actuators`: for actuators and its data management (points to the
Data Processing API);
* `/alerts`: for alerts management (points to the Data Processing API);
* `/triggered-alerts`: for accessing historical triggered alerts data
(points to the Triggered Alerts API);
* `/triggered-alerts/smartfarm`: points to an web socket which keeps sending
information regarding triggered alerts.

For all of this endpoints, CORS (Cross-Origin Resource Sharing) had to be
supported, since there were requests made between services in different machines.
In order to supported the following headers were added to each location:

```
proxy_set_header 'Access-Control-Allow-Origin' '*';
```

Support requests from any origin machine (this origin can be modified in cases
where the origin request must be only one machine, for authentication purposes,
for example).

```
proxy_set_header 'Access-Control-Allow-Headers'
    'content-type,authentication';
```

Between different machines, only allow `Content-Type` and `Authentication` headers.

```
proxy_set_header 'Access-Control-Allow-Methods'
    'GET,HEAD,POST,PUT,PATCH,DELETE,OPTIONS,TRACE';
```

Only allow the mentioned HTTP methods.
