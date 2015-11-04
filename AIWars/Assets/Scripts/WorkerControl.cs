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
    private bool isBuilt = false;
    private int random;



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

        int delete = bases.Count;
        int delete2 = Minerals.Count;





    }

    void build()
    {



        for (int i = 0; i < sensor.targets.Count; i++)
        {
            if (sensor.targets[i].tag == ("Mineral"))
            {
                Vector3 temp = sensor.targets[i].transform.position;
                Minerals.Add(temp);
                Mins.Add(sensor.targets[i].GetComponent<Minerals>());
                //Mins[i].position = temp;


            }
            if (sensor.targets[i].tag == ("Base"))
            {

                Vector3 temp = sensor.targets[i].transform.position;

                bases.Add(temp);
            }

        }



        for (int i = 0; i < workers.Count; i++)
        {


            random = addRandomPatch();



            do
            {
                random = addRandomPatch();
                bool deleteme1 = Mins[0].occupied;
                bool deleteme2 = Mins[1].occupied;
                bool deleteme3 = Mins[2].occupied;


            } while (Mins[random].occupied == true);






            Mins[random].occupants++;
            Mins[random].occupied = true;
            workers[i].mineralPatch = Minerals[random];
            workers[i].Base = bases[0];





        }



        isBuilt = true;
    }

    int addRandomPatch()
    {
        float temp = Random.Range(0, Minerals.Count);


        return (int)temp;

    }


}


