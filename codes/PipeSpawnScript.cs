using UnityEngine;
using UnityEngine.UIElements;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public static float spawnRate = 4f;
    private float timer = 0;
    public float heightoffset = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightoffset;
        float highestPoint = transform.position.y + heightoffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }

    public static void ResetSpawnTimer()
    {
        // Find all PipeSpawnScript instances and reset their timers
        foreach (var spawner in FindObjectsByType<PipeSpawnScript>(FindObjectsSortMode.None))
        {
            spawner.timer = 0f;
        }
    }
}
