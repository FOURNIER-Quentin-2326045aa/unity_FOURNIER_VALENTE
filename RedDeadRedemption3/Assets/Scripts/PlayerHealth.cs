using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public TMP_Text healthText;

    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = "HP : " + currentHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthText.text = "HP : " + currentHealth;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("Defaite");
    }
}
