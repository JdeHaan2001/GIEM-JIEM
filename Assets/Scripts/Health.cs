using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI hpTMP;

    public int MaxHealth = 100;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = MaxHealth;
    }

    public void Heal(int hp)
    {
        if (currentHealth + hp > MaxHealth)
            currentHealth = MaxHealth;
        else
            currentHealth += hp;

        updateHealthUI();
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
        //hpTMP.text = currentHealth.ToString();
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
