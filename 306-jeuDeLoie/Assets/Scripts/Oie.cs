using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe qui gère l'oie
/// </summary>
public class Oie : MonoBehaviour
{
    // Constantes
    /// <summary>
    /// Nombre de joueurs afectés pour la tempete
    /// </summary>
    public static readonly int NB_JOUEURS_TEMPETE = 2;

    /// <summary>
    /// Nombre de case duquel on avance ou on recule lors de l'innondation
    /// </summary>
    private static readonly int NB_CASE_INNONDATION = 3;

    /// <summary>
    /// Valeur maximum pour un tirage aléatoire sur deux
    /// </summary>
    private static readonly int MAX_ALEATOIRE = 100;
    /// <summary>
    /// Valeur qui détermine pour un tirage aléatoire sur 2 le seuil
    /// </summary>
    private static readonly int SEUIL_ALEATOIRE = 50;

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

    // Champs
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
    public List<int> joueursAffectes = new List<int>();

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
                descriptionAttaque = $"L'oie fait une tempête et échange {joueurs[joueursAffectes[0]].nom} et {joueurs[joueursAffectes[1]].nom}";
                break;
            case Oie.Attaque.Foudre:
                Fourdroyer();
                descriptionAttaque = "L'oie foudroie le terrain";
                break;
            case Oie.Attaque.Innondation:
                bool[] resultat = Innonder(joueurs);
                descriptionAttaque = "L'oie fait innonder le terrain.";
                for (int i = 0; i < joueurs.Count; i++)
                {
                    descriptionAttaque += $"\n{joueurs[i].nom} a ";
                    if (resultat[i])
                    {
                        descriptionAttaque += $"avancé ";
                    }
                    else
                    {
                        descriptionAttaque += $"reculé ";
                    }
                    descriptionAttaque += $"de {NB_CASE_INNONDATION} cases.";
                }
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
    /// <summary>
    /// Fait la tempête de l'oie, échange deux joueurs aléatoirement
    /// </summary>
    /// <param name="joueurs">List de tout les joueurs</param>
    private void Tempeter(List<Joueur> joueurs)
    {
        do
        {
            joueursAffectes.Clear();
            for (int i = 0; i < NB_JOUEURS_TEMPETE; i++)
            {
                joueursAffectes.Add(nombreRandom.Next(0, joueurs.Count));
            }
        } while (joueursAffectes[0] == joueursAffectes[1]);


        // Echanger leurs positions
        joueurs[joueursAffectes[0]].EchangerJoueurs(joueurs[joueursAffectes[1]]);
    }

    private void Fourdroyer()
    {
        //chaque case du plateau a une chance sur 3 d'être immobilisée 
        //(le joueur qui est est dessus ne joue pas pendant un tour)

    }

    /// <summary>
    /// Fait innonder le terraine
    /// Chaque joueur a une chance sur deux de reculer de trois case et une chance sur deux d'avancer de trois cases
    /// </summary>
    /// <param name="joueurs">Liste des joueurs</param>
    /// <returns>Retourne qui a avancer (true) et qui a reculer (false)</returns>
    private bool[] Innonder(List<Joueur> joueurs)
    {
        bool[] resultatJoueurs = new bool[joueurs.Count];
        for (int i = 0; i < joueurs.Count; i++)
        {
            int deplacement = NB_CASE_INNONDATION;
            resultatJoueurs[i] = true;
            if (nombreRandom.Next(MAX_ALEATOIRE) >= SEUIL_ALEATOIRE)
            {
                resultatJoueurs[i] = false;
                deplacement = -deplacement;
            }
            joueurs[i].SeDeplacer(deplacement);
        }
        return resultatJoueurs;

    }
    private void Glacer()
    {
        //chaque joueur à une chance sur 2 de voir son dé divisé par 2 au prochain tour

    }
}
