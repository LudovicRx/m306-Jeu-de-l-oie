using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur : MonoBehaviour
{
    public static List<string> noms = new List<string>() { "Thalion", "Alta", "Ama", "Ulnim", "Wing-leon", "Themeril", "Riantho", "Sylcir", "Voril", "Thosrodior", "Maehal", "Raxa", "Caror", "Vargnor", "Laimor", "Galcir", "Ingimor" };
    private static System.Random nombreRandom = new System.Random();
    private string nom;
    private Espece espece;
    public Case emplacement;
    public Plateau plateau;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LancerDe()
    {
        int result = nombreRandom.Next(1, 7);
        this.SeDeplacer(result);
    }

    public void Action()
    {

    }

    private void SeDeplacer(int nbDeplacement)
    {
        int idNewCase = nbDeplacement + this.emplacement.GetComponent<Case>().IdCase;
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
                this.espece = new Elfe();
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
        this.name = noms[numNom];
    }

    public void DetermineEspece(Espece espece)
    {
        this.espece = espece;
    }

    public void DetermineNom(string nom)
    {
        this.nom = nom;
    }
}
