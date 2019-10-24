
- Text parser
  - GO NORTH / NORTH / N
  - PICK UP THE BOOK -> PICKUP BOOK -> GET BOOK -> RETRIEVE BOOK
  - [COMMAND] + [OBJECT]
  - TALK TO BOB -> TALK BOB

- Rooms
  - ID
  - Description
  - Exits (NSEWUD)
    - Locked

- Item/Inventory
  - Pick up an item
  - ID
  - Description

- Event manager / Game Master
  - SOMETHING happened -> does something else need to happen?
  - Walk into room X while holding book, Bob yells at you to stop reading
  - `UNLOCK DOOR` while holding key, 
  - What important things have happened? (Flag)
    - Turned on the stove

- Save/Load
  - dump the current game state
  - don't care about security
  - Begin display summary of the story
  
