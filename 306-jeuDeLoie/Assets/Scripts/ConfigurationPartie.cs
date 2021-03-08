using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationPartie : MonoBehaviour
{
    public GameObject jeu;
    private int idJoueur;

    //Appelé avant la première frame
    void Start()
    {
        
    }

    //Appelé à chaque frame
    void Update()
    {
        
    }
    
    public void MettreAJourJoueur()
    {
        //Le joueur a modifie les informations de son personnage - appeler quand on clique sur une flèche

        // /!\ Récupérer les informations
        jeu.GetComponent<Jeu>().ObtientJoueurs()[idJoueur].DetermineNom("nom récupéré dans le champs");
        jeu.GetComponent<Jeu>().ObtientJoueurs()[idJoueur].DetermineEspece(new Espece());
    }

    public void ChangerIdJoueur(bool direction)
    {
        //décrémenter le compteur de joueurs si false, incrémenter si true
        if (direction)
        {
            idJoueur -= 1;
            if (idJoueur < 0)
            {
                idJoueur = (jeu.GetComponent<Jeu>().ObtientNbJoueur()-1);
            }
        }
        else
        {
            idJoueur += 1;
            if(idJoueur >= jeu.GetComponent<Jeu>().ObtientNbJoueur())
            {
                idJoueur = 0;
            }
        }
    }
}
