using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupFinPartie : Popup
{
    public Button btnRejouer;
    public Button btnMenuPrincipale;
    public Text nomGagnant;

    private AssetBundle myLoadedAssetBundle;
    public void AfficherPopUpFin(Joueur joueurGagnant)
    {
        this.gameObject.SetActive(true);
        nomGagnant.text = joueurGagnant.nom;
    }

    // Start is called before the first frame update
    void Start()
    {
        //  myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes/PagesParametresPartie");

        btnMenuPrincipale.onClick.AddListener(ChangeScene);
        btnRejouer.onClick.AddListener(MasquerPopup);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Assets/Scenes/PagesParametresPartie.unity");
    }
}
