using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plateau : MonoBehaviour
{
    public GameObject modeleCase;
    public int nbColonnes = 5;
    public int nbLignes = 4;
    public Tuple<bool, int>[,] casesJouables;
    private List<Case> cases = new List<Case>();

    // Start is called before the first frame update
    void Start()
    {
        casesJouables = new Tuple<bool, int>[nbLignes, nbColonnes];
        casesJouables[0, 0] = new Tuple<bool, int>(true, 1);
        casesJouables[1, 0] = new Tuple<bool, int>(true, 2);
        casesJouables[1, 1] = new Tuple<bool, int>(true, 3);
        casesJouables[2, 1] = new Tuple<bool, int>(true, 4);
        casesJouables[3, 1] = new Tuple<bool, int>(true, 5);
        casesJouables[3, 2] = new Tuple<bool, int>(true, 6);
        casesJouables[3, 3] = new Tuple<bool, int>(true, 7);
        casesJouables[3, 4] = new Tuple<bool, int>(true, 8);
        GenererPlateau();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenererPlateau()
    {
        for (int ligne = 0; ligne < nbLignes; ligne++)
        {
            for (int col = 0; col < nbColonnes; col++)
            {
                if (casesJouables[ligne, col] != null && casesJouables[ligne, col].Item1)
                {
                    cases.Add(new Case(casesJouables[ligne, col].Item2, PlacerElement(Instantiate(modeleCase), this.gameObject, modeleCase, ligne, col)));
                    // ;
                    // Instantiate(modeleCase, this.GetComponent<Transform>());
                    // Debug.Log($" Colonne : {col}, Ligne : {ligne}");
                }
            }
        }
    }

    
    private GameObject PlacerElement(GameObject objectToPlace, GameObject parent, GameObject objectSizeReference, int row, int col)
    {
        objectToPlace.GetComponent<Transform>().SetParent(parent.GetComponent<Transform>());
        objectToPlace.GetComponent<Transform>().position = new Vector3(objectSizeReference.GetComponent<Renderer>().bounds.size.x * col, 0, objectSizeReference.GetComponent<Renderer>().bounds.size.y * row * -1);
        return objectToPlace;
    }
}
