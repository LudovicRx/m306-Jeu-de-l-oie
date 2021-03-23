using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Compteur de tour
/// </summary>
public class CompteurTour : MonoBehaviour
{
    /// <summary>
    /// Texte du compteur de tour
    /// </summary>
    public Text content;

    /// <summary>
    /// Met à jour le texte du compteur de tour
    /// </summary>
    /// <param name="numeroTour">Numéro du tour</param>
    public void UpdateText(int numeroTour)
    {
        content.text = $"Tour n°{numeroTour}";
    }
}
