using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Script qui fait retourner au menu principal
/// </summary>
public class BtnMenuPrincipal : MonoBehaviour
{
    /// <summary>
    /// Bouton du menu principal
    /// </summary>
    public Button btnMenuPrincipal;

    // Start is called before the first frame update
    void Start()
    {
        btnMenuPrincipal.onClick.AddListener(ChangerScene);
    }

    /// <summary>
    /// Change la scene et va sur le menu principal
    /// </summary>
    public void ChangerScene()
    {
        SceneManager.LoadScene("Assets/Scenes/PagesParametresPartie.unity");
    }
}
