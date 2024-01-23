using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraControl : MonoBehaviour {
 
    public float turnSpeed = 4.0f;
    public Transform player;
 
    private Vector3 offset;
 
    void Start()
    {
        offset = new Vector3(player.position.x, player.position.y, player.position.z);
    }
 
    void LateUpdate()
    {
        
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }
}