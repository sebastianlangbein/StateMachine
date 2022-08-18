using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElephantAi : MonoBehaviour
{
    public Text healthText;
    public Slider healthBar;
    public int health;
    public int maxHealth = 999;
    public Image bar;

    private void Start()
    {
        //can also use $"{health}" to convert to a string
        UpdateUI();
    }

    public void UpdateUI()
    {
        healthText.text = health.ToString();
        healthBar.value = health;
        bar.color = Color.Lerp(Color.red, Color.green, (float)health / maxHealth);
        if (health == 0)
        {
            bar.gameObject.SetActive(false);
        }
        else
        {
            bar.gameObject.SetActive(true);
        }
    }

    public void Damage(int damageAmount)
    {
        if (health - damageAmount < 0)
        {
            health = 0;
        }
        else
        {
            health -= damageAmount;
        }
        UpdateUI();
    }
    public void Heal(int healAmount)
    {
        if (health + healAmount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healAmount;
        }
        UpdateUI();
    }
}
