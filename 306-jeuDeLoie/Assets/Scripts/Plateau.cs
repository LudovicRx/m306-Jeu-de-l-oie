using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Gère le plateau de jeu
/// </summary>
public class Plateau : MonoBehaviour
{
    /// <summary>
    /// Modèle d'une case
    /// </summary>
    public GameObject modeleCase;
    /// <summary>
    /// Nombre de colonnes
    /// </summary>
    private int nbColonnes = 16;
    /// <summary>
    /// Nombre de lignes
    /// </summary>
    private int nbLignes = 12;
    /// <summary>
    /// Aléatoire
    /// </summary>
    /// <returns>Générateur de nombre pseudos-aléatoire</returns>
    private System.Random random = new System.Random();
    /// <summary>
    /// Cases jouables
    /// </summary>
    public Tuple<bool, int>[,] casesJouables;
    /// <summary>
    /// Cases qui ont été crées
    /// </summary>
    /// <typeparam name="GameObject">Case</typeparam>
    /// <returns>Liste des cases</returns>
    public List<GameObject> cases = new List<GameObject>();
    /// <summary>
    /// Cases de départ
    /// </summary>
    /// <typeparam name="GameObject">4 cases de départ</typeparam>
    /// <returns>Cases de départ sous forme de liste</returns>
    public List<GameObject> casesDepart = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        casesJouables = new Tuple<bool, int>[nbLignes, nbColonnes];
        casesJouables[0, 0] = new Tuple<bool, int>(true, 0);
        casesJouables[0, 1] = new Tuple<bool, int>(true, 0);
        casesJouables[1, 0] = new Tuple<bool, int>(true, 0);
        casesJouables[1, 1] = new Tuple<bool, int>(true, 0);
        casesJouables[2, 0] = new Tuple<bool, int>(true, 1);
        casesJouables[3, 0] = new Tuple<bool, int>(true, 2);
        casesJouables[4, 0] = new Tuple<bool, int>(true, 3);
        casesJouables[5, 0] = new Tuple<bool, int>(true, 4);
        casesJouables[6, 0] = new Tuple<bool, int>(true, 5);
        casesJouables[7, 0] = new Tuple<bool, int>(true, 6);
        casesJouables[8, 0] = new Tuple<bool, int>(true, 7);
        casesJouables[9, 0] = new Tuple<bool, int>(true, 8);
        casesJouables[10, 0] = new Tuple<bool, int>(true, 9);
        casesJouables[11, 0] = new Tuple<bool, int>(true, 10);
        casesJouables[11, 1] = new Tuple<bool, int>(true, 11);
        casesJouables[11, 2] = new Tuple<bool, int>(true, 12);
        casesJouables[11, 3] = new Tuple<bool, int>(true, 13);
        casesJouables[11, 4] = new Tuple<bool, int>(true, 14);
        casesJouables[11, 5] = new Tuple<bool, int>(true, 15);
        casesJouables[11, 6] = new Tuple<bool, int>(true, 16);
        casesJouables[11, 7] = new Tuple<bool, int>(true, 17);
        casesJouables[11, 8] = new Tuple<bool, int>(true, 18);
        casesJouables[11, 9] = new Tuple<bool, int>(true, 19);
        casesJouables[11, 10] = new Tuple<bool, int>(true, 20);
        casesJouables[11, 11] = new Tuple<bool, int>(true, 21);
        casesJouables[11, 12] = new Tuple<bool, int>(true, 22);
        casesJouables[11, 13] = new Tuple<bool, int>(true, 23);
        casesJouables[11, 14] = new Tuple<bool, int>(true, 24);
        casesJouables[11, 15] = new Tuple<bool, int>(true, 25);
        casesJouables[10, 15] = new Tuple<bool, int>(true, 26);
        casesJouables[9, 15] = new Tuple<bool, int>(true, 27);
        casesJouables[8, 15] = new Tuple<bool, int>(true, 28);
        casesJouables[7, 15] = new Tuple<bool, int>(true, 29);
        casesJouables[6, 15] = new Tuple<bool, int>(true, 30);
        casesJouables[5, 15] = new Tuple<bool, int>(true, 31);
        casesJouables[4, 15] = new Tuple<bool, int>(true, 32);
        casesJouables[3, 15] = new Tuple<bool, int>(true, 33);
        casesJouables[2, 15] = new Tuple<bool, int>(true, 34);
        casesJouables[1, 15] = new Tuple<bool, int>(true, 35);
        casesJouables[0, 15] = new Tuple<bool, int>(true, 36);
        casesJouables[0, 14] = new Tuple<bool, int>(true, 37);
        casesJouables[0, 13] = new Tuple<bool, int>(true, 38);
        casesJouables[0, 12] = new Tuple<bool, int>(true, 39);
        casesJouables[0, 11] = new Tuple<bool, int>(true, 40);
        casesJouables[0, 10] = new Tuple<bool, int>(true, 41);
        casesJouables[0, 9] = new Tuple<bool, int>(true, 42);
        casesJouables[1, 9] = new Tuple<bool, int>(true, 43);
        casesJouables[2, 9] = new Tuple<bool, int>(true, 44);
        casesJouables[3, 9] = new Tuple<bool, int>(true, 45);
        casesJouables[4, 9] = new Tuple<bool, int>(true, 46);
        casesJouables[5, 9] = new Tuple<bool, int>(true, 47);
        casesJouables[6, 9] = new Tuple<bool, int>(true, 48);
        casesJouables[7, 9] = new Tuple<bool, int>(true, 49);
        casesJouables[7, 10] = new Tuple<bool, int>(true, 50);
        casesJouables[7, 11] = new Tuple<bool, int>(true, 51);
        casesJouables[6, 11] = new Tuple<bool, int>(true, 52);
        casesJouables[5, 11] = new Tuple<bool, int>(true, 53);
        casesJouables[4, 11] = new Tuple<bool, int>(true, 54);
        casesJouables[3, 11] = new Tuple<bool, int>(true, 55);
        casesJouables[2, 11] = new Tuple<bool, int>(true, 56);
        casesJouables[2, 12] = new Tuple<bool, int>(true, 57);
        casesJouables[2, 13] = new Tuple<bool, int>(true, 58);
        casesJouables[3, 13] = new Tuple<bool, int>(true, 59);
        casesJouables[4, 13] = new Tuple<bool, int>(true, 60);
        casesJouables[5, 13] = new Tuple<bool, int>(true, 61);
        casesJouables[6, 13] = new Tuple<bool, int>(true, 62);
        casesJouables[7, 13] = new Tuple<bool, int>(true, 63);
        casesJouables[8, 13] = new Tuple<bool, int>(true, 64);
        casesJouables[9, 13] = new Tuple<bool, int>(true, 65);
        casesJouables[9, 12] = new Tuple<bool, int>(true, 66);
        casesJouables[9, 11] = new Tuple<bool, int>(true, 67);
        casesJouables[9, 10] = new Tuple<bool, int>(true, 68);
        casesJouables[9, 9] = new Tuple<bool, int>(true, 69);
        casesJouables[9, 8] = new Tuple<bool, int>(true, 70);
        casesJouables[9, 7] = new Tuple<bool, int>(true, 71);
        casesJouables[9, 6] = new Tuple<bool, int>(true, 72);
        casesJouables[9, 5] = new Tuple<bool, int>(true, 73);
        casesJouables[9, 4] = new Tuple<bool, int>(true, 74);
        casesJouables[9, 3] = new Tuple<bool, int>(true, 75);
        casesJouables[8, 3] = new Tuple<bool, int>(true, 76);
        casesJouables[7, 3] = new Tuple<bool, int>(true, 77);
        casesJouables[6, 3] = new Tuple<bool, int>(true, 78);
        casesJouables[5, 3] = new Tuple<bool, int>(true, 79);
        casesJouables[4, 3] = new Tuple<bool, int>(true, 80);
        casesJouables[3, 3] = new Tuple<bool, int>(true, 81);
        casesJouables[2, 3] = new Tuple<bool, int>(true, 82);
        casesJouables[1, 3] = new Tuple<bool, int>(true, 83);
        casesJouables[0, 3] = new Tuple<bool, int>(true, 84);
        casesJouables[0, 4] = new Tuple<bool, int>(true, 85);
        casesJouables[0, 5] = new Tuple<bool, int>(true, 86);
        casesJouables[0, 6] = new Tuple<bool, int>(true, 87);
        casesJouables[0, 7] = new Tuple<bool, int>(true, 88);
        casesJouables[1, 7] = new Tuple<bool, int>(true, 89);
        casesJouables[2, 7] = new Tuple<bool, int>(true, 90);
        casesJouables[3, 7] = new Tuple<bool, int>(true, 91);
        casesJouables[4, 7] = new Tuple<bool, int>(true, 92);
        casesJouables[5, 7] = new Tuple<bool, int>(true, 93);
        casesJouables[6, 7] = new Tuple<bool, int>(true, 94);
        casesJouables[7, 7] = new Tuple<bool, int>(true, 95);
        casesJouables[7, 6] = new Tuple<bool, int>(true, 96);
        casesJouables[7, 5] = new Tuple<bool, int>(true, 97);
        casesJouables[6, 5] = new Tuple<bool, int>(true, 98);
        casesJouables[5, 5] = new Tuple<bool, int>(true, 99);
        casesJouables[4, 5] = new Tuple<bool, int>(true, 100);
        casesJouables[3, 5] = new Tuple<bool, int>(true, 101);
        casesJouables[2, 5] = new Tuple<bool, int>(true, 102);

        GenererPlateau();
    }

    /// <summary>
    /// Génère le pateau
    /// </summary>
    public void GenererPlateau()
    {
        for (int ligne = 0; ligne < nbLignes; ligne++)
        {
            for (int col = 0; col < nbColonnes; col++)
            {
                if (casesJouables[ligne, col] != null && casesJouables[ligne, col].Item1)
                {
                    GameObject nouvelleCase = Instantiate(modeleCase);
                    PlacerElement(nouvelleCase, this.gameObject, modeleCase, ligne, col);
                    if (casesJouables[ligne, col].Item2 == 0)
                    {
                        casesDepart.Add(nouvelleCase);
                    }
                    else
                    {
                        nouvelleCase.GetComponent<Case>().IdCase = casesJouables[ligne, col].Item2;
                        if (nouvelleCase.GetComponent<Case>().IdCase != 102)
                        {
                            nouvelleCase.GetComponent<Case>().gage = Gage.gages[random.Next(Gage.gages.Count)];
                            nouvelleCase.GetComponent<Renderer>().material.color = nouvelleCase.GetComponent<Case>().gage.color;
                        }
                        cases.Add(nouvelleCase);
                    }
                }
            }
        }
        // Trie la liste dans l'ordre des id
        cases = cases.OrderBy<GameObject, int>(c => c.GetComponent<Case>().IdCase).ToList();
    }

    /// <summary>
    /// Place un élément dans le jeu sous forme de quadrillage
    /// </summary>
    /// <param name="objectToPlace">Objet à placer</param>
    /// <param name="parent">Parent </param>
    /// <param name="objectSizeReference">Taille de l'objet de référence</param>
    /// <param name="row">Numéro de ligne</param>
    /// <param name="col">Numéro de colonne</param>
    /// <returns>Objet placé</returns>
    private GameObject PlacerElement(GameObject objectToPlace, GameObject parent, GameObject objectSizeReference, int row, int col)
    {
        objectToPlace.GetComponent<Transform>().SetParent(parent.GetComponent<Transform>());
        objectToPlace.GetComponent<Transform>().position = new Vector3(objectSizeReference.GetComponent<Renderer>().bounds.size.x * col, 0, objectSizeReference.GetComponent<Renderer>().bounds.size.z * row * -1);
        return objectToPlace;
    }
}
