using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    private List<Vector3> directions = new List<Vector3>();
    [SerializeField] private float timer = 1;
    [SerializeField] private float reset,y;
    private int step,yeetPoints;    

    void Awake()
    {
        reset = timer;
        y = transform.position.y;
    }

    void Update()
    {
        if (timer <= 0)
        {
            MoveRandomly(100);
            timer = reset;
        }
        else
        {
            timer = timer - Time.deltaTime;
        }
        
    }

    private void MoveRandomly(int times)
    {
        for (int i = 0; i < times; i++)
        {
            float random = Random.Range(-10, 10);
            Vector3 t = new Vector3(random, y, 0);
            directions.Add(t);
            gameObject.transform.position = t;
            step++;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            yeetPoints++;
        }
    }
}
