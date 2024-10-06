using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftParent : MonoBehaviour
{
    public Transform parent;
    public Vector3 RelativePosition { get; set; }
    private Quaternion relativeRotation;

    // Start is called before the first frame update
    void Start()
    {
        RelativePosition = parent.InverseTransformPoint(transform.position);
        relativeRotation = Quaternion.Inverse(parent.rotation) * transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = parent.TransformPoint(RelativePosition);
        transform.rotation = parent.rotation * relativeRotation;
    }
}
