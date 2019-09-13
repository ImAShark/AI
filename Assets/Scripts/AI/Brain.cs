using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    private List<Vector3> directions = new List<Vector3>();
    [SerializeField] private float timer = 1;
    [SerializeField] private float reset,y,x;
    private int step,yeetPoints;
    private bool isDead = false;

    void Awake()
    {
        var myBall = gameObject.transform.parent.GetComponentInChildren<Ball>();
        myBall.BallDies += Die;
        reset = timer;
        y = transform.position.y;
        x = transform.position.x;
    }

    void Update()
    {
        if (!isDead)
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
                
    }

    private void MoveRandomly(int times)
    {
        for (int i = 0; i < times; i++)
        {
            float random = Random.Range(x - 9.5f, x + 9.5f);
            Vector3 t = new Vector3(random, y, 0);
            directions.Add(t);
            gameObject.transform.position = t;
            step++;
            if (isDead)
            {
                break;
            }
        }
    }

    private void Die()
    {
        isDead = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            yeetPoints++;
            Debug.Log("yeet " + yeetPoints);
        }
    }

    public int getPoints()
    {
        return yeetPoints;
    }

    public List<Vector3> getPath()
    {
        return directions;
    }
}
