using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float shellSize;

    private Collider2D mCollider;
    private Transform mTransform;
    private RaycastHit2D[] hits;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mCollider = GetComponent<Collider2D>();
        mTransform = mCollider.transform;
        hits = new RaycastHit2D[3];
    }

    void OnFly(InputValue value)
    {
        Debug.Log("bruh");
    }

    // Update is called once per frame
    void Update()
    {
        int hitCount = mCollider.Cast(Vector2.down, hits, speed * Time.deltaTime);
        float distance = speed * Time.deltaTime;
        foreach (RaycastHit2D hit in hits.Take(hitCount))
        {
            distance = Mathf.Min(distance, hit.distance - shellSize);
        }
        mTransform.localPosition += (Vector3)(distance * Vector2.down);
        if (hitCount != 0)
        {
            Destroy(gameObject);
        }
    }
}
