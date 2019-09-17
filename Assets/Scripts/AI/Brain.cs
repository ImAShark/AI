using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    private List<Vector3> directions = new List<Vector3>();
    private List<Vector3> alfaPath = new List<Vector3>();
    [SerializeField] private float timer = 1;
    private float reset,y,x;
    private int step,aStep,yeetPoints;
    private bool isDead = false, firstTime = false, hasAlfaPath = false;

    void Awake()
    {
        var myBall = gameObject.transform.parent.GetComponentInChildren<Ball>();
        myBall.BallDies += Die;
        reset = timer;
        
    }

    void Start()
    {
        alfaPath = GameObject.Find("PopulationController").GetComponent<Population>().getAlfaPath();
        if (alfaPath.Count == 0)
        {
            hasAlfaPath = false;
            firstTime = true;
        }
        else
        {
            hasAlfaPath = true;
            firstTime = false;
        }

        y = transform.position.y;
        x = transform.position.x;
    }

    void Update()
    {
        Move();
                
    }

    private void Move()
    {
        if (!isDead)
        {
            if (timer <= 0 && alfaPath.Count == 0 && hasAlfaPath)
            {
                MoveToVector();
                timer = reset;
            }
            else
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
                step = 0;
                break;
            }
        }
    }

    private void MoveToVector()
    {
        if (hasAlfaPath)
        {
            gameObject.transform.position = alfaPath[aStep];
            aStep++;
        }
    }

    private void Die()
    {
        isDead = true;
        firstTime = false;
    }

    public void SetAlfaPath(bool b, List<Vector3> p)
    {
        hasAlfaPath = b;
        alfaPath = p;
        isDead = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            yeetPoints++;
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

    public Vector3 getRandomPath()
    {
        float random = Random.Range(x - 9.5f, x + 9.5f);
        Vector3 t = new Vector3(random, y, 0);
        return t;
    }
}
