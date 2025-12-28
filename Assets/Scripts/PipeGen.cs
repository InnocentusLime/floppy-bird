using UnityEngine;

public class PipeGen : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnFrequency;

    private float spawnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTime <= 0.0f) {
            Vector2 spawnPos = transform.localPosition;
            spawnPos.y += RandomOffset(3);
            Instantiate(pipePrefab, (Vector3)(spawnPos), Quaternion.identity);
            spawnTime = spawnFrequency;
            return;
        }
        spawnTime -= Time.deltaTime;
    }

    float RandomOffset(int level)
    {
        int choice = Random.Range(-level, level);
        return (float)choice / (float)level * 1.5f;
    }
}
