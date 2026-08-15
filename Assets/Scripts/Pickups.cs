using UnityEngine;
using UnityEngine.UI;

public class Pickups : MonoBehaviour
{

    private int Score;
    public int ScoreAmount;

    public Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Gem")
        {
            Score += ScoreAmount;
            scoreText.text = "SCORE : " + Score;
            Destroy(collision.gameObject);
            Debug.Log(Score);
        }
    }
}
