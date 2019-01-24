using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TherapistMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void GoToRegisterPatient()
    {

        SceneManager.LoadScene(7);
    }

    public void GoToChoosePatient()
    {

        SceneManager.LoadScene(8);
    }

    public void GoToCreate()
    {

        SceneManager.LoadScene(9);
    }

}
