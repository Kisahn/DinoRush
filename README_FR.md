> 📘 This project is also available in English: [Read in English 🇬🇧](./README.md)

# 🦖 DinoRush – Prototype de jeu de plateforme 3D

**DinoRush** est un prototype de jeu de plateforme 3D inspiré par *Crash Bandicoot*, développé avec Unity.

Le joueur incarne un petit dinosaure qui doit collecter toutes les pièces tout en évitant de tomber dans l’eau.  
Le gameplay repose entièrement sur la **précision des sauts**, la **collecte d’objets** et la **gestion du risque**.

Développé en collaboration, DinoRush propose une structure de jeu complète : menus, audio dynamique via Wwise, système de checkpoints, vies limitées, et retours visuels et sonores à l’écran.

---

## 🎮 Fonctionnalités principales (v1.0.0 – Release finale)

- ✅ Contrôleur joueur modulaire (mouvement, rotation, audio, animation)
- ✅ Caméra refactorisée (rotation, suivi, angles limités)
- ✅ Déplacement 3D et saut avec gravité personnalisée
- ✅ Système de checkpoints avec réapparition
- ✅ Game Over après perte de toutes les vies
- ✅ Effet de particules visuel lors de la collecte des pièces (burst + disparition automatique)
- ✅ Menus fonctionnels (pause, game over)
- ✅ Menu principal avec chargement de scène
- ✅ UI en jeu (compteur de vies, pièces)
- ✅ Boutons avec retour sonore (hover/clic via Wwise)
- ✅ Système de gestion de scènes
- ✅ Build propre pour Windows
- ✅ Versionné proprement avec Git

---

## 🧱 Technologies utilisées

| Composant               | Description                                      |
|-------------------------|--------------------------------------------------|
| 🎮 Unity 2020+          | Moteur de jeu                                    |
| 💻 C#                   | Langage principal, architecture modulaire        |
| 🎧 Wwise                | Middleware audio (feedback, musique, états)      |
| 🧩 Unity UI             | Menus, transitions, intégration des interfaces   |
| 🕹️ CharacterController | Déplacement 3D personnalisé avec collisions      |
| 🔁 Animator             | Machine d’états complète (saut, idle, course)    |
| ✨ Particules            | Effet Spark sur les pièces, burst et auto-stop   |

---

## 👥 Équipe de développement

Projet réalisé en collaboration par :

- **Jean Deck** – Programmation gameplay, scripts UI, architecture modulaire  
  [https://www.linkedin.com/in/jean-deck-2b915aa9/](https://www.linkedin.com/in/jean-deck-2b915aa9/)

- **Lauren Allard** – Design UI/UX & intégration complète des interfaces dans Unity (liaison design/scripts)  
  [https://www.linkedin.com/in/lauren-allard/](https://www.linkedin.com/in/lauren-allard/)

- **Benoît Rivière** – Level design, modélisation 3D, animations  
  [https://www.linkedin.com/in/rivi%C3%A8rebeno%C3%AEt/](https://www.linkedin.com/in/rivi%C3%A8rebeno%C3%AEt/)

- **Song Xue** – Modélisation 3D  
  [https://www.linkedin.com/in/songxue1997/](https://www.linkedin.com/in/songxue1997/)

- **Benjamin Cicéron** – Sound design, intégration Wwise  
  [https://www.linkedin.com/in/benjamin-ciceron/](https://www.linkedin.com/in/benjamin-ciceron/)

---

## 📦 Build final

- Plateforme : Windows x86_64
- Téléchargement : disponible dans la section [Releases](https://github.com/Kisahn/DinoRush/releases)
- Contrôles :
  - ZQSD : déplacement
  - Espace : saut
  - Échap : pause
- Remarques :
  - L’audio fonctionne via le runtime Wwise (déjà intégré au build)
  - Le jeu est autonome, aucun service Unity requis

---

## 🧪 Objectifs pédagogiques

- Concevoir une architecture modulaire avec Unity & C#
- Intégrer Wwise pour des sons dynamiques déclenchés par événements
- Créer et lier des interfaces utilisateur visuelles et fonctionnelles
- Gérer des checkpoints, réapparitions et Game Over
- Refactoriser du code monolithique en composants maintenables
- Travailler en équipe multi-rôles avec un workflow de production structuré

---

## 📜 Licence

Ce projet est publié sous licence [CC BY-NC 4.0](https://creativecommons.org/licenses/by-nc/4.0/).  
Voir le fichier [`LICENSE`](./LICENSE) pour les conditions complètes.

> ⚠️ Les assets audio, visuels et animations ne sont **pas réutilisables** sans autorisation explicite.
