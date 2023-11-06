# C-2048

Règles du Jeu:

Objectif: Atteindre la tuile 2048 en combinant des tuiles de même valeur.
Défaite: Le jeu se termine lorsqu'il n'y a plus de mouvements possibles et que la grille est pleine sans pouvoir combiner d'autres tuiles.
Victoire: Le joueur gagne si une tuile affichant le nombre 2048 apparaît sur la grille.

Grille:

Structure: La grille de jeu est un carré composé de 4 lignes et 4 colonnes, ce qui donne 16 cases au total.
Initialisation: Au début du jeu, deux cases sont remplies de manière aléatoire par des tuiles de valeur 2 ou 4.

Tuiles:

Apparence: Chaque tuile est représentée par un carré avec un nombre. Les nombres commencent à 2 et doublent à chaque fusion (2, 4, 8, 16, etc.).
Génération: À chaque tour, après un mouvement, une nouvelle tuile apparaît aléatoirement dans une position vide de la grille avec une valeur de 2 ou de 4.
Fusion: Lorsque deux tuiles de même valeur sont combinées, elles fusionnent en une seule tuile avec la somme de ces valeurs.

Mouvements:

Commandes: Le joueur peut glisser les tuiles dans une des quatre directions: haut, bas, gauche, droite.
Déplacement: Lorsqu'une direction est choisie, toutes les tuiles glissent dans cette direction jusqu'à ce qu'elles frappent soit le bord de la grille, soit une autre tuile.
Fusion: Si deux tuiles de même valeur se heurtent lors d'un mouvement, elles fusionnent en une seule tuile de valeur double. Après une fusion, elles ne peuvent plus fusionner avec d'autres tuiles pendant ce mouvement.
Limitation: Une seule fusion par ligne/colonne est autorisée par mouvement.

Score:

Calcul: Le score commence à 0 et augmente chaque fois que deux tuiles fusionnent. La valeur de la nouvelle tuile est ajoutée au score.
Affichage: Le score est généralement affiché en permanence à l'écran pour que le joueur puisse suivre ses progrès.
Objectif: Le score est un indicateur de performance. Atteindre 2048 avec le score le plus élevé possible est l'objectif ultime pour de nombreux joueurs.
