using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapstrengh;
    public LogicScript logic;
    public static bool birdIsAlive = true; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && birdIsAlive)
        {
            myRigidBody.linearVelocity = Vector2.up * flapstrengh;
        }
        
        if (transform.position.y > 10.5f || transform.position.y < -10.5f)
        {
            logic.gameOver();
            birdIsAlive=false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
    
}
