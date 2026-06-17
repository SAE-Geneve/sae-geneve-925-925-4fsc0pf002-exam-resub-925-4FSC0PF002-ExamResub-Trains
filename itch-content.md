# Aiguillages — Train Dispatch · Contenu itch.io

> Énoncé d'examen Unity (module 4FSC0PF002) — SAE Institute Genève.
> Démonstrateur pédagogique · Prototype.

---

## Titre

**Aiguillages — Train Dispatch (Énoncé d'examen SAE)**

Variantes plus courtes pour le listing : *Aiguillages — Démonstrateur SAE* · *Aiguillages*

---

## Tagline (short description)

> Énoncé d'examen Unity (SAE Genève) · Démonstrateur pédagogique. Cliquez les drapeaux bleus pour guider le train à travers les stations avant la fin du chrono.

---

## Description complète

⚠️ **Énoncé d'examen — démonstrateur pédagogique (prototype)**
Ce projet est le **support d'examen du module Unity 4FSC0PF002 à la SAE Institute Genève**. Il sert de **démonstrateur pédagogique** : une base de travail à compléter par les étudiants (gestion des signaux, chronomètre, score, HUD). Il s'agit d'un **prototype**, pas d'un jeu fini — l'objectif est l'apprentissage et l'évaluation, pas la rejouabilité.

---

**Le jeu**
**Aiguillages** est un petit jeu de gestion ferroviaire. Un train parcourt le réseau en continu : à vous de tracer sa route en temps réel pour qu'il enchaîne le plus de passages en station possible avant la fin du chronomètre.

**Comment jouer**
Toute l'interaction se fait en **cliquant sur les drapeaux bleus** présents dans la scène :
- 🚩 Cliquez le **drapeau bleu d'un aiguillage** pour basculer sa sortie active (indiquée dans la scène).
- 🚩 Cliquez le **drapeau bleu d'un signal** pour arrêter ou relâcher le train ; le train ralentit progressivement et s'arrête au niveau du drapeau.
- 🏁 Faites passer le train en **station** pour marquer des points.
- ⏱️ Tenez jusqu'à la fin du **chronomètre**.

**Interface (HUD)**
- ▶️ Démarrer · ⏸️ Pause · ⏩ Vitesse ×2
- Affichage du chronomètre et du score en temps réel.

**Sous le capot**
Le déplacement des trains repose sur le système **Splines** d'Unity : un *SplineContainer* définit chaque tronçon de voie, et *SplineAnimate* déplace le train le long du chemin. Les tronçons s'enchaînent dynamiquement au passage des aiguillages.

🎮 Jouable directement dans le navigateur (WebGL). Aucune installation requise.

*Projet réalisé avec Unity — SAE Institute Genève, section Programmation de jeux.*

---

## Réglages du formulaire itch.io

| Champ | Valeur |
| --- | --- |
| Classification | Game |
| Kind of project | HTML — cocher « This file will be played in the browser » |
| Genre | Simulation (ajouter *Educational* pour signaler le caractère pédagogique) |
| Release status | **Prototype** |
| Pricing | No payments (gratuit) |
| Embed (WebGL) | ~960×600, « Click to launch in fullscreen » activé |

**Tags :** `unity` · `webgl` · `educational` · `prototype` · `trains` · `simulation` · `management` · `splines` · `sae` · `singleplayer` · `browser`

---

## Cover & captures

- **Cover :** 630×500 px. Train en contre-plongée passant devant un drapeau bleu, ambiance action + bucolique. Une bannière « Énoncé d'examen / Prototype pédagogique » aide à cadrer les attentes dès la vignette.
- **Captures suggérées :** train approchant d'un drapeau bleu ; aiguillage avec sa sortie active visible ; vue large du réseau avec le HUD (score + chrono).
