---
layout: documentation-default
category: Developer
order: 2
---

## SmartFarm Web Portal

This module, also named as **dashboard**, contains all the interface used by
the user to interact with all the platform back-end. It was developed with
*ReactJS* and its interaction makes use of the APIs available.

It can be fully adapted or substituted by another module provided it uses the
APIs correctly.

It is present in the folder *dashboard* where it has the source code,
and contains two files (*index.js* - defines the visible index routes and
its views - and *routes.js* - defines base routes available through the
dashboard) and other relevant parts separated between other three folders:
components, containers and views. The first one contains the layout components
separated by files. The second one contains the base Javascript code which
includes all routes path and what component they call. The third one has
the pages, buttons, charts and widgets that come with the template,
and also the pages created for each functionality  defined with Javascript
code (making use of *ReactJS*).

This module is seen as a multi-container application with one single file
based on *Docker Compose*.
