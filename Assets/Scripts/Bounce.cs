using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float speed = 1, lastPos = 0, rot = -45;

    void Update()
    {
        transform.Translate( speed * Time.deltaTime, 0, 0);
        lastPos = transform.position.x;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (0 > transform.position.x)
        {
            rot =+ 90;
            transform.Rotate(0,0,45 + 90);
            Debug.Log("yeet");
        }
        else if (0 < transform.position.x)
        {
            rot =- 90;
            transform.Rotate(0,0, 45 - 90);
            Debug.Log("HEYO");
        }
        else
        {
            Debug.Log("oof");
        }

    }

}
