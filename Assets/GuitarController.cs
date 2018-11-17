using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarController : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode fireKey;
    public float rotation;
    public float rotationOffset = 15;
    public flameController flameController;

    // Use this for initialization
    void Start()
    {
        TiltGuitar(-rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(upKey))
        {
            TiltGuitar(rotation);
        }
        if (Input.GetKeyDown(downKey))
        {
            TiltGuitar(-rotation);
        }
        if (Input.GetKeyDown(fireKey))
        {
            flameController.FireFire();
        }
    }

    public void TiltGuitar(float angle)
    {
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, angle + rotationOffset);
    }
}
