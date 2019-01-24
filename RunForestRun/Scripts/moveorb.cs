
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveorb : MonoBehaviour {

    public KeyCode moveL;
    public KeyCode moveR;
    public KeyCode jump;

    public AudioClip impact;
    AudioSource somesound;


    
    public float horizVel = 0;
    public int laneNum = 2;
    public string controlLocked = "n";
    
    public Transform boomObj;

    public int forceConst = 50;
 
    private Rigidbody selfRigidbody;
 
 
 
    
    // Use this for initialization
	void Start () {
		
        somesound = GetComponent<AudioSource>();
        selfRigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        
        //Handle ball rotation
        float rotation = Input.GetAxis("Horizontal") * 100;
        rotation *= Time.deltaTime;
        selfRigidbody.AddRelativeTorque(Vector3.back * rotation);
        
        GetComponent<Rigidbody>().velocity = new Vector3(horizVel, GM.vertVel, PlayerPrefs.GetFloat("sensivityVelocity"));
        
       
        //Temple Run 'like lane movemenets
        GetComponent<Rigidbody>().transform.position =  new Vector3(0,1,gameObject.transform.position.z);
        if (Input.GetKey(moveL)){
            somesound.Play();
            GetComponent<Rigidbody>().transform.position =  new Vector3(-1,1,gameObject.transform.position.z);

        }

        if(Input.GetKey(moveR)){
            somesound.Play();
            GetComponent<Rigidbody>().transform.position =  new Vector3(1,1,gameObject.transform.position.z);

        }
       
        //Subway Surf 'like lane movemenets
        /* if (Input.GetKeyDown(moveL) && (laneNum > 1) && (controlLocked == "n"))
        {
            somesound.Play();
            horizVel = -2;
            StartCoroutine(stopSlide());
            laneNum -= 1;
            controlLocked = "y";
        }

        if (Input.GetKeyDown(moveR) && (laneNum < 3) && (controlLocked == "n")) 
        {
            
            somesound.Play();
            horizVel = +2;
            StartCoroutine(stopSlide());
            laneNum += 1;
            controlLocked = "y";
        }
        */
        
    
	}

    void FixedUpdate()
    {
        //Not working jump
         if(Input.GetKeyDown(jump)){
            Debug.Log("Space is pressed!");
            Vector3 jump = new Vector3 (0.0f, 2000000.0f, 0.0f);
            GetComponent<Rigidbody>().AddForce (jump);
            Debug.Log("Space is done!");
        }
        
    }


    //Pre-existing function for collision-action
    void OnCollisionEnter(Collision other) {


        
    
    }

    void OnTriggerEnter(Collider other) {

        
        if (other.gameObject.tag == "lethal") {
        
            StartCoroutine(WaitAndDoSomething()); 
            gameObject.SetActive(false);
            GM.zVelAdj = 0;
            Instantiate(boomObj, transform.position, boomObj.rotation);
            GM.lvlCompStatus = "Fail";
            SceneManager.LoadScene(1);
        
        }

        if (other.gameObject.name == "rampbottomtrig") {
            
            GM.vertVel = 2;
        }

        if (other.gameObject.name == "ramptoptrig")
        {

            GM.vertVel = 0;
        }

        if (other.gameObject.name == "exit")
        {

            SceneManager.LoadScene("LevelComp");
        }

        if ( other.gameObject.name == "Watermelon(Clone)"){
            Destroy(other.gameObject);
            GM.watermelonTotal += 1;
        }

        if (other.gameObject.name == "Banana(Clone)") {

            Destroy(other.gameObject);
            GM.bananaTotal += 1;
        }

          if (other.gameObject.name == "Coin(Clone)")
        {
            GM.lvlCompStatus = "Success";
            Destroy(other.gameObject);
            GM.coinTotal += 1;
        }

      
    }

    IEnumerator stopSlide() {

        yield return new WaitForSeconds(.5f);

        horizVel = 0;
        
        controlLocked = "n";
    }

    IEnumerator WaitAndDoSomething() {
        yield return new WaitForSeconds(2);
        // do something
        
}
}
