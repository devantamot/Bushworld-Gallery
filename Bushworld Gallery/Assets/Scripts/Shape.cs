using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    private float xpos, zpos, length, width, height;

	// Use this for initialization
	void Start () {
		
	}
	
	private void updatePosition()
    {
        this.gameObject.transform.position = new Vector3(xpos, 0, zpos);
    }

    private void updateScale()
    {
        this.gameObject.transform.localScale = new Vector3(length, 0.01f, width);
    }

    public void copyShape(Shape obj)
    {
        this.Xpos = obj.Xpos;
        this.Zpos = obj.Zpos;
        this.Length = obj.Length;
        this.Width = obj.Width;
    }

    public float Xpos {
        get { return xpos; }
        set { xpos = value; updatePosition(); }
    }

    public float Zpos
    {
        get { return zpos; }
        set { zpos = value; updatePosition(); }
    }

    public float Length
    {
        get { return length; }
        set { length = value; updateScale();  }
    }

    public float Width
    {
        get { return width; }
        set { width = value; updateScale(); }
    }

    public float Height
    {
        get { return height; }
        set { height = value; updateScale(); }
    }
}
