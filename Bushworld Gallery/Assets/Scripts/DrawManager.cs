using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawManager : MonoBehaviour {

    public enum Drawing { Floor, Wall }

    public Canvas UICanvas; // This will allow the user to 
    private Drawing currentlyDrawing; // Determines what the user is currently drawing
    private Shape currentShape; // The current shape the user is drawing
    private ArrayList shapeList;

    private bool leftMousePressed;
    private bool rightMousePressed;

    private float LinitMouseX, LinitMouseZ;
    private float LfinMouseX, LfinMouseZ;

    //These will be for when the user draws the floor and walls. 
    private Floor outlineFloor;
    private Wall outlineWall;
    public Floor refFloor;
    public Wall refWall;


	// Use this for initialization
	void Start () {
        shapeList = new ArrayList();
        DebugManager.Log("Created shapelist");
        outlineFloor = Instantiate<Floor>(refFloor);
        outlineFloor.gameObject.transform.SetParent(this.gameObject.transform);
        outlineFloor.gameObject.SetActive(false);
        outlineWall = Instantiate<Wall>(refWall);
        outlineWall.gameObject.transform.SetParent(this.gameObject.transform);
        outlineWall.gameObject.SetActive(false);
        currentShape = outlineFloor;
    }
	
	// Update is called once per frame
	void Update () {

        //TODO Check if the mouse is clicking on a button instead of trying to draw

        //When the user presses down on the LEFT mouse ALso makes sure that the mouse is not over a UI element
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            leftMousePressed = true;
            LinitMouseX = Input.mousePosition.x;
            LinitMouseZ = Input.mousePosition.y;
            DebugManager.Log("Left Mouse Pressed at: "+LinitMouseX + ", " + LinitMouseZ);
            currentShape.gameObject.SetActive(true);
        }

        //Once the LEFT mouse button has been pressed (Being dragged)
        if (leftMousePressed && Input.GetMouseButton(0))
        {
            currentShape.Xpos = Input.mousePosition.x;
            currentShape.Zpos = Input.mousePosition.y;
            Debug.Log("X: " + Input.mousePosition.x + " Z: "+Input.mousePosition.y);
            currentShape.Length = (LinitMouseX - Input.mousePosition.x)/100;
            currentShape.Width = (LinitMouseZ - Input.mousePosition.y)/100;
        }

        //When the user relsease the LEFT mouse button 
        if (Input.GetMouseButtonUp(0))
        {
            LfinMouseX = Input.mousePosition.x;
            LfinMouseZ = Input.mousePosition.y;
            DebugManager.Log("Left Mouse Released at: " + LfinMouseX + ", " + LfinMouseZ);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed right click.");
        }

    }

    public void setDrawingTo(string d) {

        if (d.Equals("Wall"))
        {
            currentlyDrawing = Drawing.Wall;
            currentShape = outlineWall;
        }
        else if (d.Equals("Floor"))
        {
            currentlyDrawing = Drawing.Floor;
            currentShape = outlineFloor;
        }
        DebugManager.Log("Set Drawing to: " + d);
    }

    private Shape getCurrentDrawing()
    {
        if (currentlyDrawing == Drawing.Floor)
            return outlineFloor;
        else
            return outlineWall;
    }
}
