using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        int divisor = GameObject.Find("Game Manager").GetComponent<GameManagerX>().destroyTime;
        float destroyTime = 4.5f / divisor;
        Destroy(gameObject, destroyTime); // destroy particle after 2 seconds
    }


}
