using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCredits : MonoBehaviour
{
   public GameObject camera;
    public GameObject credits;
    public GameObject fondCredits;
    // Start is called before the first frame update
    void Start()
    {
         credits.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, 70);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void OnMouseDown()
    {
       camera.GetComponent<Transform>().position = new Vector3(fondCredits.transform.position.x, fondCredits.transform.position.y,60);
    }
}
