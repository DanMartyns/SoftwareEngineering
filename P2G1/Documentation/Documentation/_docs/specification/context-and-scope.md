---
layout: documentation-default
category: Specification
order: 1
---

## Context

In the modern world, the concept of Internet of Things (IoT) is spreading as each
day passes and everyone has very high expectations on its future market.
Smart Farms are one branch of this concept, which targets the monitoring and
actuation in big farms around the globe. There are already some farms with
well-established systems that allow the farmer to interact with the farm in
a digital way through sensors and actuators.

The main goal of **SmartFarm** is to provide the farmers a reliable web platform
to monitor the environmental conditions of its farm, as well as to define alerts
for unusual values. The farmer will also be able to send values/instructions
to the actuators on the farm, to perform various actions.

## Scope

![SmartFarm Logo](https://firebasestorage.googleapis.com/v0/b/smartfarm-9779d.appspot.com/o/logo-medium.png?alt=media&token=b6552b69-4a1f-4f29-9ab0-b342547f6904)

**SmartFarm** intents to be the tool that helps farmers by monitoring and acting
upon their farms. The farmer will be able to check the environmental metrics
of his farms using a web portal. It will also be possible to act upon the farms,
with the pre-defined actuators. To efficiently monitor large-scale farms,
the platform will provide a mechanism to define alerts, based on thresholds
and statistical information gathered by the sensors on the farm.

The platform is intended to be as flexible and extensible as possible, being
able to handle diverse sensors, such as, temperature, humidity, air pressure,
motion and more. It is also designed to be easy to the farmer to integrate newly
added sensors, although limited to pre-defined types. The platform also exposes
an HTTP API for other UI projects that desire to use the SmartFarm backend.