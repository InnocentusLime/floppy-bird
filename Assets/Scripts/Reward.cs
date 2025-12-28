using UnityEngine;

public class Reward : MonoBehaviour
{
    public GameManager score;

    private void Start()
    {
        score = GameObject.FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score.OnScore();
        Destroy(gameObject);
    }
}
