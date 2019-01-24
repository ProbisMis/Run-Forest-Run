using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateGame : MonoBehaviour {

	public InputField coinField;
	public InputField bananaField;
	public InputField watermelonField;
	public InputField heartField;
	public InputField coinFieldR;
	public InputField bananaFieldR;
	public InputField watermelonFieldR;
	public InputField heartFieldR;

	public Slider sensivityVelocity;
	public Slider sensivityCollectibles;
	public Slider sensivityObstacles;
	public Slider sensivityPowerups;
	string Coin = "Coin";
	string CoinR = "CoinR";
	string Banana = "Banana";
	string BananaR = "BananaR";
	string Watermelon = "Watermelon";
	string WatermelonR = "WatermelonR";
	string Heart = "Heart";
	string HeartR = "HeartR";
  

    // Use this for initialization
    void Start () {
		

		sensivityCollectibles.maxValue = 20;
		sensivityCollectibles.minValue = 1;
		sensivityVelocity.maxValue = 10;
		sensivityVelocity.minValue = 1;

		if (PlayerPrefs.HasKey("sensivityCollectibles")){
			sensivityCollectibles.value = PlayerPrefs.GetFloat("sensivityCollectibles");
		}
		if (PlayerPrefs.HasKey(Coin))
			coinField.text = PlayerPrefs.GetInt(Coin).ToString();
		if (PlayerPrefs.HasKey(CoinR))
			coinFieldR.text = PlayerPrefs.GetInt(CoinR).ToString();
		if (PlayerPrefs.HasKey(Banana))
			bananaField.text = PlayerPrefs.GetInt(Banana).ToString();
		if (PlayerPrefs.HasKey(BananaR))
			bananaFieldR.text = PlayerPrefs.GetInt(BananaR).ToString();
		if (PlayerPrefs.HasKey(Watermelon))
			watermelonField.text = PlayerPrefs.GetInt(Watermelon).ToString();
		if (PlayerPrefs.HasKey(WatermelonR))
			watermelonFieldR.text = PlayerPrefs.GetInt(WatermelonR).ToString();
		if (PlayerPrefs.HasKey(Heart))
			heartField.text = PlayerPrefs.GetInt(Heart).ToString();
		if (PlayerPrefs.HasKey(HeartR))
			heartFieldR.text = PlayerPrefs.GetInt(HeartR).ToString();
			
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetFloat("sensivityCollectibles", sensivityCollectibles.value);
		PlayerPrefs.SetFloat("sensivityVelocity", sensivityVelocity.value);
		
	
	}

	 public void GoToNextPage()
    {	
		if (coinField.text != "")
			PlayerPrefs.SetInt(Coin,int.Parse(coinField.text));
		if (coinFieldR.text != "")
			PlayerPrefs.SetInt(CoinR,int.Parse(coinFieldR.text));
		
		if (bananaField.text != "")
			PlayerPrefs.SetInt(Banana,int.Parse(bananaField.text));
		if (bananaFieldR.text != "")
			PlayerPrefs.SetInt(BananaR,int.Parse(bananaFieldR.text));
		
		if (watermelonField.text != "")
			PlayerPrefs.SetInt(Watermelon,int.Parse(watermelonField.text));
		if (watermelonFieldR.text != "")
			PlayerPrefs.SetInt(WatermelonR,int.Parse(watermelonFieldR.text));
		
		if (heartField.text != ""){
			PlayerPrefs.SetInt(Heart,int.Parse(heartField.text));
		}
		if (heartFieldR.text != ""){
			PlayerPrefs.SetInt(HeartR,int.Parse(heartFieldR.text));
		}
			
        SceneManager.LoadScene(9);
    }

	public void deletePlayerPrefs(){

        PlayerPrefs.DeleteAll ();
    
	}

	public void playGame(){

       SceneManager.LoadScene(0);
    
	}

}
