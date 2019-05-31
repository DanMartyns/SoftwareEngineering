---
layout: documentation-default
category: Developer
order: 9
---

## System Deployment

The SmartFarm system deployment is assured by the *Jenkins* automation server.
By making use of the power of the *Jenkins* pipeline, specific stages were defined:

1. **Repository clone** - All Smartfarm’s source code is maintained in a SCM
(Source Control Management) repository (Gitlab) and the most recent version
is always at the master branch;

2. **Build with tests** - This stage is consequenquently divided in some steps:
    1. **Environment setup** - in order to successfully test all modules, there are
    some dependencies that must be setted up before start (like connection to
    databases and other Smartfarm modules), so a docker environment must be
    started in the first place to fulfill these dependencies;
    2. **Test and build** - using *Maven* automation tool, and based on the
    defined tests (unit and integration) for each module, the source code is
    compiled, tested and built;
    3. **Clean**  - after the latter step is finished, the temporary folders
    and files are removed and the docker environment is stopped and deleted
    (containers and network) in order to keep the file system available and clean.

3. **Deploy** -  After all modules are built, they must be distributed by the.
respective deploy machine. As the Smartfarm’s deploy machine is a unique mainframe,
all the previous built modules are combined in one folder, that is sent to the
destination appliance, to a specific path where the modules should be deployed.
After that, the production environment should be restarted (the docker containers),
in order to make the changes visible.

4. **Deploy result** - In order to inform the result status of the whole process,
after the deploy stage (or if the pipeline suddenly stops due to errors on
any stage) , the status is analyzed and sent by email to all developers.
If something during the preocess went wrong, the logs will attach that email
in order to analyze the situation immediately.

All the previous definitions of modules and deploy paths, as well as the deploy
machine location are defined in the respective (*bash*) scripts, which can be
changed at any time in order to adapt to the developer team needs.
