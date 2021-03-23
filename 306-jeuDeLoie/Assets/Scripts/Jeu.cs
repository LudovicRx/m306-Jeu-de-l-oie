using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    public GameObject elf;
    public GameObject fee;
    public GameObject nain;
    public GameObject orc;

    // VARIABLES
    public static List<Joueur> joueurs = new List<Joueur>();
    public Plateau plateau;
    private Oie oie;

    public Joueur joueurGagnant = null;
    public int joueurActuel;
    public PopupGage popupGage;

    public PopupFinPartie popupFin;
    public HUD hud;
    public int numeroTour;

    // Start is called before the first frame update
    void Start()
    {
        joueurs.Add(Instantiate(elf).GetComponent<Joueur>());
        joueurs.Add(Instantiate(fee).GetComponent<Joueur>());
        joueurs.Add(Instantiate(nain).GetComponent<Joueur>());
        joueurs.Add(Instantiate(orc).GetComponent<Joueur>());
        foreach (var joueur in joueurs)
        {
            joueur.plateau = this.plateau;
        }
        popupGage.MasquerPopup();
        popupFin.btnRejouer.onClick.AddListener(InitialiserJeu);
        popupGage.button.onClick.AddListener(hud.InitBarreInfo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InitialiserJeu();
        }

        if (joueurGagnant == null)
        {
            if (Input.GetKeyDown(KeyCode.L) && !popupGage.isOpen)
            {
                joueurs[joueurActuel].LancerDe();
                hud.InitBarreInfo();
                hud.UpdateBarreInfo();

                BougeJoueur(joueurs[joueurActuel], joueurs[joueurActuel].emplacement.gameObject);

                if (joueurs[joueurActuel].emplacement.IdCase < this.plateau.cases[this.plateau.cases.Count - 1].GetComponent<Case>().IdCase)
                {
                    popupGage.AfficherGage(joueurs[joueurActuel].emplacement.gage);
                }


                joueurActuel++;
                joueurActuel %= ObtientNbJoueur();

                hud.joueurActuel = joueurs[joueurActuel];
                if (joueurActuel == 0)
                {
                    numeroTour++;
                    hud.UpdateNumeroTour(numeroTour);
                }

                joueurGagnant = VerifierGagnant();

                if (joueurGagnant != null)
                {
                    popupFin.AfficherPopUpFin(joueurGagnant);

                }

            }
        }

    }

    // Initialisation du jeu
    public void InitialiserJeu()
    {
        for (int i = 0; i < plateau.casesDepart.Count; i++)
        {
            BougeJoueur(joueurs[i], plateau.casesDepart[i]);
        }
        joueurGagnant = null;
        joueurActuel = 0;
        numeroTour = 1;
        popupGage.MasquerPopup();
        hud.UpdateNumeroTour(numeroTour);
        hud.joueurActuel = joueurs[joueurActuel];
        hud.InitBarreInfo();

    }

    // Retourne le joueur qui gagne
    public Joueur VerifierGagnant()
    {
        foreach (var joueur in joueurs)
        {
            if (joueur.emplacement == plateau.cases[plateau.cases.Count - 1].GetComponent<Case>())
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
        float z = 0.05f;
        // foreach (Transform child in c.GetComponent<Transform>())
        // {
        //     //  * child.localScale.z
        //     z += child.worldToLocalMatrix.m21;
        // }
        // for (int i = 0; i < c.GetComponent<Transform>().childCount; i++)
        // {

        // }
        joueur.GetComponent<Transform>().SetParent(c.GetComponent<Transform>());
        joueur.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
        joueur.GetComponent<Transform>().localPosition = new Vector3(0, 0, z);
        joueur.GetComponent<Joueur>().emplacement = c.GetComponent<Case>();

        // if (c.GetComponent<Case>().IdCase > 0 && c.GetComponent<Case>().IdCase < this.plateau.cases[this.plateau.cases.Count - 1].GetComponent<Case>().IdCase)
        // {
        //     Debug.Log(c.GetComponent<Case>().gage.description);
        // }
    }

    public void ActiverOie()
    {
        //L'oie joue son tour
        oie.Jouer(joueurs.Count);
    }
}
