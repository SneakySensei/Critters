using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    public GameObject DeathParticle;

    private Vector3 screenBounds;
    private float playerWidth;
    private float playerHeight;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Player's RigidBody
        rb = GetComponent<Rigidbody2D>();

        // Calculate screen and player boundaries
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        playerWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        playerHeight = GetComponent<SpriteRenderer>().bounds.size.y / 2;

    }

    // Update is called once per frame
    void Update()
    {
        // Get user input
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Create unit direction vector from input
        Vector2 movementDirection = new Vector2(x, y).normalized;

        // Set player velocity in the direction of input
        rb.velocity = movementDirection * speed;
    }

    void LateUpdate()
    {
        // Restrict(Clamp) the player to screen boundaries
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, screenBounds.x * -1 + playerWidth, screenBounds.x - playerWidth);
        pos.y = Mathf.Clamp(pos.y, screenBounds.y * -1 + playerHeight, screenBounds.y - playerHeight);
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Detect collision: Play death animation, handle gameOver state, kill player.
        Debug.Log("DEAD");
        Instantiate(DeathParticle, transform.position, Quaternion.identity);

        Destroy(gameObject);
        GameController.handleGameOver();
    }
}
