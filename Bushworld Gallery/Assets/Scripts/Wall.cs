using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Shape {

    public float twoDheight;
    public float threeDheight;

	// Use this for initialization
	void Start () {
        twoDheight = 0.01f;
        threeDheight = 5.0f;
        this.Ypos = 0.5f;
        this.Height = twoDheight;
        Debug.Log("WALL " + this.Height);       
        Debug.Log("WALL "+this.Ypos);
    }

    public void threeDify()
    {
        this.Ypos = threeDheight / 2;
        this.Height = threeDheight;
        Debug.Log(threeDheight+ " "+this.Ypos);
    }

    public void twoDify()
    {
        this.Height = twoDheight;
        this.Ypos = 0.5f;
    }
}
