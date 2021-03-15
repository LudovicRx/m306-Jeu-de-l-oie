using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    public GameObject joueur;
    public GameObject joueur2;
    public GameObject joueur3;
    public GameObject joueur4;

    // VARIABLES 
    public List<Joueur> joueurs = new List<Joueur>();
    private List<Gage> gages = new List<Gage>();
    public Plateau plateau;
    private Oie oie;    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            joueur.GetComponent<Transform>().SetParent(plateau.cases[4].GetComponent<Transform>());
            joueur.GetComponent<Transform>().localPosition = new Vector3(0, 0.02f, 0.02f);
        }
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

    public void BougeJoueur() {
        
    }
}
