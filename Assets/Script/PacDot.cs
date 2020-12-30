using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDot
{
    private static PacDot instance;
    private PacDot() { }

    public static PacDot Instance()
    {
        if (instance == null)
        {
            instance = new PacDot();
        }
        return instance;
    }

    public GameObject GenerateObj()
    {
        GameObject obj = GameObject.Instantiate(Resources.Load("PacDot")) as GameObject;
        return obj;
    }
}