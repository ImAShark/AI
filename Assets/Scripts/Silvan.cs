using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silvan : MonoBehaviour
{
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Wall")
        {
            dir = Vector3.Reflect(dir, collision.GetContact(0).normal);
        }
    }
}
