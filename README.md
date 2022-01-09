# Lette_Unity01

## This Project was made as a Educational Project. It is not maintained and no new features will be added. 

Practice Unity project for the Training.

Contains:
- weapon, that points to the mouse.
- Player (sphere) moving via Rigidbody.addForce();
- Camera being attatched to player via script.
- weapon bullets instantiated via weapon script with start velocity.
- bullets despawn on enemy collision or positional inactivity.
- enemies, power ups and health pickups are instantiated from prefab via Random method in GameManager script.
- enemies follow the player and damage it in close proximitry.
- using Havok Physics for more accurate physics calculations.


## Scripts

#### cameraScroll.cs
- put on camera, allows for using the scroll wheel to zoom in/out the camera

#### CollisionDamage.cs
- hurts the player by (default) 20 HP on contact, no further.

#### DontDestroyOnLoad.cs
- makes objects not get destroyed on scene load (unused)

#### Enemy.cs
- manages enemy health
	- gets damage from Projectile
- manages enemy NavMeshAgent (set destination to player and update)
- fills in enemy health bar

#### GameManager.cs
- manages gameStates (pause, main menu, etc.)
- manages global variables like collectables
- spawn enemies, collectables, power ups, and healing

#### GameState.cs
- enum for the Game States

#### Healthable.cs
- abstract class for all objects, that have health

#### Pickup.cs
- class for pickups, contains the type and a value

#### PickupType.cs
- enum for the various pickup types

#### Player.cs
- manages player health and movement
- reacts with pickups

#### PositionOffset.cs
- keeps an object, that is not child in a relative position to the object the script is attatched to.
- option to stay in same height or keep height offset aswell

#### Projectile.cs
- determines damage to give to enemy on impact
- despawns after physical inactivity or below respawn height

#### Respawn.cs
- resets whatever objet its attatched to's height when falling off the map.

#### Retarded.cs
- changes scale and light color on Update randomly

#### Weapon.cs
- rotates the weapon to the mouse cursor and instantiates a bullet with force on press of "fire1" (left mouse button)
