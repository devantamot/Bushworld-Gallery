using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This Class is for the first person controls when exporing the gallery  
 */
public class FPVController : MonoBehaviour {

    private float zdir, xdir, ydir;
    public float gravity = -9.8f;
    public float movementSpeed = 100f;
    private Transform trans;

	// Use this for initialization
	void Start () {
        trans = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * movementSpeed;
        float deltaZ = Input.GetAxis("Vertical") * movementSpeed;

        Vector3 movement = new Vector3(deltaX, 0, -deltaZ);
        Debug.Log("X: " + Input.GetAxis("Horizontal") + " Z: "+ Input.GetAxis("Vertical") + " FINE: "+movement);
        movement = Vector3.ClampMagnitude(movement, movementSpeed);
        //movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        trans.Translate(movement);
    }
}
