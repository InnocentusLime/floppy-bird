using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float shellSize;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float flySpeed;
    [SerializeField] private float pull;
    [SerializeField] private bool isInvulnerable;

    private float speed;
    private Collider2D mCollider;
    private Transform mTransform;
    private RaycastHit2D[] hits; 
    private int score;

    public void OnScore()
    {
        Debug.Log("Reward!");
        score++;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mCollider = GetComponent<Collider2D>();
        mTransform = mCollider.transform;
        hits = new RaycastHit2D[3];
        speed = 0.0f;
    }

    public void OnFly(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }
        speed = -flySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        speed += acceleration * Time.deltaTime;
        speed = Mathf.Min(speed, maxSpeed);
        if (speed < 0.0) 
        {
            speed += pull * Time.deltaTime;
        }

        float distance = speed * Time.deltaTime;

        int hitCount = mCollider.Cast(Vector2.down, hits, distance);
        foreach (RaycastHit2D hit in hits.Take(hitCount))
        {
            distance = Mathf.Min(distance, hit.distance - shellSize);
        }
        mTransform.localPosition += (Vector3)(distance * Vector2.down);
        if (hitCount != 0 && !isInvulnerable)
        {
            speed = 0.0f;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Debug.Log(string.Format("You died! Score: {0}", score));
    }
}
