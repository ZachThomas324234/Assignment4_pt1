using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heal : MonoBehaviour
{
    //audio
    public AudioSource meat1audio;
    public AudioSource meat2audio;
    public AudioSource meat3audio;

    //healing
    public int PlayerMaxHealth = 100;
    public int PlayerHealth = 100;
    public int HealAmount = 30;
    public int MeatAmountMax = 3;
    public int MeatAmount = 3;

    //player damage
    public int PlayerDamage = 25;

    //enemy health
    public int EnemyMaxHealth = 25;

    //gameobjects
    public GameObject meat1;
    public GameObject meat2;
    public GameObject meat3;
    public GameObject chicken;
    public GameObject player;
    public GameObject sphere;

    //timers
    private Timers timers;

    //booleaans
    private bool isEating;

    //mouse
    public Mouse mouse;

    
    //start
    void Start()
    {
        chicken.SetActive(false);
    }


    //eat meat and heal "animation"
    private IEnumerator MeatDestroy()
    {
        isEating = true;
        MeatAmount -= 1;
        chicken.SetActive(true);
        meat1.SetActive(true);
        meat2.SetActive(true);
        meat3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        meat1audio.Play();
        meat1.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        meat2audio.Play();
        meat2.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        meat3audio.Play();
        meat3.SetActive(false);
        PlayerHealth += HealAmount;
        yield return new WaitForSeconds(0.5f);
        chicken.SetActive(false);
        isEating = false;
    }

    //update is called once per frame
    void Update()
    {
        //right click function
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
        if (MeatAmount > 0)
        {
            if (!isEating)
            {  
            StartCoroutine (MeatDestroy());
            }
        }  
        }
    
        //no meat = no heal
        if (MeatAmount < 1)
        {
        HealAmount = 0;
        }

        //health overdose
        if (PlayerHealth >= PlayerMaxHealth)
        {
        PlayerHealth = PlayerMaxHealth;
        }

        //no health = die
        if (PlayerHealth < 1)
        {
        SceneManager.LoadScene(1);
        mouse.ShowMouse();
        }
        }
}
