using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameMath;
public class TrolleyController : MonoBehaviour
{
    public GameObject nearLimit;
    public GameObject farLimit;
    private float wantedPosition = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(nearLimit.transform.position, farLimit.transform.position, wantedPosition);
    }

    public void setNewPosition(float wantedPosition)
    {
        this.wantedPosition = wantedPosition;
    }
}
