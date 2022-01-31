using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 2f;
    public GameObject enemy;

    public void DamageReceived(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0f) {
            Debug.Log("Gamer over");
            DieEnemy();
        }
    }
    
    private void DieEnemy()
    {
        Destroy(gameObject);
    }

}
