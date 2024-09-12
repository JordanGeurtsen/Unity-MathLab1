using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableController : MonoBehaviour
{
    private float wantedScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentScale = transform.localScale;
        Vector3 scaleChange = new Vector3(0, (wantedScale * 2) - currentScale.y, 0);

        transform.localScale += scaleChange;
    }

    public void setNewScale(float wantedScale)
    {
        this.wantedScale = wantedScale;
    }
}
