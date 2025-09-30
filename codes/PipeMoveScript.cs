using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    public float MoveSpeed = 5;
    public float DeadZone = -30;
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * LogicScript.currentPipeSpeed * Time.deltaTime; ;
        if (transform.position.x < DeadZone)
        {
            Debug.Log("Deleted");
            Destroy(gameObject);
        }
    }
}
