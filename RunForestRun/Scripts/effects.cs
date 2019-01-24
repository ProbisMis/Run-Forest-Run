using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effects : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "Banana(Clone)") { 
            transform.Rotate(0, 3, 0);
        }
        if (gameObject.name == "Coin(Clone)")
        {
            transform.Rotate(0, 0, 3);
        }

        if (gameObject.name == "Watermelon(Clone)")
        {
            transform.Rotate(0, 3, 0);
        }
       
	}
}
