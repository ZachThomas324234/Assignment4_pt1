using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class heal1 : MonoBehaviour
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
    public int EnemylightMaxHealth = 30;
    public int EnemylightHealth = 30;
    public int EnemymidMaxHealth = 55;
    public int EnemymidHealth = 55;
    public int EnemylargeHealth = 80;
    public int EnemylargeMaxHealth = 80;

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

    //graphics
    public TextMeshProUGUI meatDisplay;
    public TextMeshProUGUI healthDisplay;
    public Image healthBar;
    
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
        Heal(30);
        yield return new WaitForSeconds(0.5f);
        chicken.SetActive(false);
        isEating = false;
    }

    void Heal(int HealAmount)
        {
            PlayerHealth += HealAmount;
            PlayerHealth = Mathf.Clamp(PlayerHealth, 0, 100);

            healthBar.fillAmount = PlayerHealth / 100f;
        }

    //update is called once per frame
    void Update()
    {
        //set ammo display, if it exists :D
        if (meatDisplay != null)
            meatDisplay.SetText(MeatAmount + " / " + MeatAmountMax);
        
        //set ammo display, if it exists :D
        if (healthDisplay != null)
            healthDisplay.SetText(PlayerHealth + " / " + PlayerMaxHealth);

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
        if (MeatAmount < 0)
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
