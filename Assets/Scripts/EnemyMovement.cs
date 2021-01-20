using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 400;
    private Vector3 playerPos;
    private Rigidbody2D rb;

    // Has the enemy entered the screen?
    private bool isOnScreen = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        Vector3 targetDir = (playerPos - transform.position);
        Vector3 moveDir = new Vector3(targetDir.x + Random.Range(-2.0f, 2.0f), targetDir.y + Random.Range(-2.0f, 2.0f), targetDir.z).normalized;
        
        rb.velocity = moveDir * speed * Time.fixedDeltaTime;

    }

    void OnBecameVisible()
    {
        isOnScreen = true;
    }

    void OnBecameInvisible()
    {
        if (isOnScreen)
        {
            Destroy(gameObject);
        }
    }
}
