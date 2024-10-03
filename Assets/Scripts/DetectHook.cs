using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHook : MonoBehaviour
{
    private bool hookHit = false;
    private SphereCollider concrete;
    private Vector3 hookPoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.hookPoint = this.transform.position + GetComponent<BoxCollider>().center;

        if(hookHit)
        {
            concrete.transform.position = hookPoint;
            concrete.transform.rotation = this.transform.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        this.hookHit = true;
        this.concrete = other.gameObject.GetComponent<SphereCollider>();
    }
}
