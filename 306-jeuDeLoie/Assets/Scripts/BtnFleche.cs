using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnFleche : MonoBehaviour
{
    public GameObject configurationpartie;
    private bool etat;
    private ConfigurationPartie configuration;

    // Start is called before the first frame update
    void Start()
    {
        ConfigurationPartie configuration = new ConfigurationPartie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangerConfiguration()
    {
        //quand on clique sur une flèche, enregistrer les changement du personnage actuel
        configuration.GetComponent<ConfigurationPartie>().ChangerIdJoueur(etat);
        //puis passer au personnage suivant
        configuration.GetComponent<ConfigurationPartie>().ChangerIdJoueur(etat);
    }
}
