using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    //target is referring to the player
    public Transform player;
    public float smoothing = 5f;

    private Vector3 difference;

    void Start()
    {
        // calculating distance of camera and player
        difference = transform.position - player.position;
    }

    // call every physics update
    void FixedUpdate()
    {
        // make camera follow the player according to the distance difference
        Vector3 targetCamPos = difference + player.position;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}