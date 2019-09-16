using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    [SerializeField] private GameObject subject;
    private List<GameObject> parents = new List<GameObject>();
    private List<Vector3> aDirections = new List<Vector3>();
    private int amount,high, deaths;
    private GameObject alfa, mutation;

    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        amount = players.Length;
        for (int i = 0; i < amount; i++)
        {
           parents.Add(players[i]);
           var casulties = parents[i].gameObject.transform.parent.GetComponentInChildren<Ball>();
           casulties.BallDies += StartProcces;
        }
        Debug.Log(amount);
    }

    void Update()
    {
        
    }

    private void StartProcces()
    {
        BallDead();
        if (deaths == amount)
        {
            for (int i = 0; i < amount; i++)
            {
              GameObject t = parents[i].gameObject;
              int y = t.gameObject.GetComponent<Brain>().getPoints();
                if (y <= high)
                {
                    y = high;
                    alfa = t;
                    Debug.Log("alfa " + alfa.transform.parent.gameObject.name);
                    Mutate();
                }
            }
        }
    }

    private void Mutate()
    {
        aDirections = alfa.GetComponent<Brain>().getPath();

        for (int i = 0; i < aDirections.Count; i++)
        {
            int t = Random.Range(0,100);
            if (t >= 5)
            {
                aDirections[i] = alfa.GetComponent<Brain>().getRandomPath();
            }
        }
        RePopulate();
    }

    public List<Vector3> getAlfaPath()
    {
        return aDirections;
    }

    private void RePopulate()
    {
        bool proccesed = false;
        if (!proccesed)
        {
            for (int i = 0; i < amount; i++)
            {
                Vector3 pos = parents[i].gameObject.transform.position;
                Destroy(parents[i].gameObject);
                Instantiate(subject, pos, Quaternion.identity);
            }
            proccesed = true;
        }
        
    }

    private void BallDead()
    {
        deaths++;
    }


}
