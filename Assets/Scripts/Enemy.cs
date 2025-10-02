using UnityEngine;
using System;

public class Enemy : MonoBehaviour, IDamageable
{
    public static event Action EnemyDied;

    [SerializeField] private int hitPoints = 5;

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        Debug.Log($"Enemy hit: {hitPoints} HP remaining");

        if(hitPoints <= 0)
        {
            Debug.Log("Enemy died");
            EnemyDied?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
