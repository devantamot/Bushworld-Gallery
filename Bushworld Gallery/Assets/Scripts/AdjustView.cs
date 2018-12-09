using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustView : MonoBehaviour {

    private Camera camera;
    public DrawManager drawMan;
    public Canvas canvas;
    public FirstPersonController fpsc;

	// Use this for initialization
	void Start ()
    {
        camera = this.GetComponent<Camera>();
        fpsc.gameObject.SetActive(false);
	}
	
	public void setTo2DTopDown()
    {
        camera.gameObject.SetActive(true);
        fpsc.setCamera(false);
        fpsc.gameObject.SetActive(false);
        camera.transform.position = new Vector3(0f, 429.5f, 0f);
        camera.transform.rotation = Quaternion.Euler(90,0,0);
        camera.transform.localScale.Set(1, 1, 1);
        drawMan.twoDifiy();
        canvas.gameObject.transform.GetChild(0).gameObject.SetActive(true); // sets Floor button to be active
        canvas.gameObject.transform.GetChild(1).gameObject.SetActive(true); // sets Wall button to be active
    }

    public void setTo3DView()
    {
        camera.gameObject.SetActive(true);
        fpsc.setCamera(false);
        fpsc.gameObject.SetActive(false);
        camera.transform.position = new Vector3(482.8f, 458.3f, -241f);
        camera.transform.rotation = Quaternion.Euler(48.035f, -51.077f, -0.191f);
        camera.transform.localScale.Set(1, 1, 1);
        drawMan.threeDifiy();
        canvas.gameObject.transform.GetChild(0).gameObject.SetActive(false); // sets Floor button to be inactive
        canvas.gameObject.transform.GetChild(1).gameObject.SetActive(false); // sets Wall button to be inactive
    }

    public void setToFPV()
    {
        setTo3DView();
        fpsc.gameObject.SetActive(true);
        camera.gameObject.SetActive(false);
        fpsc.setCamera(true);
    }
}
