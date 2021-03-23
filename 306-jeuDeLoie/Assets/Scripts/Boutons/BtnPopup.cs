using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Bouton qui affiche un popup
/// </summary>
public class BtnPopup : MonoBehaviour
{
    /// <summary>
    /// Popup à afficher
    /// </summary>
    public Popup popup;
    /// <summary>
    /// Bouton qui fait afficher
    /// </summary>
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(popup.AfficherPopup);
    }
}
