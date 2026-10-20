# Unit spawning lesson

This Unity lesson adds UnitData assets, runtime UnitComponent state, and a UnitSpawner.

## Setup

1. Create WarriorData and MageData through `Create > Dragoncraft > New Unit`.
2. Assign each data asset its matching Prefab and select its UnitType.
3. Add UnitComponent to the root of both unit Prefabs.
4. Create WarriorSpawn and MageSpawn empty GameObjects in Level01.
5. Add UnitSpawner to a manager GameObject and assign both data assets and both spawn Transforms.
6. Enter Play mode. The expected result is one Warrior and one Mage at the assigned positions.
