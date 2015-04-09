These classes are mean to mock up a prototype arrangement for a simple squad based game scneario where
the first player creating the game session is the "Creator Side" and the next player to come in is the
"Joiner Side" of the scenario.

Maybe if other player join they will be Observers.

As soon as the 2nd player logs in, the game session starts.

It is expected the game runner will:
 - own a PlayerManager instance
 - create a ProtoGameSession with a ProtoWorld when two player log in
   - alternate turns based on game events
   - wrap up the game session when that game event comes in
 - fake the handling of post game sessions
   - report results
   - kick players out so a new game session can start

 