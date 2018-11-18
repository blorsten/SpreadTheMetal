using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarController : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode purpleFIre;
    public KeyCode greenFire;
    public KeyCode yellowFire;
    public KeyCode orangeFire;
    public Color purple;
    public Color yellow;
    public Color orange;
    public Color green;
    public float rotation;
    public float rotationOffset = 15;
    public flameController flameController;

    private SpriteRenderer spr;

    // Use this for initialization
    void Start()
    {
        TiltGuitar(-rotation);
        spr = GetComponent<SpriteRenderer>();
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
        if (Input.GetKeyDown(purpleFIre))
        {
            spr.color = purple;
            flameController.FireFire(EnemyColor.Purple);
        }
        if (Input.GetKeyDown(yellowFire))
        {
            spr.color = yellow;
            flameController.FireFire(EnemyColor.yellow);
        }
        if (Input.GetKeyDown(greenFire))
        {
            spr.color = green;
            flameController.FireFire(EnemyColor.Green);
        }
        if (Input.GetKeyDown(orangeFire))
        {
            spr.color = orange;
            flameController.FireFire(EnemyColor.Orange);
        }
    }

    public void TiltGuitar(float angle)
    {
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, angle + rotationOffset);
    }
}
