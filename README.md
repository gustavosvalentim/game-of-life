# 🧬 Conway's Game of Life – WPF Edition (.NET 8)

This is a simple, interactive implementation of **Conway's Game of Life** built with **WPF** and **.NET 8**. It allows you to visualize and control the simulation of cellular automata with customizable speed and population density.

---

## 🧠 About Conway's Game of Life

Conway's Game of Life is a **cellular automaton** devised by mathematician John Conway. The game simulates life and death on a grid of cells, following simple rules:

1. Any live cell with **fewer than 2** live neighbors dies (underpopulation).
2. Any live cell with **2 or 3** live neighbors lives on.
3. Any live cell with **more than 3** live neighbors dies (overpopulation).
4. Any dead cell with **exactly 3** live neighbors becomes alive (reproduction).

---

## 🖥️ UI Overview

| Element         | Description                                                 |
|-----------------|-------------------------------------------------------------|
| **Render**      | Steps forward by one generation                             |
| **Start**       | Begins auto-playing the simulation                          |
| **Stop**        | Stops the simulation                                        |
| **Reset**       | Clears and re-initializes the board                         |
| **Live Density**| Sets initial life density (0–100%)                          |
| **FPS**         | Frames per second when running (e.g., 10 = 10 generations/s)|

---

## 📦 Technologies Used

- **.NET 8**
- **WPF (Windows Presentation Foundation)**
- C# with MVVM-friendly design
- XAML-based UI

---

## 🛠️ Build & Run

1. Clone the repository:
```bash
git clone https://github.com/gustavosvalentim/game-of-life.git
```

2. Navigate to the project folder:

```bash
cd game-of-life
```

3. Build and run the application:

```bash
dotnet build
dotnet run
```

> Make sure you have the [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installed.

---

## 📝 License

This project is licensed under the [MIT License](LICENSE).

---

## 🤝 Contributions

Pull requests, feature suggestions, and improvements are welcome!
