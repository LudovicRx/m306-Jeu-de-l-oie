using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    public GameObject joueur;

    // VARIABLES 
    public List<Joueur> joueurs = new List<Joueur>();
    private List<Gage> gages = new List<Gage>();
    private Plateau plateau;
    private Oie oie;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Initialisation du jeu 
    public void InitialiserJeu()
    {

    }

    // Retourne le joueur qui gagne
    public Joueur VerifierGagnant()
    {
        return new Joueur();
    }

    public int ObtientNbJoueur()
    {
        return joueurs.Count;
    }

    public void DetermineJoueurs(List<Joueur> joueursParDefaut)
    {
        this.joueurs = joueursParDefaut;
    }

    public List<Joueur> ObtientJoueurs() {
        return joueurs;
    }
}
