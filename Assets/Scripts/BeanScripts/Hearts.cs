using UnityEngine;
using System.Collections.Generic;

public class Hearts : MonoBehaviour
{
    public List<GameObject> hearts;
    private int currentHealth;

    void Start()
    {
        ResetHealth();
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            hearts[currentHealth].SetActive(false);

            if (currentHealth <= 0)
            {

                transform.localScale = new Vector3(1f, 1f, 1f);

                FindFirstObjectByType<GameManager>().GameOver();
            }
        }
    }

    public void ResetHealth()
    {
        currentHealth = hearts.Count;

        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
    }
}