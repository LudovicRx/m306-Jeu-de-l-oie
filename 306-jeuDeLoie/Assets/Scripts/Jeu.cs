using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    public GameObject joueur1;
    public GameObject joueur2;
    public GameObject joueur3;
    public GameObject joueur4;

    // VARIABLES 
    public List<Joueur> joueurs = new List<Joueur>();
    public Plateau plateau;
    private Oie oie;
    public int joueurActuel;

    // Start is called before the first frame update
    void Start()
    {
        joueurs.Add(joueur1.GetComponent<Joueur>());
        joueurs.Add(joueur2.GetComponent<Joueur>());
        joueurs.Add(joueur3.GetComponent<Joueur>());
        joueurs.Add(joueur4.GetComponent<Joueur>());
        joueurActuel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InitialiserJeu();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            joueurs[joueurActuel].LancerDe();
            BougeJoueur(joueurs[joueurActuel], joueurs[joueurActuel].emplacement.gameObject);
            joueurActuel++;
            joueurActuel %= ObtientNbJoueur();
        }
    }

    // Initialisation du jeu 
    public void InitialiserJeu()
    {
        for (int i = 0; i < plateau.casesDepart.Count; i++)
        {
            BougeJoueur(joueurs[i], plateau.casesDepart[i]);
        }
    }

    // Retourne le joueur qui gagne
    public Joueur VerifierGagnant()
    {
        foreach (var joueur in joueurs)
        {
            if (joueur.emplacement == plateau.cases[plateau.cases.Count - 1])
            {
                return joueur;
            }
        }
        return null;
    }

    public int ObtientNbJoueur()
    {
        return joueurs.Count;
    }

    public void DetermineJoueurs(List<Joueur> joueursParDefaut)
    {
        this.joueurs = joueursParDefaut;
    }

    public List<Joueur> ObtientJoueurs()
    {
        return joueurs;
    }

    public void BougeJoueur(Joueur joueur, GameObject c)
    {
        joueur.GetComponent<Transform>().SetParent(c.GetComponent<Transform>());
        joueur.GetComponent<Transform>().localPosition = new Vector3(0, 0, 0.017f);
        joueur.GetComponent<Joueur>().emplacement = c.GetComponent<Case>();
        if (c.GetComponent<Case>().IdCase > 0)
        {
            Debug.Log(c.GetComponent<Case>().gage.description);
        }
    }
}
