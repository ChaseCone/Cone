using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject player;
    public float speed;
    private GameObject gameManager;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
        gameManagerScript.updateEnemyCount(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            gameManagerScript.updateEnemyCount(0, 1);
            Destroy(gameObject);
        }
    }
}
