using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFleche : MonoBehaviour
{
    public ConfigurationPartie configurationPartie;
    private bool direction;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        ChangerConfiguration();
    }

    public void ChangerConfiguration()
    {
        //quand on clique sur une flèche, enregistrer les changement du personnage actuel
        configurationPartie.MettreAJourJoueur();
        //puis passer au personnage suivant
        configurationPartie.ChangerIdJoueur(direction);
    }
}
