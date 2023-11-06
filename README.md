# C-2048

R�gles du Jeu:

Objectif: Atteindre la tuile 2048 en combinant des tuiles de m�me valeur.
D�faite: Le jeu se termine lorsqu'il n'y a plus de mouvements possibles et que la grille est pleine sans pouvoir combiner d'autres tuiles.
Victoire: Le joueur gagne si une tuile affichant le nombre 2048 appara�t sur la grille.

Grille:

Structure: La grille de jeu est un carr� compos� de 4 lignes et 4 colonnes, ce qui donne 16 cases au total.
Initialisation: Au d�but du jeu, deux cases sont remplies de mani�re al�atoire par des tuiles de valeur 2 ou 4.

Tuiles:

Apparence: Chaque tuile est repr�sent�e par un carr� avec un nombre. Les nombres commencent � 2 et doublent � chaque fusion (2, 4, 8, 16, etc.).
G�n�ration: � chaque tour, apr�s un mouvement, une nouvelle tuile appara�t al�atoirement dans une position vide de la grille avec une valeur de 2 ou de 4.
Fusion: Lorsque deux tuiles de m�me valeur sont combin�es, elles fusionnent en une seule tuile avec la somme de ces valeurs.

Mouvements:

Commandes: Le joueur peut glisser les tuiles dans une des quatre directions: haut, bas, gauche, droite.
D�placement: Lorsqu'une direction est choisie, toutes les tuiles glissent dans cette direction jusqu'� ce qu'elles frappent soit le bord de la grille, soit une autre tuile.
Fusion: Si deux tuiles de m�me valeur se heurtent lors d'un mouvement, elles fusionnent en une seule tuile de valeur double. Apr�s une fusion, elles ne peuvent plus fusionner avec d'autres tuiles pendant ce mouvement.
Limitation: Une seule fusion par ligne/colonne est autoris�e par mouvement.

Score:

Calcul: Le score commence � 0 et augmente chaque fois que deux tuiles fusionnent. La valeur de la nouvelle tuile est ajout�e au score.
Affichage: Le score est g�n�ralement affich� en permanence � l'�cran pour que le joueur puisse suivre ses progr�s.
Objectif: Le score est un indicateur de performance. Atteindre 2048 avec le score le plus �lev� possible est l'objectif ultime pour de nombreux joueurs.
