using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftParent : MonoBehaviour
{
    public Transform parent;
    protected Vector3 relativePosition;
    protected Quaternion relativeRotation;

    // Start is called before the first frame update
    void Start()
    {
        relativePosition = parent.InverseTransformPoint(transform.position);
        relativeRotation = Quaternion.Inverse(parent.rotation) * transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = parent.TransformPoint(relativePosition);
        transform.rotation = parent.rotation * relativeRotation;
    }
}
