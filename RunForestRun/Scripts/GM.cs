using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public CapsuleCollider m_Collider;
    private float col_scale;
	public static float vertVel = 0;
    public static int coinTotal = 0;
    public static int bananaTotal = 0;

    public static int watermelonTotal = 0;
    public static float timeTotal = 0;
    public float waittoload = 0;

    public static float zScenePos = 4;

    public static float zVelAdj = 1;

    public static string lvlCompStatus = "";


    public Transform bbNoPit;
    public Transform bbPitMid;

    public Transform Coin;
    public Transform obstObj;

    public Transform rock01;
    public Transform rock02;

    public Transform capsuleObj;

    public Transform blockTreePath;
    public Terrain terrain;

    public Transform Avocado;
    public Transform Banana;
    public Transform Burger;
    public Transform Chips_Bag;
    public Transform Coconut;
    public Transform Donut;
    public Transform Fries;
    public Transform HotDog;
    public Transform Mushroom;
    public Transform Onion;
    public Transform Pepper;
    public Transform Pineapple;
    public Transform Pizza;
    public Transform Tacos;
    public Transform Tomato;
    public Transform Watermelon;
    public Transform Wine_Bottle;

    public Transform Log01;

    public int randNum;
    public int randNumPath;
    public int totalCollectibles;
    public int coinLTotal;
    public int coinRTotal;
    public int bananaLTotal;
    public int bananaRTotal;
    public int watermelonLTotal;
    public int watermelonRTotal;

    public Transform player;

    private List<Transform> activeTiles ;
    private float safeZone = 15f;
    // Use this for initialization
	void Start () {
        activeTiles = new List<Transform>();
        col_scale = PlayerPrefs.GetFloat("sensivityCollectibles");
        m_Collider.height = col_scale/40;
        m_Collider.radius = col_scale/40;
 
    


        totalCollectibles = 0;
        coinLTotal = 0;
        coinRTotal = 0;
        bananaLTotal = 0;
        bananaRTotal = 0;
        watermelonLTotal = 0;
        watermelonRTotal = 0;

        if (PlayerPrefs.HasKey("Coin")) {
            totalCollectibles += PlayerPrefs.GetInt("Coin");
            coinLTotal += PlayerPrefs.GetInt("Coin");
        }
            
        if (PlayerPrefs.HasKey("CoinR")) {
            totalCollectibles += PlayerPrefs.GetInt("CoinR");
            coinRTotal += PlayerPrefs.GetInt("CoinR");
        }
        
        if (PlayerPrefs.HasKey("Banana")) {
            totalCollectibles += PlayerPrefs.GetInt("Banana");
            bananaLTotal = PlayerPrefs.GetInt("Banana") ;
        }
            
         if (PlayerPrefs.HasKey("BananaR")) {
            totalCollectibles += PlayerPrefs.GetInt("BananaR");
            bananaRTotal = PlayerPrefs.GetInt("BananaR") ;
        }
        
        if (PlayerPrefs.HasKey("Watermelon")) {
            totalCollectibles += PlayerPrefs.GetInt("Watermelon");
            watermelonLTotal = PlayerPrefs.GetInt("Watermelon") ;
        }
        
        if (PlayerPrefs.HasKey("WatermelonR")) {
            totalCollectibles += PlayerPrefs.GetInt("WatermelonR");
            watermelonRTotal = PlayerPrefs.GetInt("WatermelonR") ;
        }

        if (PlayerPrefs.HasKey("Heart")) 
            totalCollectibles += PlayerPrefs.GetInt("Heart");
        if (PlayerPrefs.HasKey("HeartR")) 
            totalCollectibles += PlayerPrefs.GetInt("HeartR");
      zScenePos = 4;
      Debug.Log(totalCollectibles);
      
	}

   
	
	// Update is called once per frame
	void Update () {
        timeTotal += Time.deltaTime;
        
        float  difference = zScenePos - player.position.z;
        

        if (difference < 100)
        {
            
                randNum = Random.Range(0, 100); //likelihood of event to happen ex. if 1<x<5 do this if 5<x<6 do this.
                randNumPath = Random.Range(0, 5);
            if (randNum < 10 && randNum > 5) {

                if (PlayerPrefs.HasKey("Coin") && coinLTotal != 0) {
                totalCollectibles = totalCollectibles - 1;
                coinLTotal = coinLTotal -1 ;
                Instantiate(Coin, new Vector3(-1, 1, zScenePos), Coin.rotation);
                }         
            }

            if (randNum < 5 ) {

                if (PlayerPrefs.HasKey("CoinR") && coinRTotal != 0) {
                totalCollectibles = totalCollectibles - 1;
                coinRTotal = coinRTotal -1 ;
                Instantiate(Coin, new Vector3(1, 1, zScenePos), Coin.rotation);
                }         
            }

            if (randNum >10 && randNum <13)
            {
                Instantiate(Log01, new Vector3(-1, 1, zScenePos), Log01.rotation);
            }

            if (randNum > 13 && randNum < 23) {
                Instantiate(rock02, new Vector3(1, 1, zScenePos), rock02.rotation);
            }

            if (randNum >23 && randNum < 33)
            {
                if (PlayerPrefs.HasKey("Banana") && bananaLTotal != 0) {
                totalCollectibles = totalCollectibles - 1;
                bananaLTotal = bananaLTotal -1 ;
                Instantiate(Banana, new Vector3(-1, 1, zScenePos), Banana.rotation);
                }     
                
            }

             if (randNum >33 && randNum < 43)
            {
                if (PlayerPrefs.HasKey("BananaR") && bananaRTotal != 0) {
                totalCollectibles = totalCollectibles - 1;
                bananaRTotal = bananaRTotal -1 ;
                Instantiate(Banana, new Vector3(1, 1, zScenePos), Banana.rotation);
                }     
                
            }

             if (randNum >45 && randNum < 63)
            {
                if (PlayerPrefs.HasKey("Watermelon") && watermelonLTotal != 0) {
                totalCollectibles = totalCollectibles - 1;
                watermelonLTotal = watermelonLTotal -1 ;
                Instantiate(Watermelon, new Vector3(-1, 1, zScenePos), Watermelon.rotation);
                }     
                
            }

            if (randNum >63 && randNum < 73)
            {
                if (PlayerPrefs.HasKey("WatermelonR") && watermelonRTotal != 0) {
                totalCollectibles = totalCollectibles - 1;
                watermelonRTotal = watermelonRTotal -1 ;
                Instantiate(Watermelon, new Vector3(1, 1, zScenePos), Watermelon.rotation);
                }     
                
            }

            if (randNum > 75 && randNum < 80 )
            {
                Instantiate(rock01, new Vector3(0, 1, zScenePos), rock01.rotation);
            }

            if (randNum >80 && randNum <90)
            {
                Instantiate(Log01, new Vector3(1, 1, zScenePos), Log01.rotation);
            }

            if (randNum > 90 && randNum < 100) {
                Instantiate(rock02, new Vector3(-1, 1, zScenePos), rock02.rotation);
            }
            
           if (randNumPath < 4){
                Transform tile = Instantiate(blockTreePath, new Vector3(0, 0, zScenePos), blockTreePath.rotation);   
                activeTiles.Add(tile);
           } else {
                 Transform tile = Instantiate(bbPitMid, new Vector3(0, 0, zScenePos), bbPitMid.rotation);
                activeTiles.Add(tile);
           }
            
            if (player.position.z > safeZone){
                DeleteTile();
            }
            
            zScenePos += 12;

        }

        if (lvlCompStatus == "Fail") {

            waittoload += Time.deltaTime;
        }

        if (waittoload > 5) {
            Debug.Log("LevelComp accessed");
            SceneManager.LoadScene("LevelComp");

        }

	}
     private void DeleteTile (){

            Destroy (activeTiles [0].gameObject);
            activeTiles.RemoveAt(0);
        }
}
