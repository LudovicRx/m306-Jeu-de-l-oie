using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompteurTour : MonoBehaviour
{
    public Text content;
    void Start() {
        content = this.gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Text>();
    }
}
