using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMath.UI;

public class CraneTowerController : MonoBehaviour
{
    public HoldableButton leftButton;
    public HoldableButton rightButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leftButton.IsHeldDown)
        {
            transform.Rotate(Vector3.up, 0.1f);
        }

        if (rightButton.IsHeldDown)
        {
            transform.Rotate(Vector3.up, -0.1f);
        }
    }
}
