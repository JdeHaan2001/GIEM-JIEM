using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public HealthBar healthBar;

    public int MaxHealth = 100;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = MaxHealth;
    }

    public bool Heal(int hp)
    {
        if (currentHealth == MaxHealth) 
            return false;
        else if (currentHealth + hp > MaxHealth)
        {
            currentHealth = MaxHealth;
            updateHealthUI();
            return true;
        }
        else if (currentHealth < MaxHealth)
        {
            currentHealth += hp;
            updateHealthUI();
            return true;
        }
        else
            return false;
    }

    public void DealDamage(int dmg)
    {
        if (currentHealth - dmg <= 0)
        {
            currentHealth = 0;
            handleDeath();
        }
        else
            currentHealth -= dmg;

        updateHealthUI();
    }

    private void updateHealthUI()
    {
        healthBar.TakeDamage(currentHealth);
    }

    private void handleDeath()
    {
        SceneHandler.ReloadScene();
        resetHealth();
    }

    private void resetHealth()
    {
        currentHealth = MaxHealth;
        updateHealthUI();
    }
}
