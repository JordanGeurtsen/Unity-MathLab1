using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMath.UI;

public class CraneTowerController : MonoBehaviour
{
    public HoldableButton leftButton;
    public HoldableButton rightButton;
    private GameObject concrete;
    private const float TowerRotationOffset = 180.0f;
    private const float RotationSpeed = 0.05f;
    [SerializeField] private bool rotateToConcrete = false;
    private TrolleyController trolleyController;

    // Start is called before the first frame update
    void Start()
    {
        concrete = GameObject.Find("Concrete");
        trolleyController = GameObject.Find("Trolley").GetComponent<TrolleyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotateToConcrete)
        { 
            return;
        }
        
        RotateToConcrete();

        float angle = CalculateAngleToConcrete() - transform.rotation.eulerAngles.y;
        
        if (!(angle < 0.1f) || !(angle > -0.1f))
        {
            return;
        }
        rotateToConcrete = false;
        trolleyController.SetMoveToConcrete(true);
    }
    
    void RotateToConcrete()
    {
        float angle = CalculateAngleToConcrete();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), RotationSpeed);
    }
    
    float CalculateAngleToConcrete()
    {
        return (-Mathf.Atan2(concrete.transform.position.z - transform.position.z, 
            concrete.transform.position.x - transform.position.x) * Mathf.Rad2Deg) + TowerRotationOffset;
    }
    
    public void SetRotateToConcrete(bool rotateToConcrete)
    {
        this.rotateToConcrete = rotateToConcrete;
    }
}
