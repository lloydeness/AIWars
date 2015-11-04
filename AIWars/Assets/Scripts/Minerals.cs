using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Minerals : MonoBehaviour {

    public int occupants = 0;
    public bool occupied = false;
    public Vector3 position { get; set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (occupants > 0)
        {
            occupied = true;

        }
	
	}
}
