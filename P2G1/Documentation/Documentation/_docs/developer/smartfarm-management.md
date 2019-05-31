---
layout: documentation-default
category: Developer
order: 4
---

## SmartFarm Management (Service Layer)

The SmartFarm Management includes particular components that define and manage
Farms, Sensors and Users. Each one supports CRUD operations and manages
its information. This module is based on the *SpringBoot* framework, making any
detail easily modified. Each component interacts with the remaining components,
thus forming the current data model.

We opted by a SQL database due to the nature of the type of data to be treated
and related. It uses *PostgreSQL* but it can be easily changed by another one.
This module has available a HTTP API to perform any CRUD operation.
Each endpoint is protected by the Authentication System developed,
which is described next.

## Authentication System

In order to protect the farmers account and platform overall, SmartFarm access
is based on *Springboot's Open Authorization (OAuth2)* protocol implementation.

It is noteworthy the fact that, although all the main endpoints relative to
User, Farm and Sensors management is protected and the client needs to be
authenticated in order to use any of the provided endpoints, the use of any of
the other provided endpoints in the SmartFarm API is **not** authenticated and,
consequently, not totally secure. The choice to have only the management system
authenticated was due to the easily integration of the User Management endpoints
to manage user authentications and to development time constraints.
On the other hand, since the authentication uses OAuth2, it can be easily
integrated with the other endpoints (and respective modules).

Following the previous paragrah, it is also import to note that, although not
having all the endpoints authenticated, the developed Web Portal only lets
authenticated users browse through the platform.

Wrapping up, the authentication system uses two main endpoints:

* `authorize`: request a temporary token using the clients credentials. If the
user is registered in the platform, a succesful response will arrive with the
token to use with the endpoints that request authentication.

* `check_token`: check if a given token is valid (mainly used within the Web
Portal to check if a user is logged in/authenticated).

Although the previous endpoints will be further detailed in the API section of
this category as well as the endpoints that request authentication, we will also
mention that, in order to consume any of those authenticated endpoints, an HTTP
`Authentication` header needs to be in the request, using as its value
`Bearer user_token`.

The Authentication System is implemented in the same module as the User, Farm
and Sensors Management, i.e., the SmartFarm Service Layer.
The following files implement the overall system:

* `AuthorizationServerConfig`: configures the Authentication and Authorization
server using the Springboot's security framework;
* `ResourceServerConfig`: configures the current application (in this case the
Service Layer) as a resource server and which endpoints are publicly open and
which are closed and request authentication.