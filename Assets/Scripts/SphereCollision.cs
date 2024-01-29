using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    public int EnemyDamage = 15;
    public Heal health;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
        health.PlayerHealth -= EnemyDamage;
        Destroy(gameObject);
        }
    }
}
