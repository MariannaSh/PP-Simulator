# Simulator "SimWeb"

This project is a web application for simulating a game where orcs and elves battle, and birds and animals move according to predefined steps in the code. The simulation is built using object-oriented programming (OOP) principles in C# and Razor Pages, and was implemented as part of a university programming course. The simulation takes place on a toroidal map where the entities move according to a sequence of commands that is predefined in the code.

## Project Description

The project consists of the following components:

- **SimConsole**: A console application for running simulations and logging data.
- **Simulator**: The core simulation logic, including object creation (such as orcs, elves, birds, and animals) and movement handling.
- **SimWeb**: A web application for visualizing the simulation, displaying the entities on the map, and showing the current round and movement sequence.
- **TestSimulator**: A set of unit tests for verifying the correct operation of the simulator.

## Project Structure

### 1. **SimConsole**
This project is a console application used for interacting with the simulation.

- **Box.cs** — Class for describing rectangular objects.
- **LogVisualizer.cs** — Log visualizer.
- **MapVisualizer.cs** — Map visualizer.
- **Program.cs** — Main program file.

### 2. **Simulator**
The core part of the project that contains the simulation logic.

- **Animals.cs** — Abstraction for animals.
- **Birds.cs** — Classes for birds.
- **Creature.cs** — Class for creating creatures.
- **Direction.cs** — Description of directions.
- **DirectionParser.cs** — Direction parser for processing movements.
- **Elf.cs** — Class for elves.
- **Orc.cs** — Class for orcs.
- **Point.cs** — Represents a point on the map.
- **Rectangle.cs** — Rectangle class for boundary detection.
- **Simulation.cs** — Main simulation class.
- **SimulationHistory.cs** — Tracks the history of the simulation.
- **SimulationTurnLog.cs** — Log for each turn in the simulation.
- **Validator.cs** — Data validation utility.

### 3. **SimWeb**
A web application used to visualize the simulation data.

- **App.cs** — Main class for the web application.
- **Program.cs** — Main program file for the web application.
- **Pages** — Folder containing web pages.
- **wwwroot** — Static files (CSS, JS).

### 4. **TestSimulator**
A module for testing various components of the simulator.

- **DirectionParserTests.cs** — Tests for the direction parser.
- **PointTests.cs** — Tests for point-related logic.
- **RectangleTests.cs** — Tests for rectangle-related logic.
- **SmallTorusMapTests.cs** — Tests for the toroidal map.
- **ValidatorTests.cs** — Tests for data validation.

## SimWeb Web Application

The web application demonstrates the simulation where orcs, elves, birds, and other creatures move on a toroidal map. The map is a grid, and each entity moves according to a predefined sequence of commands. The web interface displays the following:

- **Current Round**: The number of the current round in the simulation.
- **Map**: The grid on which entities are placed.
- **Movement Sequence**: A sequence of commands for the entities, such as "dlrdrul..." indicating the directions to follow (down, left, right, up, etc.).

### Example Screens
![Снимок экрана 2025-02-12 220027](https://github.com/user-attachments/assets/cd4a3570-cc70-4f0b-9538-3f1f75c038dd)
- The first screen displays information about the simulation, the current map type (torus), and the sequence of movements.

![Снимок экрана 2025-02-12 220011](https://github.com/user-attachments/assets/2900bcf0-eebe-4a6a-91c3-8762b0069493)
- The second screen shows the map with various creatures (animals, orcs, elves) and their positions after a set of movements.

### Controls
- **Left/Right Arrows**: Navigate through the rounds of the simulation.
- **Movement Sequence**: Edit or input commands for the entities in the simulation.

## Installation and Setup

To run the project, follow the steps below to set up the environment:

### 1. Clone the repository

```bash
https://github.com/MariannaSh/PP-Simulator.git
```

### 2. Install dependencies

Run the following command to restore the required dependencies:

```bash
dotnet restore
```

### 3. Running the Application

To run the console application:

```bash
dotnet run --project SimConsole
```

To run the web application:

```bash
dotnet run --project SimWeb
```

## Testing

To run the tests for verifying the components, use the following command:

```bash
dotnet test TestSimulator
```

## Acknowledgments

This project was created as part of a university programming course. Special thanks to the course instructor for invaluable support and guidance.

