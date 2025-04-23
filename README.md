> 📘 Ce projet existe aussi en français : [Lire en français 🇫🇷](./README_FR.md)

# 🦖 DinoRush – 3D Platformer Prototype

**DinoRush** is a 3D platformer prototype inspired by *Crash Bandicoot*, made in Unity.

The player controls a small dinosaur who must collect all coins while avoiding falling into the water.  
The game is focused entirely on **jumping precision**, **collection**, and **risk management**.

Developed as a collaborative project, DinoRush features a full game structure: menus, dynamic audio via Wwise, checkpoint system, limited lives, and UI feedback.

---

## 🎮 Key Features

- ✅ Modular player controller (movement, rotation, audio, animation)
- ✅ Refactored camera system (rotation, follow, clamp angles)
- ✅ 3D movement and jump with physics & custom gravity
- ✅ Checkpoint system (with respawn)
- ✅ Game Over after a limited number of lives
- ✅ Spark particle system on coin pickup (with burst + timed stop)
- ✅ Fully functional pause and game over menus
- ✅ Main menu with scene transition
- ✅ In-game UI (life counter, coin tracker)
- ✅ Buttons with sound feedback on hover/click (via Wwise)
- ✅ Scene management system
- ✅ Clean build ready for Windows
- ✅ Fully versioned with Git

---

## 🧱 Technologies Used

| Component               | Description                                      |
|-------------------------|--------------------------------------------------|
| 🎮 Unity 2020+          | Game engine                                      |
| 💻 C#                   | Core gameplay, modular architecture              |
| 🎧 Wwise                | Audio middleware (feedback, music, states)       |
| 🧩 Unity UI             | Menus, scene transitions, UI integration         |
| 🕹️ CharacterController | Custom 3D movement & collision handling           |
| 🔁 Animator             | Full state machine for jump / idle / run         |
| ✨ Particles             | Coin sparkle system with burst + auto stop       |

---

## 👥 Development Team

Collaborative project developed by:

- **Jean Deck** – Gameplay programming, UI scripting, modular architecture  
  [https://www.linkedin.com/in/jean-deck-2b915aa9/](https://www.linkedin.com/in/jean-deck-2b915aa9/)

- **Lauren Allard** – UI/UX design & full Unity UI integration (linked UI design with scripts)  
  [https://www.linkedin.com/in/lauren-allard/](https://www.linkedin.com/in/lauren-allard/)

- **Benoît Rivière** – Level design, 3D modeling, animations  
  [https://www.linkedin.com/in/rivi%C3%A8rebeno%C3%AEt/](https://www.linkedin.com/in/rivi%C3%A8rebeno%C3%AA/)

- **Song Xue** – 3D modeling  
  [https://www.linkedin.com/in/songxue1997/](https://www.linkedin.com/in/songxue1997/)

- **Benjamin Cicéron** – Sound design, Wwise integration  
  [https://www.linkedin.com/in/benjamin-ciceron/](https://www.linkedin.com/in/benjamin-ciceron/)

---

## 📦 Final Build

- Platform: Windows x86_64
- Download: Available in the [Releases section](https://github.com/Kisahn/DinoRush/releases)
- Controls:
  - ZQSD to move
  - Space to jump
  - ESC to pause
- Notes:
  - Audio middleware requires Wwise runtime (already integrated in build)
  - The game is standalone and does not require Unity Services

---

## 🧪 Learning Objectives

- Build a modular game structure with Unity & C#
- Integrate Wwise for dynamic, event-driven sound
- Design and link UI systems (visual + logic)
- Handle checkpoints, respawn logic and Game Over
- Refactor monolithic systems into clean components
- Collaborate in a multi-role project team with real production flow

---

## 📜 License

This project is released under the [CC BY-NC 4.0 License](https://creativecommons.org/licenses/by-nc/4.0/).  
See the [`LICENSE`](./LICENSE) file for full terms.

> ⚠️ Audio, visual, and animation assets are **not reusable** without explicit permission.