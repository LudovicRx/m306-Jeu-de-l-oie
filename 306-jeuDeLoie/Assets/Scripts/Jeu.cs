using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    // VARIABLES 
    private List<Joueur> joueurs = new List<Joueur>();
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


}
