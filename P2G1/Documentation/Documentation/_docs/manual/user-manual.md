---
layout: documentation-default
category: Manual
order: 1
---

## User Manual

On this section it is described the possible UI experience flows on the SmartFarm platform, along with system screenshots to ease the understanding.

To take advantage of the platform, the user needs to be registered. If the user isn't already registered, he needs to click on "Register Now!" button.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/front_login_register.png" alt=""></span>

If the user chooses to register itself, he must fill the inputs with the desired user name and password.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/register_page.png" alt=""></span>

After the registry, the user needs to login (using the correspondent username and password) to access the main dashboard.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/login_page.png" alt=""></span>

On the main page, the user can choose the desired subsection, clicking on the respective tab.

Let's click on "See farms" tab.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/see_farms.png" alt=""></span>

The option will display the farms that are associated with the logged user.

If the user wants to create a new farm, he must click on "Add farm" button, and it will display a new page where the user must fill the name, the address, the area of the farm, and pick in the map the farm coordinates. Finally, click on "Add new farm" to commit the operation.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/new_farm.png" alt=""></span>

Each farm can have several sensors and actuators.
If the user clicks on "See sensors", it will be displayed all the information about every sensor of every farm of the logged user.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/see_sensors.png" alt=""></span>

Each sensor has a page which display the values sent by the sensor, the average of those values and other sensor details.
It will also display a map with the location of the sensor, and it will allow the user to send values to the sensor.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/sensor_page_2.png" alt=""></span>

If the user wants to add a new sensor, just click on "Add sensor" and fill the needed information.
The available farms will be displayed, which means that the user can only choose to add a new sensor in a previously created farm.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/new_sensor1.png" alt=""></span>

Next, the user writes the name of the sensor and selects one of the sensor types available.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/new_sensor2.png" alt=""></span>

Sequentially, the user must write the sensor model and select if it's an actuator or not. Then, pick the sensor coordinates and click on "Add new sensor".

Let's add two temperature sensors, with the names "temp200" and model "DS18B20".
If we list all sensors we can see the detailed about the sensors recently added.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/see_added_sensors.png" alt=""></span>

If the user wants to delete a sensor, click on "Delete" button. Let's delete the last sensor on the list:
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/see_deleted_sensor.png" alt=""></span>

The user can also create alerts associated with the values received from the sensors. Let's click on "See alerts" to check the alerts.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/see_alerts.png" alt=""></span>

To add new alerts, the user must click on "Add alert" button, and then choose the sensor that will trigger the alert.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/new_alert1.png" alt=""></span>

Then the user must select the alert type between the ones available:
* "Maximum" if the alert triggers when a value is higher that the threshold;
* "Minimum" if the alert triggers when a value is lower thatn the threshold;
* "Maximum Average" if the alert triggers when a value is higher than the sensor average + threshold;
* "Minimum Average" if the alert triggers when a value is lower than the sensor average - threshold.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/new_alert2.png" alt=""></span>

After the alert type is selected, the user must write the desired threshold for the alert.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/new_alert3.png" alt=""></span>

Finally, if the user wants to actuate on a sensor when the alert is triggered, it is possible by clicking on "Add actuator", selecting the sensor where he wants to actuate and write the value he wants to send.

After everything in configured, the user clicks on "Add new alert".
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/new_alert4.png" alt=""></span>

And if we list the alerts again, we'll see the new alert. Whenever the sensor sends a value that triggers the threshold, the alert will be triggered and the value "ON" will be sent to the actuator sensor.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/see_created_alert.png" alt=""></span>

If we click on an alert, we can see its details and a list with all the times that he has been triggered, with the value that has triggered it and the timestamp.
<br>
<br>
<span class="image"><img src="{{ site.baseurl }}/images/user_manual/alert_page.png" alt=""></span>
