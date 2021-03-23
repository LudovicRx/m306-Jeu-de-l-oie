using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCreerPartie : MonoBehaviour
{
    public GameObject camera;
    public GameObject pageConfig;
    public GameObject fondPageConfig;

   // private string texte;
    private int nbJoueurs;

    // Start is called before the first frame update
    void Start()
    {
        pageConfig.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, 70);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void OnMouseDown()
   {
       //Enregistrer le nombre de joueurs entré par les utilisateurs (remplacer par textarea.text)
       nbJoueurs = 1;

       //créer la partie (générer le bon nombre de joueurs)
       CreerPartie();

       //Aller sur la page pour personnaliser les personnages
       camera.GetComponent<Transform>().position = new Vector3(fondPageConfig.transform.position.x, fondPageConfig.transform.position.y, 60);
   }

    public void CreerPartie()
    {
        List<Joueur> joueursProvisoirs = new List<Joueur>();

        //Pré-fabriquer des personnage aux races et noms aléatoires, au nombre des joueurs
        for (int i = 0; i < nbJoueurs; i++)
        {
            joueursProvisoirs.Add(new Joueur());
            joueursProvisoirs[i].DetermineEspeceDefaut();
            joueursProvisoirs[i].DetermineNomDefaut();
        }

       //jeu.GetComponent<Jeu>().DetermineJoueurs(joueursProvisoirs); 
    }
}
