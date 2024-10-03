using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    private GameObject craneTower;
    private CraneTowerController craneTowerController;
    
    // Start is called before the first frame update
    void Start()
    {
        craneTower = GameObject.Find("Tower Crane");
        craneTowerController = craneTower.GetComponent<CraneTowerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnMouseDown()
    {
        craneTowerController.SetRotateToConcrete(true);
    }
}
