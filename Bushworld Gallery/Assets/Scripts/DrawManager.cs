using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawManager : MonoBehaviour {

    private int numWall;
    private int numFloor;

    public enum Drawing { Floor, Wall, Nothing }

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

    public Camera camera; // used for ray casting
    private RaycastHit hitCanvas;
    private Ray canvasRay;

	// Use this for initialization
	void Start () {

        numFloor = 0;
        numWall = 0;

        shapeList = new ArrayList();
        DebugManager.Log("Created shapelist");

        outlineWall = Instantiate<Wall>(refWall);
        outlineWall.gameObject.transform.SetParent(this.gameObject.transform);
        outlineWall.gameObject.SetActive(false);

        outlineFloor = Instantiate<Floor>(refFloor);
        outlineFloor.gameObject.transform.SetParent(this.gameObject.transform);
        outlineFloor.gameObject.SetActive(false);

        currentShape = outlineFloor;
    }

    void Update () {

        //TODO Check if the mouse is clicking on a button instead of trying to draw
        if (EventSystem.current.IsPointerOverGameObject() == false && currentlyDrawing != Drawing.Nothing)
        {
            //When the user presses down on the LEFT mouse ALso makes sure that the mouse is not over a UI element
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                leftMousePressed = true;

                currentShape.gameObject.SetActive(true);

                canvasRay = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(canvasRay, out hitCanvas))
                {

                    LinitMouseX = hitCanvas.point.x;
                    LinitMouseZ = hitCanvas.point.z;

                    currentShape.Length = 0;
                    currentShape.Width = 0;

                    currentShape.Xpos = hitCanvas.point.x;
                    currentShape.Zpos = hitCanvas.point.z;

                    //Debug.Log("POINT" + hitCanvas.point);
                }

            }

            //Once the LEFT mouse button has been pressed (Being dragged)
            if (leftMousePressed && Input.GetMouseButton(0))
            {
                canvasRay = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(canvasRay, out hitCanvas))
                {

                    currentShape.Length = (hitCanvas.point.x - LinitMouseX + currentShape.Length / 2) / this.transform.localScale.x;
                    currentShape.Width = (hitCanvas.point.z - LinitMouseZ + currentShape.Width / 2) / this.transform.localScale.z;

                    currentShape.Xpos = (hitCanvas.point.x + LinitMouseX) / 2;
                    currentShape.Zpos = (hitCanvas.point.z + LinitMouseZ) / 2;

                    //Debug.Log("POINT" + hitCanvas.point);
                }

            }

            //When the user relsease the LEFT mouse button 
            if (Input.GetMouseButtonUp(0))
            {
                canvasRay = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(canvasRay, out hitCanvas))
                {

                    currentShape.Length = (hitCanvas.point.x - LinitMouseX + currentShape.Length / 2) / this.transform.localScale.x;
                    currentShape.Width = (hitCanvas.point.z - LinitMouseZ + currentShape.Width / 2) / this.transform.localScale.z;

                    currentShape.Xpos = (hitCanvas.point.x + LinitMouseX) / 2;
                    currentShape.Zpos = (hitCanvas.point.z + LinitMouseZ) / 2;

                    Shape newShape = Instantiate(currentShape);
                    newShape.gameObject.transform.SetParent(this.gameObject.transform);
                    newShape.copyShape(currentShape);

                    if (currentlyDrawing == Drawing.Floor)
                    {
                        newShape.name = "Floor #" + ++numFloor;
                    }
                    else
                    {
                        newShape.name = "Wall #" + ++numWall;
                    }

                    shapeList.Add(newShape);

                    currentShape.gameObject.SetActive(false);
                    //Debug.Log("POINT" + hitCanvas.point);
                }

                leftMousePressed = false;

                //DebugManager.Log("Left Mouse Released at: " + LfinMouseX + ", " + LfinMouseZ);
            }

            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Pressed right click.");
            }
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

    public void threeDifiy()
    {
        currentlyDrawing = Drawing.Nothing;
        for(int i=0; i < shapeList.Count; i++)
        {
            if(shapeList[i] is Wall)
            {
                ((Wall)shapeList[i]).threeDify();
            }
            else
            {
                ((Floor)shapeList[i]).threeDify();
            }
        }
    }

    public void twoDifiy()
    {
        currentlyDrawing = Drawing.Wall;
        for (int i = 0; i < shapeList.Count; i++)
        {
            if (shapeList[i] is Wall)
            {
                ((Wall)shapeList[i]).twoDify();
            }
            else
            {
                ((Floor)shapeList[i]).twoDify();
            }
        }
    }

    private Shape getCurrentDrawing()
    {
        if (currentlyDrawing == Drawing.Floor)
            return outlineFloor;
        else
            return outlineWall;
    }
}
