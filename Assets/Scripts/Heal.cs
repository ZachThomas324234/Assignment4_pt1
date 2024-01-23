using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public AudioSource audioData;

    public int PlayerMaxHealth = 100;
    public int PlayerHealth = 100;
    public int HealAmount = 30;
    public int MeatAmountMax = 3;
    public int MeatAmount = 3;

    public int PlayerDamage = 25;

    public int EnemyMaxHealth = 25;
    public int EnemyDamage = 15;

    private Timers timers;


    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                PlayerHealth += HealAmount;
                MeatAmount -= 1;
                if (MeatAmount > -1)
            {
                audioData.Play();
            }
            }
    
    
        
    if (MeatAmount < 1)
        {
        HealAmount = 0;
        }

        if (PlayerHealth >= PlayerMaxHealth)
        {
        PlayerHealth = PlayerMaxHealth;
        }
    }
}
