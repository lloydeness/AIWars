using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorkerControl : MonoBehaviour
{

    public Sensor sensor;
    public List<WorkerBee> workers;
    public List<Vector3> bases;
    public List<Vector3> Minerals;
    public List<Minerals> Mins;
    private int workerCount = 0;
    private bool isBuilt = false;
    private int objectsInSensor = 0;
 



    public
    // Use this for initialization
    void Start()
    {

    }




    // Update is called once per frame
    void Update()
    {



        if (isBuilt == false)
        {
            build();
        }


        if (objectsInSensor < sensor.targets.Count)
        {

            countWorkers();

        }



    }

    void build()
    {

        Mins.Clear();
        bases.Clear();
        workers.Clear();


        for (int i = 0; i < sensor.targets.Count; i++)
        {
            if (sensor.targets[i].tag == ("Mineral"))
            {
                Vector3 temp = sensor.targets[i].transform.position;
                Minerals.Add(temp);
                Mins.Add(sensor.targets[i].GetComponent<Minerals>());
                


            }
            if (sensor.targets[i].tag == ("Base"))
            {

                Vector3 temp = sensor.targets[i].transform.position;

                bases.Add(temp);
            }


            if (sensor.targets[i].tag == ("Worker"))
            {      

                workers.Add(sensor.targets[i].GetComponent<WorkerBee>());
            }

        }



        for (int i = 0; i < workers.Count; i++)
        {
            float distance = 100000;
            Vector3 closestPatch;
            int tempObject = 0;
            closestPatch = new Vector3(1000, 1000, 1000);
            for (int j = 0; j < Minerals.Count; j++)
            {
                Vector3 tempPatch = Mins[j].gameObject.transform.position;
                
              

                if (Vector3.Distance(workers[i].transform.position, tempPatch) < distance && Mins[j].occupied ==false)
                {
                    closestPatch = tempPatch;
                    distance = Vector3.Distance(workers[i].transform.position, closestPatch);                    
                    tempObject = j;
                }

            }




            Mins[tempObject].occupants++;
            Mins[tempObject].occupied = true;
            workers[i].mineralPatch = Mins[tempObject].transform.position;
            workers[i].Base = bases[0];
            workers[i].jobAssigned = true;





        }


        objectsInSensor = sensor.targets.Count;
        isBuilt = true;
        workerCount = workers.Count;
    }

    int addRandomPatch()
    {
        float temp = Random.Range(0, Minerals.Count);


        return (int)temp;

    }

    void countWorkers()
    {
        workerCount = 0;
        for (int i = 0; i < sensor.targets.Count; i++)
        {
            if (sensor.targets[i].tag == ("Worker"))
            {
                workerCount++;    
                if (workerCount > workers.Count)
                {
                    workers.Add(sensor.targets[i].GetComponent<WorkerBee>());
                    assignWork();
                }         
            }

        }
    }

    void assignWork()
    {

        for (int i = 0; i < workers.Count; i++)
        {
            if (workers[i].jobAssigned == false)
            {
                float distance = 100000;
                Vector3 closestPatch;
                int tempObject = 0;
                closestPatch = new Vector3(1000, 1000, 1000);



                for (int j = 0; j < Minerals.Count; j++)
                {

                    Vector3 tempPatch = Mins[j].gameObject.transform.position;



                    if (Vector3.Distance(workers[i].transform.position, tempPatch) < distance && Mins[j].occupied == false)
                    {
                        closestPatch = tempPatch;
                        distance = Vector3.Distance(workers[i].transform.position, closestPatch);
                        tempObject = j;
                    }


                }




                Mins[tempObject].occupants++;
                Mins[tempObject].occupied = true;
                workers[i].mineralPatch = Mins[tempObject].transform.position;
                workers[i].Base = bases[0];
                workers[i].jobAssigned = true;



            }
        }
    }



        void resetMineralsOccupied()
    {
        for (int i = 0; i < Mins.Count; i++)
        {

            Mins[i].occupants = 0;
            Mins[i].occupied = false;

        }


    }


}


