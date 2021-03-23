using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oie : MonoBehaviour
{
    /*ALIYA EN TRAIN DE FAIRE CECI*/

    private List<Case> cases = new List<Case>();
    private System.Random nombreRandom = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Fini
    public void Jouer(int nbJoueurs)
    {
        int attaque = nombreRandom.Next(1, 21);

        //une chance sur 5 d'attaquer, 4 attaques possibles
        switch(attaque){
            case 1 :
                Tempeter(nbJoueurs);
                break;
            case 2 :
                Fourdroyer();
                break;
            case 3 :
                Innonder();
                break;
            case 4 :
                Glacer();
                break;
        }
    }


    //5 attaques de l'oie
    private void Tempeter(int nbJoueurs)
    {
        //sélectionner au hasard deux joueurs
        int joueur1 = nombreRandom.Next(1, nbJoueurs + 1);
        int joueur2 = nombreRandom.Next(1, nbJoueurs + 1);

        //échanger leurs positions
    }
    private void Fourdroyer()
    {
        //chaque case du plateau a une chance sur 3 d'être immobilisée 
        //(le joueur qui est est dessus ne joue pas pendant un tour)

    }
    private void Innonder()
    {
        //chaque joueur a une chance sur deux de reculer de trois case et une chance sure deux d'avancer de trois cases

    }
    private void Glacer()
    {
        //chaque joueur à une chance sur 2 de voir son dé divisé par 2 au prochain tour

    }
}
