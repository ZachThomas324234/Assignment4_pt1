using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            SpawnWave();
        }
    }

    private void SpawnWave()
    {

    }
}

[System.Serializable]
public class Wave
{

}