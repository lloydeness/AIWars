using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MineralCount : MonoBehaviour
{


    float score;
    public Text Mineral;
    public int scoreInt;
    public WorkerControl workerControl;
    


    // Use this for initialization
    void Start()
    {

        setScore();


    }

    // Update is called once per frame
    void Update()
    {


        setScore();

    }



    void setScore()
    {

        Mineral.text = "Minerals: " + workerControl.resources;
    }

}
