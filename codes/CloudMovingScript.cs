using UnityEngine;

public class CloudMovingScript : MonoBehaviour
{
    public float cloudMoveSpeed = 5f;
    public float DeadZone = -30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * cloudMoveSpeed * Time.deltaTime;
        if (transform.position.x < DeadZone)
        {
            Debug.Log("Cloud Deleted");
            Destroy(gameObject);
        }


    }
}
