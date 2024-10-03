using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMath.UI;

public class CraneTowerController : MonoBehaviour
{
    public HoldableButton leftButton;
    public HoldableButton rightButton;
    private GameObject concrete;
    private float towerRotationOffset = 180.0f;
    private float rotationSpeed = 0.05f;
    [SerializeField] private bool rotateToConcrete = false;

    // Start is called before the first frame update
    void Start()
    {
        concrete = GameObject.Find("Concrete");
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateToConcrete)
        {
            RotateToConcrete();

            float angle = CalculateAngleToConcrete() - transform.rotation.eulerAngles.y;
            if (angle < 0.1f && angle > -0.1f)
            {
                rotateToConcrete = false;
                GameObject.Find("Trolley").GetComponent<TrolleyController>().SetMoveToConcrete(true);
            }
        }
    }
    
    void RotateToConcrete()
    {
        float angle = CalculateAngleToConcrete();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), rotationSpeed);
    }
    
    float CalculateAngleToConcrete()
    {
        return (-Mathf.Atan2(concrete.transform.position.z - transform.position.z, 
            concrete.transform.position.x - transform.position.x) * Mathf.Rad2Deg) + towerRotationOffset;
    }
    
    public void SetRotateToConcrete(bool rotateToConcrete)
    {
        this.rotateToConcrete = rotateToConcrete;
    }
}
