using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gage : MonoBehaviour
{
    /// <summary>
    /// Couleur bleue
    /// </summary>
    /// <returns>Couleur bleue</returns>
    public static UnityEngine.Color bleu = new UnityEngine.Color(80f / 255f, 224f / 255f, 210f / 255f, 1f);
    /// <summary>
    /// Couleur vert
    /// </summary>
    /// <returns>Couleur</returns>
    public static UnityEngine.Color vert = new UnityEngine.Color(163f / 255f, 248f / 255f, 198f / 255f, 1f);
    /// <summary>
    /// Couleur vert foncé
    /// </summary>
    /// <returns>Couleur</returns>
    public static UnityEngine.Color vertFonce = new UnityEngine.Color(60f / 255f, 166f / 255f, 29f / 255f, 1f);
    /// <summary>
    /// Couleur jaune vert
    /// </summary>
    /// <returns>Couleur</returns>
    public static UnityEngine.Color jauneVert = new UnityEngine.Color(206f / 255f, 255f / 255f, 121f / 255f, 1f);
    /// <summary>
    /// Couleur rouge
    /// </summary>
    /// <returns>Couleur</returns>
    public static UnityEngine.Color rouge = new UnityEngine.Color(55f / 255f, 236f / 255f, 71f / 255f, 1f);
    /// <summary>
    /// Liste des gages
    /// </summary>
    /// <typeparam name="Gage">Gages</typeparam>
    /// <returns></returns>
    public static List<Gage> gages = new List<Gage>() {
        new Gage("Fait un bras de fer avec la personne qui est à ta droite", bleu),
        new Gage("Parle comme Yoda pendant les trois prochain tours", rouge),
        new Gage("Joue à ni oui ni non avec la personne à ta gauche, celui qui perd fait 10 pompes", vert),
        new Gage("Ne parle plus pendant trois tours", vertFonce),
        new Gage("Fait un combat de regard avec la personne qui est à ta droite", jauneVert)

    };
    /// <summary>
    /// Description
    /// </summary>
    public string description;
    /// <summary>
    /// Couleur 
    /// </summary>
    public Color color;

    /// <summary>
    /// Crée un gage
    /// </summary>
    /// <returns>Gage</returns>
    public Gage() : this("Sample Gage", Color.black) { }
    /// <summary>
    /// Crée un gage
    /// </summary>
    /// <param name="InDescription">Description</param>
    /// <returns>Gage</returns>
    public Gage(string InDescription) : this(InDescription, Color.blue) { }
    /// <summary>
    /// Crée un gage
    /// </summary>
    /// <param name="InDescription">Description</param>
    /// <param name="InColor">Couleur</param>
    public Gage(string InDescription, Color InColor)
    {
        description = InDescription;
        color = InColor;
    }
}
