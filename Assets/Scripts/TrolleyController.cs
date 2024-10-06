using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMath.Utils;
using UnityEngine.Diagnostics;

public class TrolleyController : MonoBehaviour
{
    public GameObject nearLimit;
    public GameObject farLimit;
    public float moveSpeed = 3f;
    [SerializeField] private bool moveToConcrete = false;
    
    private GameObject craneTower;
    private SphereCollider concrete;
    private SoftParent softParent;
    private CableController cableController;

    // Start is called before the first frame update
    void Start()
    {
        craneTower = GameObject.Find("Tower Crane");
        concrete = GameObject.Find("Concrete").GetComponent<SphereCollider>();
        softParent = GetComponent<SoftParent>();
        cableController = GameObject.Find("Cable").GetComponent<CableController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveToConcrete)
        {
            Vector3 concretePosition = concrete.transform.position;
            moveTrolley(new Vector3(concretePosition.x, transform.position.y, concretePosition.z));

            if (Position.Distance2D(transform.position, concretePosition) < 0.1f)
            {
                moveToConcrete = false;
                transform.position = new Vector3(concretePosition.x, transform.position.y, concretePosition.z);
                cableController.SetScaleToConcrete(true);
            }

            softParent.RelativePosition = softParent.parent.InverseTransformPoint(transform.position);
        }
    }

    private void moveTrolley(Vector3 target)
    {
        if (Get2DDistanceToCraneTower(target) < Get2DDistanceToCraneTower(nearLimit.transform.position))
        {
            target = nearLimit.transform.position;
        }
        else if (Get2DDistanceToCraneTower(target) > Get2DDistanceToCraneTower(farLimit.transform.position))
        {
            target = farLimit.transform.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    private float Get2DDistanceToCraneTower(Vector3 position)
    {
        return Position.Distance2D(position, craneTower.transform.position);
    }
    

    public void SetMoveToConcrete(bool moveToConcrete)
    {
        this.moveToConcrete = moveToConcrete;
    }
}