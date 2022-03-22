using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 1.0f;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    private float powerupStrength = 5.0f;
    public GameObject powerUpIndicator;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerFP = focalPoint.transform.transform.forward;
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(playerFP * forwardInput * speed);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, 1, 0);
        if (Input.GetKeyDown(KeyCode.Space) )//&& hasPowerup == true)
        {
            StartCoroutine(Jump());
        }
    }

    void spawnProjectiles()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy curr in enemies)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            ProjectileController controller = projectile.GetComponent<ProjectileController>();
            controller.target = curr.gameObject;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerCountdownRoutine());
        }
        
    }
    IEnumerator PowerCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    IEnumerator Jump()
    {
            while (transform.position.y < 4)
            {
                transform.Translate(0, 10 * Time.deltaTime, 0);
                Debug.Log("went up a frame");
                yield return null;
            }
            yield return null;
            while (transform.position.y > 1)
            {
                transform.Translate(0, -5 * Time.deltaTime, 0);
                Debug.Log("went down a frame");
                yield return null;
            }
            yield return null;
            spawnProjectiles();

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
