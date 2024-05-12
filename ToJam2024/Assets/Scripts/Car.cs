using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour, IDamageable
{
    ExplodeJoints explodeJoints;
    

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        GameManager.OnKillAll += HandleKillAll;
        GameManager.SpawnCar(this);
        explodeJoints = GetComponent<ExplodeJoints>();
    }

    private void HandleKillAll()
    {
        Die();
    }

    public void TakeDamage(float damage)
    {
        
    }

    public void Die()
    {
        explodeJoints.DoExplodeJoints();
        Destroy(gameObject, 2);
    }

    private void OnDestroy()
    { 
        GameManager.OnKillAll -= HandleKillAll;
    }
}