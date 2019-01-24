using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject Sphere;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - Sphere.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if(Sphere == null){
            
        }
        else{
            Vector3 newPos = Sphere.transform.position + offset;
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        }


            }
}