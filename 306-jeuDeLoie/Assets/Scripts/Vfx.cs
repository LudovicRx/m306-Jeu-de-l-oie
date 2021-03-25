using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vfx : MonoBehaviour
{
    public int _position;
    GameObject _vfx;
    // Start is called before the first frame update

    //Constructeur
    public Vfx(int position, GameObject vfx){
        _vfx = vfx;
        _position = position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
