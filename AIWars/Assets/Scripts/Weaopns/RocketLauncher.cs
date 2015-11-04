using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RocketLauncher : MonoBehaviour 
{
	public float acceleration = 2f;
	public float rateOfFire = 1f;
	public Rigidbody EquippedTo;
	
	private List<Transform> targets;
	private float shotDelay = 0f;
	
	void Awake()
	{
		targets = new List<Transform>();	
	}
	
	// Update is called once per frame
	void Update () 
	{


        if (targets.Count > 0)
        {

            if (targets[0].gameObject.activeSelf == false)
            {


                targets.Remove(targets[0]);
            }
        }
        if (shotDelay<=0)
		{
			if( targets.Count>0)
			{
				GameObject rocket = PoolManager.Instance.GetObjectForType("Rocket",false);
				Rocket script = rocket.GetComponent<Rocket>();
				script.acceleration = acceleration;
				script.ignoreCollider = EquippedTo.GetComponent<Collider>();
				rocket.GetComponent<Rigidbody>().velocity = (targets[0].position- transform.position).normalized;
				rocket.transform.position = transform.position;
				shotDelay = 1/rateOfFire;
			}
		}
		else
		{
			shotDelay -= Time.deltaTime;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other != EquippedTo.GetComponent<Collider>())
		{
			targets.Add(other.transform);	
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other != EquippedTo.GetComponent<Collider>())
		{
			targets.Remove(other.transform);
		}
	}
}
