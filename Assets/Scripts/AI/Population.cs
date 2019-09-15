using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Population : MonoBehaviour
{
    private List<GameObject> parents = new List<GameObject>();
    private List<Vector3> aDirections = new List<Vector3>();
    private int amount,high;
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

    }

    void Update()
    {
        
    }

    private void StartProcces()
    {
        
        if (amount == GameObject.FindGameObjectsWithTag("Player").Length)
        {
            for (int i = 0; i < amount; i++)
            {
              GameObject t = parents[i].gameObject;
              int y = t.gameObject.GetComponent<Brain>().getPoints();
                if (y <= high)
                {
                    y = high;
                    alfa = t;
                    Debug.Log("alfa " + alfa);
                }
            }
        }
    }


}
