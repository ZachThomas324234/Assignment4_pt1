using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timers : MonoBehaviour
{
    public float ChompTimer;

    private void ChompTimerFunction()
    {
        ChompTimer -= Time.deltaTime;
        if(ChompTimer <= 0f) ChompTimer = 0;
        return;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(ChompTimer > 0) ChompTimerFunction();
    }
}
