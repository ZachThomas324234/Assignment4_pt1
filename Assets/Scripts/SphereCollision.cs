using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    public int EnemyDamage = 15;
    public heal1 health;
    public HealthManager healthManager;
    public heal1 playerDamage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            TakeDamage(20);
            Destroy(gameObject);
        }
    }
        void TakeDamage(int damage)
        {
            playerDamage.PlayerHealth -= damage;
            healthManager.healthBar.fillAmount = playerDamage.PlayerHealth / 100f;
        }
}
