using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterAim : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.transform.position = new Vector3(Screen.width / 2, (Screen.height / 2), 0);

    }
}
