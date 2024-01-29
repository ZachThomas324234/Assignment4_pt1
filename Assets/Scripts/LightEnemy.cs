using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnemy : MonoBehaviour
{
    public SphereCollision enemyDamage;
    public Heal health;
    public Heal enemyMaxHealth;
    public Heal enemyHealth;
    public Heal playerDamage;


    private void OnCollisionEnter(Collision collision)
    {
    if (collision.collider.CompareTag("Player"))
    {
    health.PlayerHealth -= enemyDamage.EnemyDamage;
    }

    if (collision.collider.CompareTag("Bullet"))
    {
    enemyHealth.EnemyHealth -= playerDamage.PlayerDamage;
    }
    }

    void Update()
    {
    if (enemyHealth.EnemyHealth < 1)
        {
        Destroy(gameObject);
        }
    }
}
