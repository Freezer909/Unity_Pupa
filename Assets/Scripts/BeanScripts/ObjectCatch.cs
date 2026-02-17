using System.Collections;
using TMPro;
using UnityEngine;

public class ObjectCatchScript : MonoBehaviour
{
    public float sizeIncrease = 0.5f;
    public float shrinkAmount = 0.3f;
    public float speedBoostAmount = 5f;
    public float boostDuration = 3f;

    SFX_Script sfx;
    public TMP_Text Points;
    private int currentScoreCount = 0;

    private CharacterControllerScript playerController;

    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();
        playerController = GetComponent<CharacterControllerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.IsChildOf(transform)) return;

        if (collision.CompareTag("PDonut"))
        {
            AddScore(1, collision.gameObject);
        }
        else if (collision.CompareTag("BDonut"))
        {
            AddScore(2, collision.gameObject);
            StartCoroutine(SpeedBoost());
        }

        else if (collision.CompareTag("Meteor"))
        {
            Destroy(collision.gameObject);
            transform.localScale -= new Vector3(shrinkAmount, shrinkAmount, 0);
            if (transform.localScale.x < 0.2f) transform.localScale = new Vector3(0.2f, 0.2f, 1);

            Hearts health = GetComponent<Hearts>();
            if (health != null) health.TakeDamage();

        }

        else if (collision.CompareTag("Weights"))
        {
            Destroy(collision.gameObject);
            sfx.PlaySFX(3);

            Hearts health = GetComponent<Hearts>();
            if (health != null) health.TakeDamage();

        }

        else if (collision.CompareTag("BowlingBall"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(playerController.StunPlayer(2.0f));

            Hearts health = GetComponent<Hearts>();
            if (health != null) health.TakeDamage();

        }

    }

    IEnumerator SpeedBoost()
    {
        playerController.moveSpeed += speedBoostAmount;
        yield return new WaitForSeconds(boostDuration);
        playerController.moveSpeed -= speedBoostAmount;
    }

    void AddScore(int amount, GameObject donut)
    {
        sfx.PlaySFX(3);
        Destroy(donut);
        currentScoreCount += amount;
        UpdateScoreText();
    }

    void UpdateScoreText() 
    { 
        Points.text = "Tavi punkti : " + currentScoreCount.ToString(); 
    }
}