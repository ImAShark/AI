using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    [SerializeField] private GameObject subject;
    private List<GameObject> parents = new List<GameObject>();
    private List<Vector3> aDirections = new List<Vector3>();
    private int amount,high, deaths;
    private GameObject alfa;
    [SerializeField] private GameObject population;
    private bool proccesed = false;

    void Start()
    {
        Startup();
    }

    private void Startup()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        amount = players.Length;
        for (int i = 0; i < amount; i++)
        {
            parents.Add(players[i]);
            var casulties = parents[i].gameObject.transform.parent.GetComponentInChildren<Ball>();
            casulties.BallDies += StartProcces;
        }
    }

    private void StartProcces()
    {
        BallDead();
        proccesed = false;
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
        if (!proccesed)
        {
            for (int i = 0; i < amount; i++)
            {
                Vector3 pos = parents[i].gameObject.transform.parent.gameObject.transform.position;
                Destroy(parents[i].gameObject.transform.parent.gameObject);
                Instantiate(subject, pos, Quaternion.identity);
            }
            proccesed = true;
        }
        else if (proccesed)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            amount = players.Length;

            for (int i = 0; i < parents.Count; i++)
            {
                parents[i] = players[i];
            }
            ResetThis();
            
        }
        
    }

    private void BallDead()
    {
        deaths++;
    }

    private void ResetThis()
    {
        Instantiate(population,new Vector3(0,0,0), Quaternion.identity);
        Destroy(this.gameObject);
        Debug.Log(gameObject);
    }


}
