using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour {

    private float xpos, ypos, zpos, length, width, height;
	
	private void updatePosition()
    {
        transform.position = new Vector3(xpos, ypos, zpos);
    }

    private void updateScale()
    {
        transform.localScale = new Vector3(length, height, width);
    }

    public void copyShape(Shape obj)
    {
        this.Xpos = obj.Xpos;
        this.ypos = obj.Ypos;
        this.Zpos = obj.Zpos;
        this.Length = obj.Length;
        this.Width = obj.Width;
    }

    public float Xpos {
        get { return xpos; }
        set { xpos = value; updatePosition(); }
    }

    public float Ypos
    {
        get { return ypos; }
        set { ypos = value; updatePosition(); }
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
