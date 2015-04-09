How to make a game loop: http://journal.stuffwithstuff.com/2014/07/15/a-turn-based-game-loop/


Event messaging:
	http://wiki.unity3d.com/index.php/CSharpMessenger_Extended
	http://wiki.unity3d.com/index.php/Advanced_CSharp_Messenger



Basic Game Cycle
* Start or Join game session
   * Select scenario (make scenario maker?)
   * Select armed forces
   * Arrange map objects (buildings, specials, big objects)
   * Select game objective(s)
   * Note, for the prototype this will be all “hard coded”
      * Creator = one side
      * Joiner = other side
* Start game cycle
* Take alternating turns until game objectives are complete
   * Basic turn cycle
* Wrap up game session
   * announce winner
   * give out experience
   * allow upgrades and save


Basic Turn Cycle
* for each team 
   * for each player in team
      * for each unit
         * move
         * if complex act and no move, then act
         * if simple act and move, act with move modifiers
         * if simple act an no move, act with no move modifiers
         * unit done
* determine objective states


Latest game flow diagram (march 2015)
* Player Manager
   * contains players
* Scenario
   * defines the setup and game logic for a game session
   * need Scenario Manager?
* Game Setup
   * make and change a setup using a Scenario as a factory
* Game Session
   * creates a container to hold the game logic components together for a game session, once complete the session is meant to be destroyed between level loads
   * The Progress method is meant to be called once per frame to see if the game session is over
   * While active:
      * start the first round
      * for each round
         * each player gets a round
            * each round goes through a number phases
* Notes:
   * want to move to a purely event driven model
      * http://forum.unity3d.com/threads/comparison-of-unity-c-messaging-events-systems.173492/
      *    * maybe there will be no reason for the Progress/Frame check


Events for game logic
* Player Manager 
   * emits - assign host
   * listens - login, logout
* Scenario
   * emits - game setup instance 
   * listens - map choice
* Game Setup
   * emits - player options (per player)
   * listens - options choice
* Game Session
   * emits - game over, game starts