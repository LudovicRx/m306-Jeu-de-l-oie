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
    /// Diviseur du dé quand un joueur se fait glacer
    /// </summary>
    public static readonly int GLACE_DIVISEUR = 2;

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
    /// Fait jouer l'oie
    /// </summary>
    /// <param name="joueurs">Liste des joueurs du jeu</param>
    public void Jouer(List<Joueur> joueurs)
    {
        // Pour récupérer le nombre de propriétés dans l'enum
        // https://stackoverflow.com/questions/856154/total-number-of-items-defined-in-an-enum
        attaqueUtilise = (Oie.Attaque)nombreRandom.Next(0, Enum.GetNames(typeof(Oie.Attaque)).Length);
        joueurs = Joueur.ResetAttaque(joueurs);

        // Une chance sur 5 d'attaquer, 4 attaques possibles
        switch (attaqueUtilise)
        {
            case Oie.Attaque.Tempete:
                Tempeter(joueurs);
                descriptionAttaque = EcrireTexteTempete(joueurs);
                break;
            case Oie.Attaque.Foudre:
                Foudroyer(joueurs);
                descriptionAttaque = EcrireTexteFoudre(joueurs);
                break;
            case Oie.Attaque.Innondation:
                Innonder(joueurs);
                descriptionAttaque = EcrireTexteInnondation(joueurs);
                break;
            case Oie.Attaque.Glace:
                Glacer(joueurs);
                descriptionAttaque = EcrireTexteGlace(joueurs);
                break;
            case Oie.Attaque.Rien:
            default:
                descriptionAttaque = EcrireTexteDefaut();
                break;
        }
    }

    /// <summary>
    /// Ecrit le message par défaut
    /// </summary>
    /// <returns>Message par défaut</returns>
    private string EcrireTexteDefaut()
    {
        return "L'oie n'a rien fait";
    }

    /// <summary>
    /// Ecrit le texte pour l'attaque glace
    /// </summary>
    /// <param name="joueurs">Liste des joueurs</param>
    /// <returns>Résultat sous forme d'un texte</returns>
    private string EcrireTexteGlace(List<Joueur> joueurs)
    {
        string texteGlace = "";
        texteGlace += "L'oie a glacé une partie du terrain.";
        foreach (var joueur in joueurs)
        {
            if (joueur.attaqueRecue == Oie.Attaque.Glace)
            {
                texteGlace += $"\n{joueur.nom} aura le résultat de son dé divisé par 2 au prochain tour.";
            }
        }
        return texteGlace;
    }

    /// <summary>
    /// Ecrit le texte pour la tempête
    /// </summary>
    /// <param name="joueurs">Liste des joueurs</param>
    /// <returns>Le résultat de l'action de la tempête</returns>
    private string EcrireTexteTempete(List<Joueur> joueurs)
    {
        string texteTempete = $"L'oie fait une tempête et échange";
        List<Joueur> joueursEchanges = new List<Joueur>();
        foreach (var joueur in joueurs)
        {
            if (joueur.attaqueRecue == Oie.Attaque.Tempete)
            {
                joueursEchanges.Add(joueur);
            }
        }
        return $"L'oie fait une tempête et échange {joueursEchanges[0].nom} et {joueursEchanges[1].nom}";
    }

    /// <summary>
    /// Ecrit le texte pour l'innondation
    /// </summary>
    /// <param name="joueurs">Liste des joueurs</param>
    /// <returns>Texte de l'innondation</returns>
    private string EcrireTexteInnondation(List<Joueur> joueurs)
    {
        string texteInnondation = "";
        texteInnondation = "L'oie fait innonder le terrain.";
        foreach (var joueur in joueurs)
        {
            texteInnondation += $"\n{joueur.nom} a ";
            if (joueur.attaqueBenefique)
            {
                texteInnondation += $"avancé ";
            }
            else
            {
                texteInnondation += $"reculé ";
            }
            texteInnondation += $"de {NB_CASE_INNONDATION} cases.";
        }
        return texteInnondation;
    }

    /// <summary>
    /// Ecrit la description pour le texte de la foudre
    /// </summary>
    /// <param name="joueurs">Liste des joueurs</param>
    /// <returns>Texte de l'attaque de la foudre</returns>
    private string EcrireTexteFoudre(List<Joueur> joueurs)
    {
        string texteFoudre = $"L'oie lance la foudre sur le terrain.";
        foreach (var joueur in joueurs)
        {
            if (joueur.attaqueRecue == Oie.Attaque.Foudre)
            {
                texteFoudre += $"\n{joueur.nom} est immobilisé pour le prochain tour.";
            }
        }
        return texteFoudre;
    }

    //5 attaques de l'oie
    /// <summary>
    /// Fait la tempête de l'oie, échange deux joueurs aléatoirement
    /// </summary>
    /// <param name="joueurs">List de tout les joueurs</param>
    private void Tempeter(List<Joueur> joueurs)
    {
        int[] joueursTouches = new int[NB_JOUEURS_TEMPETE];
        do
        {
            joueurs = Joueur.ResetAttaque(joueurs);
            for (int i = 0; i < NB_JOUEURS_TEMPETE; i++)
            {
                // joueursAffectes.Add(nombreRandom.Next(0, joueurs.Count));
                joueursTouches[i] = nombreRandom.Next(0, joueurs.Count);
                joueurs[i].attaqueRecue = Oie.Attaque.Tempete;
            }
        } while (joueursTouches[0] == joueursTouches[1]);


        // Echanger leurs positions
        joueurs[joueursTouches[0]].EchangerJoueurs(joueurs[joueursTouches[1]]);
    }

    /// <summary>
    /// Foudroie les joueurs avec une chance sur 3
    /// Si le joueur est touché, il ne peut pas joueur pendant un tour
    /// </summary>
    /// <param name="joueurs">Liste des joueurs</param>
    private void Foudroyer(List<Joueur> joueurs)
    {
        foreach (var joueur in joueurs)
        {
            if (Random3())
            {
                joueur.attaqueRecue = Oie.Attaque.Foudre;
            }
        }
    }

    /// <summary>
    /// Fait innonder le terraine
    /// Chaque joueur a une chance sur deux de reculer de trois case et une chance sur deux d'avancer de trois cases
    /// </summary>
    /// <param name="joueurs">Liste des joueurs</param>
    private void Innonder(List<Joueur> joueurs)
    {
        for (int i = 0; i < joueurs.Count; i++)
        {
            int deplacement = NB_CASE_INNONDATION;
            joueurs[i].attaqueRecue = Oie.Attaque.Innondation;
            joueurs[i].attaqueBenefique = true;
            if (Random2())
            {
                joueurs[i].attaqueBenefique = false;
                deplacement = -deplacement;
            }
            joueurs[i].SeDeplacer(deplacement);
        }
    }

    /// <summary>
    /// L'oie glace certain joueurs
    /// Chaque joueur à une chance sur 2 de voir son dé divisé par 2 au prochain tour
    /// </summary>
    /// <param name="joueurs">List des joueurs</param>
    private void Glacer(List<Joueur> joueurs)
    {
        foreach (var joueur in joueurs)
        {
            if (Random2())
            {
                joueur.attaqueRecue = Oie.Attaque.Glace;
            }
        }
    }

    /// <summary>
    /// Fait un random avec une chance sur 2
    /// </summary>
    /// <returns>True une fois sur 2</returns>
    private bool Random2()
    {
        return Random(2);
    }

    /// <summary>
    /// Fait un random sur 3
    /// </summary>
    /// <returns>Retourn true théoriquement une fois sur 3</returns>
    private bool Random3()
    {
        return Random(3);
    }

    /// <summary>
    /// Fait un random et renvoie true ou false
    /// </summary>
    /// <param name="chance">Nombre de chance d'avoir le true, plus le chiffre est grand, moins on a de chance</param>
    /// <returns>True ou false</returns>
    private bool Random(int chance)
    {
        bool reponse = false;
        // Multiplie le chiffre pour avoir un aléatoir plus correct
        int chances = (chance - 1) * 100;
        if (nombreRandom.Next(chances) < chances / 2)
        {
            reponse = true;
        }
        return reponse;
    }
}
