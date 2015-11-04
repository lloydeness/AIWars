using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Collider ignoreCollider { get; set; }
    public ScriptableObject damage { get; set; }

    void OnTriggerEnter(Collider other)
    {
        if (other != ignoreCollider)
        {

             
            PoolManager.Instance.PoolObject(gameObject);
            if (other.tag == ("Player") || other.tag == ("Carrier"))
            {
                //other.gameObject.SetActive(false);
                
              
                }
          
        }
    }


    
}
