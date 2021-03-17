using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallWizard : MonoBehaviour
{

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Enemies")
        {
            Destroy(gameObject);
        }
    }
}
