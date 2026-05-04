using System;
using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxhealth = 100;
    public float health { get; private set; }
    private bool canReceiveDamage = true;
    public float invincibilitytimer = 1;

    public delegate void HealthChangedHandler(float newHealth, float amountChanged);
    public event HealthChangedHandler OnHealthChanged;

    public delegate void HealthInitialised(float newHealth);
    public event HealthInitialised OnHealthInitialised;

    private void Start()
    {
        health = maxhealth;
        OnHealthInitialised?.Invoke(health);
        Debug.Log("Invoke");
    }

    public void ReceiveDamage(int amount, Vector3 origin)
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddDamage(float damage)
    {
        if (canReceiveDamage)
        {
            health -= damage;
            OnHealthChanged?.Invoke(health, -damage);
            canReceiveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilitytimer, ResetInvincibility));
        }
        Debug.Log(health);
    }

    IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    private void ResetInvincibility()
    {
        canReceiveDamage = true;
    }
    public void AddHealth(float healthToAdd)
    {
        health += healthToAdd;
        OnHealthChanged?.Invoke(health, healthToAdd);
        Debug.Log(health);
    }
}