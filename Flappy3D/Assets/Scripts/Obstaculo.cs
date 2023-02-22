using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Obstaculo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,-5);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < - 25f)
        {
            Destroy(gameObject);
        }
    }
}
