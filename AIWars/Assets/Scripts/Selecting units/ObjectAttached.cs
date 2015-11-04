using UnityEngine;
using System.Collections;

public class ObjectAttached : MonoBehaviour {


    public WorkerBee worker;
    // Use this for initialization
    void Start() {
        worker = GetComponentInParent<WorkerBee>();
    }

    // Update is called once per frame
    void Update() {
        if (this.isActiveAndEnabled)
        {
            worker.isSelected = true;

        }
        else if (!this.isActiveAndEnabled)
        {
            worker.isSelected = false;
        }
    }


}
