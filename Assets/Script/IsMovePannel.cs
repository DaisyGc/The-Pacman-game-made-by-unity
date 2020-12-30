using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsMovePannel : MonoBehaviour
{
    //public GameObject moveObj;
    public GameObject Moveable;

    void Start()
    {
        Moveable.GetComponent<Transform>();
    }
    public void MovePannelPos()
    {
        Moveable.transform.Translate(new Vector3(0,10000,0));
    }
}
