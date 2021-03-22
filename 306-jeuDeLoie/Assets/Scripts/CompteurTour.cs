using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompteurTour : MonoBehaviour
{
    public Text text;
    void Start() {
        text = this.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Text>();
    }
}
