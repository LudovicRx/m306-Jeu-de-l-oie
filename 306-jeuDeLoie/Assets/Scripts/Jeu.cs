using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe qui gère le jeu
/// </summary>
public class Jeu : MonoBehaviour
{
    /// <summary>
    /// Modèle pour un joueur elf
    /// </summary>
    public GameObject elf;
    /// <summary>
    /// Modèle pour un joueur fée
    /// </summary>
    public GameObject fee;
    /// <summary>
    /// Modèle pour un joueur nain
    /// </summary>
    public GameObject nain;
    /// <summary>
    /// Modèle pour un joueur orc
    /// </summary>
    public GameObject orc;

    /// <summary>
    /// Liste des joueurs
    /// </summary>
    /// <typeparam name="Joueur">Joueurs</typeparam>
    /// <returns>Liste des joueurs</returns>
    public static List<Joueur> joueurs = new List<Joueur>();
    /// <summary>
    /// Plateau de jeu
    /// </summary>
    public Plateau plateau;
    /// <summary>
    /// Oie qui influe sur le jeu
    /// </summary>
    public Oie oie;
    /// <summary>
    /// Joueur qui a gagné la partie
    /// </summary>
    public Joueur joueurGagnant = null;
    /// <summary>
    /// Index du joueur qui joue
    /// </summary>
    public int idJoueurActuel;
    /// <summary>
    /// Numéro du tour
    /// </summary>
    public int numeroTour;

    // Affichage
    /// <summary>
    /// Popup pour les informations
    /// </summary>
    public PopupInfo popupInfo;
    /// <summary>
    /// Popup de la fin de partie
    /// </summary>
    public PopupFinPartie popupFin;
    /// <summary>
    /// Popup du paramètres
    /// </summary>
    public PopupParametres popupParametres;
    /// <summary>
    /// Afifchage d'informations
    /// </summary>
    public HUD hud;


    // Start is called before the first frame update
    void Start()
    {
        joueurs.Add(Instantiate(elf).GetComponent<Joueur>());
        joueurs.Add(Instantiate(fee).GetComponent<Joueur>());
        joueurs.Add(Instantiate(nain).GetComponent<Joueur>());
        joueurs.Add(Instantiate(orc).GetComponent<Joueur>());
        joueurs[0].DetermineEspece(0);
        joueurs[1].DetermineEspece(1);
        joueurs[2].DetermineEspece(3);
        joueurs[3].DetermineEspece(2);
        foreach (var joueur in joueurs)
        {
            joueur.plateau = this.plateau;
        }
        popupInfo.MasquerPopup();
        popupFin.btnRejouer.onClick.AddListener(InitialiserJeu);
        popupInfo.button.onClick.AddListener(hud.InitBarreInfo);
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
            if (Input.GetKeyDown(KeyCode.L) && !popupInfo.IsOpen && !popupParametres.IsOpen)
            {
                joueurs[idJoueurActuel].DesactiverGlace();

                if (joueurs[idJoueurActuel].attaqueRecue != Oie.Attaque.Foudre)
                {
                    joueurs[idJoueurActuel].LancerDe();
                    BougeJoueur(joueurs[idJoueurActuel], joueurs[idJoueurActuel].emplacement.gameObject);

                    hud.InitBarreInfo();
                    hud.UpdateBarreInfo();

                    if (joueurs[idJoueurActuel].emplacement.IdCase < this.plateau.cases[this.plateau.cases.Count - 1].GetComponent<Case>().IdCase)
                    {
                        popupInfo.AfficherPopupInfo("Gage", joueurs[idJoueurActuel].emplacement.gage.description);
                    }

                }
                idJoueurActuel++;
                idJoueurActuel %= ObtientNbJoueur();

                hud.joueurActuel = joueurs[idJoueurActuel];
                if (idJoueurActuel == 0)
                {
                    numeroTour++;
                    popupInfo.button.onClick.AddListener(ActiverOie);
                }

                joueurGagnant = VerifierGagnant();

                if (joueurGagnant != null)
                {
                    popupFin.AfficherPopUpFin(joueurGagnant);

                }
            }
        }
    }

    /// <summary>
    /// Initialise le jeu
    /// </summary>
    public void InitialiserJeu()
    {
        for (int i = 0; i < plateau.casesDepart.Count; i++)
        {
            BougeJoueur(joueurs[i], plateau.casesDepart[i]);
        }
        joueurGagnant = null;
        idJoueurActuel = 0;
        numeroTour = 1;
        popupInfo.MasquerPopup();
        hud.UpdateNumeroTour(numeroTour);
        hud.joueurActuel = joueurs[idJoueurActuel];
        hud.InitBarreInfo();

    }

    /// <summary>
    /// Vérifie qui est le gagnant
    /// </summary>
    /// <returns>Retourne le joueur si il y a un gagnant, sinon null</returns>
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

    /// <summary>
    /// Obtient le nombre de joueurs
    /// </summary>
    /// <returns>Nombre de joueur</returns>
    public int ObtientNbJoueur()
    {
        return joueurs.Count;
    }



    /// <summary>
    /// Obtient la liste des joueurs
    /// </summary>
    /// <returns>Liste des joueurs</returns>
    public List<Joueur> ObtientJoueurs()
    {
        return joueurs;
    }

    /// <summary>
    /// Fait bouger un joueur
    /// </summary>
    /// <param name="joueur"></param>
    /// <param name="c"></param>
    public void BougeJoueur(Joueur joueur, GameObject c)
    {
        float z = 0.05f;
        joueur.GetComponent<Transform>().SetParent(c.GetComponent<Transform>());
        joueur.GetComponent<Transform>().rotation = new Quaternion(0, 0, 0, 0);
        joueur.GetComponent<Transform>().localPosition = new Vector3(0, 0, z);

        // Reset the speed
        joueur.GetComponent<Rigidbody>().velocity = Vector3.zero;
        joueur.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        joueur.GetComponent<Joueur>().emplacement = c.GetComponent<Case>();
    }

    /// <summary>
    /// Met en marche la fonction de l'oie
    /// </summary>
    public void ActiverOie()
    {
        popupInfo.button.onClick.AddListener(UpdateNumeroTour);
        popupInfo.button.onClick.RemoveListener(ActiverOie);

        //L'oie joue son tour
        oie.Jouer(joueurs);
        foreach (var joueur in joueurs)
        {
            if (joueur.attaqueRecue == oie.attaqueUtilise)
            {
                switch (oie.attaqueUtilise)
                {
                    case Oie.Attaque.Tempete:
                    case Oie.Attaque.Innondation:
                        BougeJoueur(joueur, joueur.emplacement.gameObject);
                        break;
                    case Oie.Attaque.Glace:
                        joueur.ActiverGlace();
                        break;
                }
            }
        }
        popupInfo.AfficherPopupInfo("Oie", oie.descriptionAttaque);
    }

    /// <summary>
    /// Met à jour le numéro du tour
    /// </summary>
    private void UpdateNumeroTour()
    {
        hud.UpdateNumeroTour(numeroTour);
        popupInfo.button.onClick.RemoveListener(UpdateNumeroTour);
    }
}
