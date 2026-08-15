using System.Collections;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHelth;
    public int damageAmount;

    public static PlayerHealth instance;
    public HealthBar healthBar;

    private SpriteRenderer sr;

    private Vector2 checkPoint;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHelth;
        healthBar.SetMaxHealth(currentHealth);
        sr=GetComponent<SpriteRenderer>();

        checkPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage()
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.6f);
        StartCoroutine(ResetAfterDelay());

        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    public void UpdatedCheckPoint(Vector2 pos)
    {
        checkPoint = pos;
    }

    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(1);
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);

    }

    public void Respawn()
    {
        currentHealth = maxHelth;
        healthBar.SetHealth(currentHealth);
        transform.position = checkPoint;
    }
}
