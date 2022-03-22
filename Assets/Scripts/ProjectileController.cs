using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject target;
    private GameObject gameManager;
    private GameManager gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (target.transform.position - transform.position).normalized;
        transform.Translate(lookDirection * Time.deltaTime * 10, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            gameManagerScript.updateEnemyCount(0, 1);
            Destroy(target);
            Destroy(gameObject);
        }
    }
}
