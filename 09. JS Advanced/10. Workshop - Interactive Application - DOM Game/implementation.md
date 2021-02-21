# DOM (Dungeon Object Model) Game

## General Rules
* Turn based
* Every actor takes a turn in order
* Player always acts first
* Every turn allows one action (attack, spell, defend)
* Item use doesn't count as an action
* Loot, equipment and skill points accessible only outside of encounter

## Implementaion Order

1. Character
1. Enemy
1. Fight one enemy
1. Fight multiple enemies -> targeting
1. Generate game world
1. Traverse game world
1. Enemy encounters -> game state
1. Leveling
1. Loot
1. Equipment
