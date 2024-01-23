using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
        transform. position = new Vector3(1.0f, 15.0f, 1.0f);
        }
    }
}
