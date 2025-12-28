using UnityEngine;
using UnityEngine.Assertions;

public class Pipe : MonoBehaviour
{
    [SerializeField] private Transform top;
    [SerializeField] private Transform bottom;
    [SerializeField] private Reward reward;
    [SerializeField] private float gap;
    [SerializeField] private float lifetime;
    [SerializeField] private float scrollSpeed;

    private float pipeSegmentSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Assert.AreApproximatelyEqual(top.transform.localScale.y, bottom.transform.localScale.y);
        pipeSegmentSize = top.transform.localScale.y;
        Destroy(gameObject, lifetime);

        top.transform.localPosition = (Vector3)((pipeSegmentSize + gap) / 2.0f * Vector2.up);
        bottom.transform.localPosition = (Vector3)((pipeSegmentSize + gap) / 2.0f * Vector2.down);
        reward.transform.localScale = new Vector3(1.0f, gap, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition -= (Vector3)(scrollSpeed * Time.deltaTime * Vector2.right);
    }
}
