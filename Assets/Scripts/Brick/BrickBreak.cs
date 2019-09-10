using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ball")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
