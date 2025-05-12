using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysicFix : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.IsSleeping())
        {
            rigidbody.WakeUp();
        }
    }
}
