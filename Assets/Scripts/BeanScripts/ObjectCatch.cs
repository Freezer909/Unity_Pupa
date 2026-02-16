using TMPro;
using UnityEngine;

public class ObjectCatchScript : MonoBehaviour
{
    public float sizeIncrease = 0.5f;
    public float massIncrease = 1f;
    private Rigidbody2D rb;
    SFX_Script sfx;

    private int currentScoreCount = 0;
    public TMP_Text Points;

    void Start()
    {
        sfx = FindFirstObjectByType<SFX_Script>();
        rb = GetComponent<Rigidbody2D>();
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
        }
        else if (collision.CompareTag("Enemy"))
        {
            sfx.PlaySFX(2);
            Destroy(collision.gameObject);

            Hearts health = GetComponent<Hearts>();
            if (health != null) health.TakeDamage();
        }
    }

    // Helper method to keep code clean
    void AddScore(int amount, GameObject donut)
    {
        sfx.PlaySFX(2);
        Destroy(donut);

        transform.localScale += new Vector3(sizeIncrease, sizeIncrease, 0);
        rb.mass += massIncrease;

        currentScoreCount += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        Points.text = "Tavi punkti : " + currentScoreCount.ToString();
    }
}