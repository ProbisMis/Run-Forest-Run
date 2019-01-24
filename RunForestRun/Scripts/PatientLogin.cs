using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PatientLogin : MonoBehaviour {

    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginTherapist());
    }

    IEnumerator LoginTherapist()
    {
        string targetURL = "http://localhost:8080/RunForestRun/login.php";
        Debug.Log("Logining " + targetURL);


        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW(targetURL, form);
        yield return www;

        Debug.Log(www.text);
        if (www.text != "0")
        {
            DBManager.username = nameField.text;
            //DBManager.score = int.Parse(www.text.Split('\t')[1]); //pass score in second chuck
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        }
        else
        {
            Debug.Log("User login failed. Error #" + www.text);
        }


    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 3 && passwordField.text.Length >= 3);
    }
}
