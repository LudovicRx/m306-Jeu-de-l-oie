using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe qui gère l'interface
/// Head Up Display - affichage à tête haute 
/// </summary>
public class HUD : MonoBehaviour
{
    /// <summary>
    /// Barre d'informations
    /// </summary>
    public BarreInfo barreInfo;
    /// <summary>
    /// Compteur de tour
    /// </summary>
    public CompteurTour compteurTour;
    /// <summary>
    /// Joueur qui joue actuellement
    /// </summary>
    public Joueur joueurActuel;

    /// <summary>
    /// Met à joue le numéro du tour    
    /// </summary>
    /// <param name="numeroTour">Numéro du tour</param>
    public void UpdateNumeroTour(int numeroTour) {
        compteurTour.UpdateText(numeroTour);
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
