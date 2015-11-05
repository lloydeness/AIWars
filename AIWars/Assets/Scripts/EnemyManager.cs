using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{

    public EnemySensor sensor;
    public List<EnemyFighter> eFighter;
    public List<Transform> playerTargets;
    private bool isBuilt = false;

    private int initialObjectCount = 0;


    public
    // Use this for initialization
    void Start()
    {

    }




    // Update is called once per frame
    void Update()
    {
        sensorCleanup();
        if (playerTargets.Count == 0)
        {
            RemoveTargets();

        }
        if ( initialObjectCount != sensor.targets.Count)
        {

            //do what rebuild does,  without adding

            adjustTargets();

        }

      
        if (isBuilt == false) 
        {

            build();
        }






    }


    void adjustTargets()
    {
        eFighter.Clear();
        playerTargets.Clear();

        for (int i = 0; i < sensor.targets.Count; i++)
        {


            if (sensor.targets[i].tag == ("Enemy"))
            {

                eFighter.Add(sensor.targets[i].GetComponentInChildren<EnemyFighter>());
            }
            else if (sensor.targets[i].tag == ("Player"))
            {
                playerTargets.Add(sensor.targets[i].GetComponent<Transform>());

            }

        }



        for (int i = 0; i < eFighter.Count; i++)
        {
            float distance = 100000;
            Vector3 closestPatch;
            int tempObject = 0;
            closestPatch = new Vector3(1000, 1000, 1000);
            for (int j = 0; j < playerTargets.Count; j++)
            {
                Vector3 tempPatch = playerTargets[j].transform.position;



                if (Vector3.Distance(eFighter[i].transform.position, tempPatch) < distance)
                {
                    closestPatch = tempPatch;
                    distance = Vector3.Distance(eFighter[i].transform.position, closestPatch);
                    tempObject = j;
                }

            }


            if (playerTargets.Count > 0)
            {
                eFighter[i].seekTarget = playerTargets[tempObject].transform;
                eFighter[i].hasTarget = true;
            }
        }

      
        initialObjectCount = sensor.targets.Count;

    }


    void build()
    {


        for (int i = 0; i < sensor.targets.Count; i++)
        {


            if (sensor.targets[i].tag == ("Enemy"))
            {

                eFighter.Add(sensor.targets[i].GetComponentInChildren<EnemyFighter>());
            }
            else if (sensor.targets[i].tag == ("Player"))
            {
                playerTargets.Add(sensor.targets[i].GetComponent<Transform>());

            }

        }



        for (int i = 0; i < eFighter.Count; i++)
        {
            float distance = 100000;
            Vector3 closestPatch;
            int tempObject = 0;
            closestPatch = new Vector3(1000, 1000, 1000);
            for (int j = 0; j < playerTargets.Count; j++)
            {
                Vector3 tempPatch = playerTargets[j].transform.position;



                if (Vector3.Distance(eFighter[i].transform.position, tempPatch) < distance)
                {
                    closestPatch = tempPatch;
                    distance = Vector3.Distance(eFighter[i].transform.position, closestPatch);
                    tempObject = j;
                }

            }



            eFighter[i].seekTarget = playerTargets[tempObject].transform;
            eFighter[i].hasTarget = true;

        }

        isBuilt = true;
        initialObjectCount = sensor.targets.Count;

    }

    void sensorCleanup()
    {
        for (int i = 0; i < sensor.targets.Count; i++)
        {
            if (sensor.targets[i].gameObject.activeSelf == false && sensor.targets[i].tag == ("Enemy"))
            {
                sensor.targets.Remove(sensor.targets[i]);
                eFighter.Remove(eFighter[i]);
            }
            if (sensor.targets[i].gameObject.activeSelf == false && sensor.targets[i].tag == ("Player"))
            {
                sensor.targets.Remove(sensor.targets[i]);
                playerTargets.Remove(playerTargets[i]);
            }

        }
        

    }

    void RemoveTargets()
    {
        for (int i = 0; i < eFighter.Count; i++)
        {
            eFighter[i].hasTarget = false;

        }

    }

 


}




