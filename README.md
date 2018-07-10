# Akihabara-Simulation
A basic demonstration of Unity knowledge. This project simulates entities in a popular street in Akihabara, Japan. 

![Simulation](/misc/screenshot.png)
![Simulation inspired by](/misc/Akihabara.jpg)

## Components
### Cars
Cars drive along the streets and pick a random destination at the intersection. They avoid hitting other cars with a CarView object. They stop at intersections when the "signal" is red. If there is a collision, objects in the intersection will be removed after a short time.
### Pedestrians
Pedestrians are spawned out of view. They are agents confined to the sidewalk unless they are allowed to cross the street. They continue walking until they reach a random destination, which should also be out of view. Pedestrians have no collision detection with cars.
### Trains
Trains pass by every once in a while. They can be seen in camera position 1 and can be seen in more detail in camera position 3. Camera position 3 reveals that passengers are being loaded and off-loaded when the train pulls into the station.

## Knowledge Demonstrated
