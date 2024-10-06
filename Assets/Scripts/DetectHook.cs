using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHook : MonoBehaviour
{
    public bool HookHit { get; set; }
    private SphereCollider concrete;
    private BoxCollider hook;
    private Vector3 hookPoint;

    // Start is called before the first frame update
    void Start()
    {
        hook = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        hookPoint = transform.position + hook.center;

        if(HookHit)
        {
            concrete.transform.position = hookPoint;
            concrete.transform.rotation = transform.rotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        HookHit = true;
        concrete = other.gameObject.GetComponent<SphereCollider>();
    }
}
