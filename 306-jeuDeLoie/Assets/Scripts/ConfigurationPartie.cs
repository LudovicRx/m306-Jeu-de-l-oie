using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationPartie : MonoBehaviour
{
    private int idJoueur;
    private Espece espece;

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

        // /!\ Récupérer le champs pseudo
        Jeu.joueurs[idJoueur].DetermineNom("nom récupéré dans le champs");
        // /!\ Récupérer la race sélectionnée (radiobutton)
        Jeu.joueurs[idJoueur].DetermineEspece(new Espece());
    }

    public void ChangerIdJoueur(bool direction)
    {
        //décrémenter le compteur de joueurs si false, incrémenter si true
        if (direction)
        {
            idJoueur -= 1;
            if (idJoueur < 0) // min 0 
            {
                idJoueur = 0;
            }
        }
        else
        {
            idJoueur += 1;
            if(idJoueur >= Jeu.joueurs.Count)
            {
                idJoueur = Jeu.joueurs.Count- 1; // index
            }
        }
    }
}
