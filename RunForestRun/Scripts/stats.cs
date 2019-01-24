using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "Coin Total") {
            GetComponent<TextMesh>().text = "Coins collected: " + GM.coinTotal;
        }

        if (gameObject.name == "Banana Total") {
            GetComponent<TextMesh>().text = "Banana collected: " + GM.bananaTotal;
        }

        if (gameObject.name == "Watermelon Total") {
            GetComponent<TextMesh>().text = "Watermelon collected: " + GM.watermelonTotal;
        }

        if (gameObject.name == "Time")
        {
            GetComponent<TextMesh>().text = "Time taken: " + GM.timeTotal;
        }

        if (gameObject.name == "Run Status")
        {
            GetComponent<TextMesh>().text = GM.lvlCompStatus;
        }

	}
}
