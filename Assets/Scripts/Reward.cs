using UnityEngine;

public class Reward : MonoBehaviour
{
    public Player score;
    private void Start()
    {
        score = GameObject.FindAnyObjectByType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score.OnScore();
        Destroy(gameObject);
    }
}
