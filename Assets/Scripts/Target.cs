using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionPS;

    public int pointValue;
    private float minForce;
    private float maxForce;
    private float maxTorque;
    private float maxXPos;
    private float yPos;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        minForce = 12;
        maxForce = 16;
        maxTorque = 10;
        maxXPos = 4;
        yPos = -2;

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            gameManager.UpdateScore(pointValue);
            Destroy(gameObject);
            Instantiate(explosionPS, transform.position, explosionPS.transform.rotation);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }    
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-maxXPos, maxXPos), yPos);
    }
}
