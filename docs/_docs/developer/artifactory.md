---
layout: documentation-default
category: Developer
order: 7
---

## Artifactory

The Heartrate Monitor system deployment is assured by the *Jenkins* automation server.
By making use of the power of the *Jenkins* pipeline, specific stages were defined:

1. **Repository clone** - All source code is maintained in a SCM
(Source Control Management) repository (Github) and the most recent version
is always at the master branch;

2. **Artifactory Configuration**

3. **Execute Maven** -  The jar file is created, followed by the cleanup of the project

4. **Publish build info** - Finally is published in the artifactory server

All the previous definitions of modules and deploy paths, as well as the deploy
machine location are defined in the respective (*bash*) scripts, which can be
changed at any time in order to adapt to the developer team needs.
