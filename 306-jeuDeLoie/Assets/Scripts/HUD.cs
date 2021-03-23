using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public BarreInfo barreInfo;
    public CompteurTour compteurTour;
    public Joueur joueurActuel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Met à joue le numéro du tour    
    /// </summary>
    /// <param name="numeroTour">Numéro du tour</param>
    public void UpdateNumeroTour(int numeroTour) {
        compteurTour.content.text = $"Tour n°{numeroTour}";
    }

    /// <summary>
    /// Met à jour la barre d'info
    /// </summary>
    public void InitBarreInfo() {
        barreInfo.Init(joueurActuel);
    }

    /// <summary>
    /// Met à jour la barre d'info
    /// </summary>
    public void UpdateBarreInfo() {
        barreInfo.UpdateDe(joueurActuel);
    }
}
