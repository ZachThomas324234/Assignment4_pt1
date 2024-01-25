using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Heal : MonoBehaviour
{
    public AudioSource meat1audio;
    public AudioSource meat2audio;
    public AudioSource meat3audio;

    public int PlayerMaxHealth = 100;
    public int PlayerHealth = 100;
    public int HealAmount = 30;
    public int MeatAmountMax = 3;
    public int MeatAmount = 3;

    public int PlayerDamage = 25;

    public int EnemyMaxHealth = 25;

    public GameObject meat1;
    public GameObject meat2;
    public GameObject meat3;
    public GameObject chicken;
    public GameObject player;
    public GameObject sphere;

    private Timers timers;

    private bool isEating;

    public Mouse mouse;

    
    //Start
    void Start()
    {
        chicken.SetActive(false);
    }


    //Eat meat and heal "animation"
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

    //Update is called once per frame
    void Update()
    {
        //Right click function
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
    
        //No meat = no heal
        if (MeatAmount < 1)
        {
        HealAmount = 0;
        }

        //Health overdose
        if (PlayerHealth >= PlayerMaxHealth)
        {
        PlayerHealth = PlayerMaxHealth;
        }

        //No health = die
        if (PlayerHealth < 1)
        {
        SceneManager.LoadScene(1);
        mouse.ShowMouse();
        }
    }
}
