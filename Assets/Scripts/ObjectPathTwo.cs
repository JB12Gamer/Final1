using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPathTwo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I'm Working");
    }
    void Update()
    {
        if (BODai.boss == 0)
        {
            Debug.Log("Boss dead");
            Destroy(gameObject);
        }
    }
}
