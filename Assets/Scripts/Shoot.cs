using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
 
    public GameObject BulletPrefab;
    public Transform FirePosition;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(BulletPrefab, FirePosition.position , Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(transform.right * 1000);
        }
    }
}