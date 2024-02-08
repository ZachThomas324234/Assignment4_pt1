using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;

    public heal1 Heal1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Heal(5);
        }

        void TakeDamage(int damage)
        {
            Heal1.PlayerHealth -= damage;
            healthBar.fillAmount = Heal1.PlayerHealth / 100f;
        }

        void Heal(int healingAmount)
        {
            Heal1.PlayerHealth += healingAmount;
            Heal1.PlayerHealth = Mathf.Clamp(Heal1.PlayerHealth, 0, 100);

            healthBar.fillAmount = Heal1.PlayerHealth / 100f;
        }
        
    }
}
