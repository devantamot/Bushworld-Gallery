using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : Shape {

    public float twoDheight;
    public float threeDheight;

    // Use this for initialization
    void Start()
    {
        twoDheight = 0.0001f;
        threeDheight = 0.25f;
        this.Height = twoDheight;
        
    }

    public void threeDify()
    {
        this.Height = threeDheight;
        this.Ypos = threeDheight / 2;
    }

    public void twoDify()
    {
        this.Height = twoDheight;
    }
}
