# ⚔️ Mystic Creatures — TCP Client/Server Game

A multi-client TCP/IP game application built on a C# (.NET Windows Forms) Client/Server architecture with SQL Server data persistence.

The system features centralized server administration and real-time socket communication for acquiring creatures, building custom battle teams, and conducting turn-based battles between players.

---

## 🛠️ Tech Stack & Prerequisites

- **Language:** C# / .NET
- **UI Framework:** Windows Forms (WinForms)
- **Networking:** Asynchronous TCP Sockets (`System.Net.Sockets`)
- **Database:** Microsoft SQL Server
- **Architecture:** Client/Server Model

---

## 🚀 Key Features

### 🖥️ Server Application (`Proyecto2PrograAvanzadaServidor`)
- **Centralized Listener:** Listens on a dedicated TCP port for incoming client connections.
- **SQL Server Integration:** Manages database connection strings, player accounts, creature inventories, and match histories.
- **Real-Time Log & Dashboard:** Displays active socket connections, server events, and transaction history.

### 🎮 Client Application (`proyecto2prograAvanzadaClienteTCP`)
- **TCP Socket Client:** Connects to the server host IP and designated port.
- **Creature Acquisition & Trading:** Allows players to obtain new creatures and construct battle teams.
- **Turn-Based Battles:** Enables real-time strategic battles between connected client instances.

---

## 📄 Documentation

You can view the full project user manual and technical documentation here:
- [📘 Download/View User Manual (PDF)](./docs/Mystic-Creatures-Client-Server-Game-ManualP2.pdf)

## ⚙️ Getting Started

1. Clone the repository:
   ```bash
   git clone [https://github.com/Silesafa/Mystic-Creatures-Client-Server-Game.git](https://github.com/Silesafa/Mystic-Creatures-Client-Server-Game.git)
