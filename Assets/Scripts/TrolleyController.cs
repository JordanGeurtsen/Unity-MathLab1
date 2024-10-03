using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameMath;
public class TrolleyController : MonoBehaviour
{
    public GameObject nearLimit;
    public GameObject farLimit;
    private float railLength;
    [SerializeField] private bool moveToConcrete = false;

    // Start is called before the first frame update
    void Start()
    {
        // horizontal distance between nearLimit and farLimit
        railLength = Vector3.Distance(nearLimit.transform.position, farLimit.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToConcrete)
        {
            Vector3 concretePosition = GameObject.Find("Concrete").GetComponent<SphereCollider>().transform.position;   
            float interpolate = CalculateInterpolateToConcrete(concretePosition);
            transform.position = Vector3.Lerp(nearLimit.transform.position, farLimit.transform.position, interpolate);
        }
    }
    
    private float CalculateInterpolateToConcrete(Vector3 concretePosition)
    {
        Vector2 trolleyPosition = new Vector2(transform.position.x, transform.position.z);
        Vector2 concretePosition2D = new Vector2(concretePosition.x, concretePosition.z);
        Vector2 nearLimitPosition = new Vector2(nearLimit.transform.position.x, nearLimit.transform.position.z);
        Vector2 farLimitPosition = new Vector2(farLimit.transform.position.x, farLimit.transform.position.z);
        
        float distanceToNearLimit = Vector2.Distance(trolleyPosition, nearLimitPosition);
        float distanceToFarLimit = Vector2.Distance(trolleyPosition, farLimitPosition);
        float distanceToConcrete = Vector2.Distance(trolleyPosition, concretePosition2D);
        
        return distanceToConcrete / (distanceToNearLimit + distanceToFarLimit);
    }
    
    public void SetMoveToConcrete(bool moveToConcrete)
    {
        this.moveToConcrete = moveToConcrete;
    }
}
