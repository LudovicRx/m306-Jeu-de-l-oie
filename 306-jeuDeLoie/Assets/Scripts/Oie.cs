using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum Attaque
// {
//     Tempete = 0,
//     Foudre = 1,
//     Innodation = 2,
//     Glace = 3

// }

/// <summary>
/// Classe qui gère l'oie
/// </summary>
public class Oie : MonoBehaviour
{
    /// <summary>
    /// Tout les types d'ataque de l'oie
    /// </summary>
    public enum Attaque
    {
        Tempete = 0,
        Foudre = 1,
        Innondation = 2,
        Glace = 3,
        Rien = 4
    }

    /// <summary>
    /// Variable random
    /// </summary>
    /// <returns></returns>
    private static System.Random nombreRandom = new System.Random();

    /// <summary>
    /// Description de l'action de l'oie
    /// </summary>
    public string descriptionAttaque;
    /// <summary>
    /// Attaque utilisée
    /// </summary>
    public Oie.Attaque attaqueUtilise;
    /// <summary>
    /// Joueurs qui ont été échangés
    /// </summary>
    public int[] joueursEchanges = new int[2];

    /// <summary>
    /// Fait jouer l'oie
    /// </summary>
    /// <param name="joueurs">Liste des joueurs du jeu</param>
    public void Jouer(List<Joueur> joueurs)
    {
        // Pour récupérer le nombre de propriétés dans l'enum
        //https://stackoverflow.com/questions/856154/total-number-of-items-defined-in-an-enum
        attaqueUtilise = (Oie.Attaque)nombreRandom.Next(0, Enum.GetNames(typeof(Oie.Attaque)).Length);

        //une chance sur 5 d'attaquer, 4 attaques possibles
        switch (attaqueUtilise)
        {
            case Oie.Attaque.Tempete:
                Tempeter(joueurs);
                descriptionAttaque = $"L'oie fait une tempête et échange {joueurs[joueursEchanges[0]].nom} et {joueurs[joueursEchanges[1]].nom}";
                break;
            case Oie.Attaque.Foudre:
                Fourdroyer();
                descriptionAttaque = "L'oie foudroie le terrain";
                break;
            case Oie.Attaque.Innondation:
                Innonder();
                descriptionAttaque = "L'oie fait innonder le terrain";
                break;
            case Oie.Attaque.Glace:
                Glacer();
                descriptionAttaque = "L'oie a glacé une partie du terrain.";
                break;
            case Oie.Attaque.Rien:
            default:
                descriptionAttaque = "L'oie n'a rien fait";
                break;
        }
    }


    //5 attaques de l'oie
    private void Tempeter(List<Joueur> joueurs)
    {
        //sélectionner au hasard deux joueurs
        int idJoueur1 = 0;
        int idJoueur2 = 0;
        // Sélectionne deux joueurs au hasard
        do
        {
            idJoueur1 = nombreRandom.Next(0, joueurs.Count);
            idJoueur2 = nombreRandom.Next(0, joueurs.Count);
        } while (idJoueur1 == idJoueur2);

        joueursEchanges[0] = idJoueur1;
        joueursEchanges[1] = idJoueur2;

        //échanger leurs positions
        joueurs[idJoueur1].EchangerJoueurs(joueurs[idJoueur2]);
    }
    private void Fourdroyer()
    {
        //chaque case du plateau a une chance sur 3 d'être immobilisée 
        //(le joueur qui est est dessus ne joue pas pendant un tour)

    }
    private void Innonder()
    {
        //chaque joueur a une chance sur deux de reculer de trois case et une chance sure deux d'avancer de trois cases

    }
    private void Glacer()
    {
        //chaque joueur à une chance sur 2 de voir son dé divisé par 2 au prochain tour

    }
}
