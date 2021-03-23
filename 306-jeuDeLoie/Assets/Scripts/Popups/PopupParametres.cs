using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Popup des parametres
/// </summary>
public class PopupParametres : Popup
{
    /// <summary>
    /// Bouton qui sert à reprendre
    /// </summary>
    public Button btnReprendre;
    /// <summary>
    /// Bouton qui fait retourner au menu principal
    /// </summary>
    public Button btnMenuPrincipal;
    /// <summary>
    /// Bouton de la croix
    /// </summary>
    public Button btnCroix;
    
    // Start is called before the first frame update
    void Start()
    {
        btnReprendre.onClick.AddListener(MasquerPopup);
        btnCroix.onClick.AddListener(MasquerPopup);
    }
}
