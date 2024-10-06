using System.Collections;
using System.Collections.Generic;
using GameMath.Utils;
using UnityEngine;

public class CableController : MonoBehaviour
{
    private float minScale = 0.0f;
    private float maxScale = 2.0f;
    [SerializeField] private bool scaleToConcrete = false;
    private float cooldown = 1.0f;
    
    private DetectHook detectHook;
    private GameObject concrete;
    private GameObject craneTower;
    private GameObject nearLimit;
    private GameObject farLimit;

    // Start is called before the first frame update
    void Start()
    {
        detectHook = GameObject.Find("Hook").GetComponent<DetectHook>();
        concrete = GameObject.Find("Concrete");
        craneTower = GameObject.Find("Tower Crane");
        nearLimit = GameObject.Find("Trolley Near Limit");
        farLimit = GameObject.Find("Trolley Far Limit");
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleToConcrete && !detectHook.HookHit)
        {
            ScaleCable(0.01f);
        }

        if (detectHook.HookHit)
        {
            cooldown -= Time.deltaTime;

            if (cooldown <= 0)
            {
                ScaleCable(-0.01f);

                if (transform.localScale.y <= minScale)
                {
                    detectHook.HookHit = false;
                    scaleToConcrete = false;
                    cooldown = 1.0f;
                    concrete.transform.position = Position.RandomPosition(craneTower.transform.position,
                        Position.Distance2D(nearLimit.transform.position, craneTower.transform.position),
                        Position.Distance2D(farLimit.transform.position, craneTower.transform.position),
                        10f,
                        20f);
                }
            }
        }
    }
    
    private void ScaleCable(float scale)
    {
        Vector3 newScale = transform.localScale;
        newScale.y = Mathf.Clamp(newScale.y + scale, minScale, maxScale);
        transform.localScale = newScale;
    }
    
    public void SetScaleToConcrete(bool scaleToConcrete)
    {
        this.scaleToConcrete = scaleToConcrete;
    }
}
