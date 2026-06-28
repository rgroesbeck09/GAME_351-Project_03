# GAME_351-Project_03

Player Can Kick: Christopher Garcia-Arvizu
Added 3 separate kicking animations to the player, chosen at random, when close enough to movable objects such as wooden
crate, tumbleweed, barrel, and basket, the object will go flying when kicked, each object has a slightly different mass
so it will move accordingly. Added script to play random kicking animations as well as to detect a collider and apply 
force to it so it can move when kicked.


Monsoon Weather: Christopehr Garcia-Arvizu
Added monsoon like weather by adding dark clouds in the sky, texture was created by myself in Microsoft Paint then imported into the
project. Added particle system for rain, rain drop texture was created in paint3D and imported, user can adjust rain rate 
for a calmer rain fall or for more agressive. Added multiple audio sources from the provided audios, wind audio is looping, 
rain audio is looping, thunder audio will play after a short delay after lightning bolt and lightning flash appear. Lightning
bolt texture was created in paint3D and imported. The scene lighting was dimmed for that monsoon feel. Monsoon controller script 
handles the timed audio and light flashes for thunder, lightning bolt, and lightning flash. On Start(), the wind and rain audios 
are started as well as the rain particle system. 

