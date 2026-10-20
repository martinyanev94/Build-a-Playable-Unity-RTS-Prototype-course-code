# Build a Playable Unity RTS Prototype: Final Project

## Project portfolio

### RTS Game Design Document

A small village must expand, gather resources, train units, explore, and survive hostile creatures.

Deliverable: A scoped design document with mechanics, entities, maps, objectives, and outcomes.

### Unity RTS Project Foundation

Start a clean Unity workspace for incremental RTS development.

Deliverable: Organized Unity project and runnable Playground scene.

### Prefab-Based RTS Map Layout

Assemble a readable village map from reusable world assets.

Deliverable: Playable map layout with reusable grouped sections.

### Data-Driven Map Configuration

Move map layout decisions from scene editing into reusable assets.

Deliverable: ScriptableObject assets describing map settings and placements.

### Unity Map Generation Editor

Reduce repetitive map construction through an editor workflow.

Deliverable: Editor-assisted map generator driven by LevelData.

### Bounded RTS Camera Controller

Let players inspect the map without leaving the playable area.

Deliverable: Configurable pan and zoom camera with limits.

### Responsive RTS HUD and Command UI

Give players the information needed to make timely decisions.

Deliverable: Responsive HUD with dynamic resources, selection data, and actions.

### RTS Minimap Rendering

Provide a compact overview of the battlefield.

Deliverable: Bounded minimap rendered through a second camera.

### Additively Loaded UI Scene

Keep interface content independent from gameplay maps.

Deliverable: Gameplay and UI scenes loaded together without duplicates.

### Pooled Combat Unit Spawner

Create armies efficiently during repeated gameplay events.

Deliverable: Configured unit spawner backed by an object pool.

### Message-Driven Unit UI Updates

Keep unit systems and UI connected without hard coupling.

Deliverable: Message queue that updates unit-facing UI safely.

### Editor Debugging Tool for Units

Shorten troubleshooting cycles during unit development.

Deliverable: Editor tool for inspecting and safely manipulating unit state.

### Army Selection and Movement

Command one or more units across the map.

Deliverable: Selection and movement command workflow.

### Unit Attack and Defense System

Make player units engage threats with melee and ranged attacks.

Deliverable: Combat units with selection details, damage, defense, and Mage ranged attacks.

### NavMesh-Based Unit Pathfinder

Move units through an obstacle-filled battlefield.

Deliverable: NavMesh movement with diagnostic support.

### Enemy Configuration, Spawning, and Damage Feedback

Populate the battlefield with configured hostile units.

Deliverable: Enemy spawn system with visible damage feedback.

### Enemy Attack and Chase AI

Make enemies pursue and attack player units, then leave combat cleanly.

Deliverable: Enemy chase, attack, damage, and life-cycle behavior.

### Enemy Map Placement, Fog, and Patrols

Turn exploration into a meaningful risk through hidden areas and patrols.

Deliverable: Configured spawn points, exploration fog, and patrol behavior.

### Automated Battle Simulation and Difficulty Balancing

Use deterministic combat tests to tune a fair challenge.

Deliverable: Battle simulations and a tested balance baseline.

### Resource Gathering and Resource Tests

Fund expansion by gathering and delivering resources.

Deliverable: Gathering system with focused automated tests.

### Unit Training and Defense Towers

Convert resources into new units and protect the village perimeter.

Deliverable: Training building and ranged defense tower.

### Objectives, Progression, and Win/Lose States

Turn the prototype's systems into a complete playable scenario.

Deliverable: Objective tracker with demonstrable victory and defeat states.

### Desktop Export and Build System

Deliver the prototype outside the Unity editor.

Deliverable: Repeatable desktop build workflow and playable executable.

### RTS Expansion Roadmap

Identify structured directions for extending the completed RTS with additional content and gameplay capabilities.

Deliverable: Identify structured directions for extending the completed RTS with additional content and gameplay capabilities.

## Requirements

Configure and launch one desktop release build. Guard Editor-only scripts, include Level01 first and GameUI second, keep Playground out of the release input, build into the project-root Builds folder, and document the artifact path and observed outcome presentation.

Expected outcome: A desktop executable or application bundle launches the completed RTS with its HUD visible and reaches the existing victory or defeat presentation.

## Completion checklist

- [ ] Editor-only scripts are excluded from desktop compilation.
- [ ] Release scenes contain Level01 first and GameUI second.
- [ ] The build artifact is written outside Assets in Builds.
- [ ] The generated player launches without a missing-scene failure.
- [ ] The HUD and an existing win or lose presentation are observable.
## Run and verify

Follow the repository `README.md` to install dependencies and run the
project. Complete the checklist above, then run the included tests or
verification command before considering the project finished.
