# ⚔️ Mystic Creatures — TCP Client/Server Game
 
A multi-client TCP/IP game application built on a **C# (.NET Windows Forms) Client/Server architecture** with **SQL Server** data persistence.
 
The system features centralized server administration and real-time socket communication for acquiring creatures, building custom battle teams, and conducting turn-based battles between players.

---

## 🛠️ Tech Stack & Prerequisites

- **Language:** C# / .NET
- **UI Framework:** Windows Forms (WinForms)
- **Networking:** Asynchronous TCP Sockets (`System.Net.Sockets`)
- **Database:** Microsoft SQL Server (ADO.NET)
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

### 🗄️ Database Integration
 
The application uses Microsoft SQL Server as its primary data storage layer.
 
The server application communicates directly with the database through ADO.NET to manage:
 
- Player accounts
- Creatures
- Teams
- Battle history
- Match statistics
- Inventory records
 
All connected clients interact with the database through the centralized TCP server, ensuring consistency and validation of game data.

---

🗄️ Database Design
Database: SQL Server
Data Access: ADO.NET
Relational Database Model
Foreign Key Constraints
Data Integrity Rules
Battle History Persistence
Inventory Management
Team Management

---

## Database Setup
 
The project includes a complete SQL Server database creation script.
 
📁 Location:
 
database/BATALLAS.sql
 
The script creates:
 
- Players
- Creatures
- Inventories
- Teams
- Battles
- Rounds
- Relationships
- Constraints

---

## 🎯 Skills Demonstrated
 
- TCP/IP Socket Programming
- Client-Server Architecture
- SQL Server Database Design
- ADO.NET Data Access
- Windows Forms Development
- Multithreading
- Object-Oriented Programming (OOP)
- Data Validation
- Real-Time Communication
- Software Documentation

  ---

## 📄 Documentation

You can view the full project user manual and technical documentation here:
- [📘 Download/View User Manual (PDF)](./docs/Mystic-Creatures-Client-Server-Game-ManualP2.pdf)

## ⚙️ Getting Started

1. Clone the repository:
   ```bash
   git clone [https://github.com/Silesafa/Mystic-Creatures-Client-Server-Game.git](https://github.com/Silesafa/Mystic-Creatures-Client-Server-Game.git)

## 🏗️ System Architecture
 
```text
+----------------------+
| Windows Client |
+----------------------+
|
|
TCP/IP
|
▼
+----------------------+
| TCP Server |
+----------------------+
|
|
ADO.NET
|
▼
+----------------------+
| SQL Server |
+----------------------+

```

## 🗄️ Database Model
 
```text
Jugadores
│
▼
InventarioJugador
│
▼
Equipo
│
▼
Batalla
│
▼
Rondas
 
TiendaCriaturas
│
└──────────────► InventarioJugador
```




