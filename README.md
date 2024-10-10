# Backtracking - 8 Queens Problem ♛

##  Overview

The 8 Queens Problem is a classic backtracking problem where the goal is to place 8 queens on an 8x8 chessboard such that no two queens threaten each other. This project implements a console application in C# that allows users to explore different configurations of queens on the board.

Backtracking is a problem-solving technique used in computer science and mathematics for finding solutions to constraint satisfaction problems. It involves incrementally building candidates to a solution and abandoning (backtracking) those candidates as soon as it is determined that they cannot lead to a valid solution.

### Key Characteristics of Backtracking:

1.	Incremental Approach: Backtracking builds candidates for the solution step by step. Each candidate is a partial solution that could potentially lead to a complete solution.
2.	Constraints: The method applies constraints to determine if the current candidate can still lead to a valid solution. If a constraint is violated, the algorithm backtracks to the previous step and tries the next candidate.
3.	Recursive Nature: Backtracking is often implemented using recursion. The function calls itself to explore different possibilities, and if it reaches a dead end, it returns to the previous state (backtracks).
4.	Exploration of All Possible Solutions: It explores all possible configurations for a problem, which is why it’s particularly useful for problems like puzzles, games, and optimization problems.

### Example: The 8 Queens Problem

In the 8 Queens problem, backtracking is used to place queens on a chessboard such that no two queens threaten each other. Here’s how backtracking is applied:

1.	Place a Queen: Start placing queens in the first row, trying different columns.
2.	Check Validity: For each placement, check if it’s valid (i.e., no other queen can attack it).
3.	Recursion: If the placement is valid, recursively try to place the next queen in the next row.
4.	Backtrack: If placing a queen leads to an invalid state later on, backtrack by removing the last placed queen and try the next column.
5.	Solution Found: Continue this process until all queens are placed or all possibilities have been exhausted.

### Advantages of Backtracking:

*	Simplicity: It’s relatively simple to understand and implement, especially for problems that require exploring combinations or permutations.
*	Flexibility: It can be applied to a wide range of problems, such as pathfinding, puzzles, and combinatorial optimization.

## ✨ Features

* Place queens on the board and explore valid configurations.
* View all states of the board during the placement process.
* View all valid solutions where 8 queens are successfully placed.
* Display a summary of the results, including the number of states explored and solutions found.

## 🏁 Getting Started

### Prerequisites

* .NET SDK (version 5.0 or higher) installed on your machine.
* A C# IDE or text editor (e.g., Visual Studio, Visual Studio Code).

### Installation

1.	Clone the repository:
``` bash
git clone https://github.com/yourusername/8Queens.git
cd 8Queens
```
2.	Open the project in your IDE.
3.	Build the project:
``` bash
dotnet build
```
4.	Run the project:
``` bash
dotnet run
```

## ✅ Usage

1.	Launch the application. You will see a menu with the following options:
* 1 Colocar Reinas: Place queens on the board and explore states.
*	2 Mostrar Todos los tableros de soluciones: View all solutions found.
*	3 Mostrar Todos los tableros de estados: View all states explored during the process.
*	4 Mostrar Resumen de resultados: Display a summary of results including the number of states and solutions.
*	0 Salir: Exit the application.
2.	Select an option by entering the corresponding number.
3.	Follow the prompts to interact with the application.

## 🏛️ Code Structure

* Tablero Class: The main class responsible for the game logic, including initializing the board, placing queens, checking valid positions, and displaying results.
* Menu Method: Manages user input and navigates through the different functionalities of the application.
* Display Methods: Methods to show the board’s current state and solutions.

## 💡 Contributing

Contributions are welcome! If you have suggestions or improvements, please fork the repository and submit a pull request.
