using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    /// <summary>
    /// List de noms de joueurs
    /// </summary>
    public static List<string> noms = new List<string>() { "Thalion", "Alta", "Ama", "Ulnim", "Wing-leon", "Themeril", "Riantho", "Sylcir", "Voril", "Thosrodior", "Maehal", "Raxa", "Caror", "Vargnor", "Laimor", "Galcir", "Ingimor" };
    /// <summary>
    /// Random
    /// </summary>
    protected static System.Random nombreRandom = new System.Random();
    /// <summary>
    /// Nom du joueur
    /// </summary>
    public string nom;
    /// <summary>
    /// Espece du joueur
    /// </summary>
    public bool estCharmer;
    private Espece espece;
    /// <summary>
    /// Emplacement du joueur
    /// </summary>
    public Case emplacement;
    /// <summary>
    /// Plateau du joueur
    /// </summary>
    public Plateau plateau;
    /// <summary>
    /// Résultat du dé du joueur
    /// </summary>
    public int resultatDes;
    /// <summary>
    /// Définit quelle attaque a recu le joueur
    /// </summary>
    public Oie.Attaque attaqueRecue;
    /// <summary>
    /// True si l'attaque est un bonus, false si l'attaque est un malus 
    /// </summary>
    public bool attaqueBenefique;

    // Start is called before the first frame update
    private void Start()
    {
        attaqueRecue = Oie.Attaque.Rien;
        attaqueBenefique = false;
    }

    /// <summary>
    /// Tire les dés
    /// </summary>
    public void LancerDe()
    {
        resultatDes = nombreRandom.Next(1, 7);
        if (attaqueRecue == Oie.Attaque.Glace)
        {
            resultatDes /= Oie.GLACE_DIVISEUR;
        }
        this.SeDeplacer(resultatDes);
    }

    public void Action()
    {

    }

    /// <summary>
    /// Bouge le joueur
    /// </summary>
    /// <param name="nbDeplacement">Nombre de case du déplacement</param>
    public void SeDeplacer(int nbDeplacement)
    {
        int idNewCase = nbDeplacement + this.emplacement.GetComponent<Case>().IdCase;
        if(idNewCase < 0) {
            idNewCase = 0;
        }
        
        if (idNewCase <= plateau.cases.Count)
        {
            this.emplacement = plateau.cases[idNewCase - 1].GetComponent<Case>();
        }
    }

    public void DetermineEspeceDefaut()
    {
        System.Random rnd = new System.Random();
        int numEspece = rnd.Next(0, 4);

        //Donner une espèce aléatoire au joueur par défaut  
        switch (numEspece)
        {
            case 0:
                this.espece = new Elfe();
                break;
            case 1:
                this.espece = new Fee();
                break;
            case 2:
                this.espece = new Orc();
                break;
            case 3:
                this.espece = new Nain();
                break;
        }
    }

    public void DetermineNomDefaut()
    {
        //Donner un nom aléatoire au joueur par défaut
        System.Random rnd = new System.Random();
        int numNom = rnd.Next(0, noms.Count);
        this.nom = noms[numNom];
    }

    public void DetermineEspece(Espece espece)
    {
        this.espece = espece;
    }

    public void DetermineNom(string nom)
    {
        this.nom = nom;
    }

    /// <summary>
    /// Echange l'emplaement de deux joueurs
    /// </summary>
    /// <param name="autreJoueur">Joueur avec qui la place s'échange</param>
    public void EchangerJoueurs(Joueur autreJoueur)
    {
        Case temp = this.emplacement;
        this.emplacement = autreJoueur.emplacement;
        autreJoueur.emplacement = temp;
    }

    /// <summary>
    /// Remet à jour les attaque recues
    /// </summary>
    /// <param name="joueurs">Liste des joueurs</param>
    /// <returns>Liste des joueurs remise à jour</returns>
    public static List<Joueur> ResetAttaque(List<Joueur> joueurs)
    {
        foreach (var joueur in joueurs)
        {
            joueur.attaqueRecue = Oie.Attaque.Rien;
        }
        return joueurs;
    }
}
