# GAME_351-Project_03

Player Can Kick: Christopher Garcia-Arvizu
Added 3 separate kicking animations to the player, chosen at random, when close enough to movable objects such as wooden
crate, tumbleweed, barrel, and basket, the object will go flying when kicked, each object has a slightly different mass
so it will move accordingly. Added script to play random kicking animations as well as to detect a collider and apply 
force to it so it can move when kicked.

Monsoon Weather: Christopher Garcia-Arvizu
Added monsoon like weather by adding dark clouds in the sky, texture was created by myself in Microsoft Paint then imported into the
project. Added particle system for rain, rain drop texture was created in paint3D and imported, user can adjust rain rate 
for a calmer rain fall or for more agressive. Added multiple audio sources from the provided audios, wind audio is looping, 
rain audio is looping, thunder audio will play after a short delay after lightning bolt and lightning flash appear. Lightning
bolt texture was created in paint3D and imported. The scene lighting was dimmed for that monsoon feel. Monsoon controller script 
handles the timed audio and light flashes for thunder, lightning bolt, and lightning flash. On Start(), the wind and rain audios 
are started as well as the rain particle system. 

Dynamic Soundtrack: Amanda Bragg
Implemented an audio system that pulls from concepts about singletons, managers, spatial audio, and events. I created a singleton 
called AudioManager that controls the music tracks (default, suspense, and fight), and makes sure that only one track plays at a time. 
I also added a SupplyStoreMusicTrigger that uses a trigger event to transition the music when the player enters/exits the Supply Store. 
Then implemented PlayerShootingAudio which handles gunshot noise and also starts the fight music when combat begins. Also added 
FootstepAudio to play positional footstep noises. BanditAudio manages bandit taunts, pain/death sounds, and randomly timed intervals. 
The foley effects were 3D positional audio and the music tracks were looping 2D. All audio files used from the given project template. 

Shooting Games: Raymond Groesbeck
First step was to create a bullet that would trigger all the events that we would be doing in this project. After that I would need 
to modify the bandits animation chart to have the bandits die animation work. From here I would need to make a collider and script 
for the bandits. The script will detect when a bullet crosses the plane of the collider and that will trigger the death of the bandit.
Now onto the barrels, this was another thing that would need a modifcation to the collider. Similar to how I implemented the death of the
bandits we have the bullet trigger the explosion and leave behind some debris. 
