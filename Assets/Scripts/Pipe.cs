using UnityEngine;
using UnityEngine.Assertions;

public class Pipe : MonoBehaviour
{
    [SerializeField] private Transform top;
    [SerializeField] private Transform bottom;
    [SerializeField] private float gap;
    [SerializeField] private float lifetime;

    private float pipeSegmentSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Assert.AreApproximatelyEqual(top.transform.localScale.y, bottom.transform.localScale.y);
        pipeSegmentSize = top.transform.localScale.y;
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition -= (Vector3)(1.5f * Time.deltaTime * Vector2.right);
        top.transform.localPosition = (Vector3)((pipeSegmentSize + gap) / 2.0f * Vector2.up);
        bottom.transform.localPosition = (Vector3)((pipeSegmentSize + gap) / 2.0f * Vector2.down);
    }
}
