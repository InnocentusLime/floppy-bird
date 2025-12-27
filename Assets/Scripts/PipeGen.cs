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
            Instantiate(pipePrefab);
            spawnTime = spawnFrequency;
            return;
        }
        spawnTime -= Time.deltaTime;
    }
}
