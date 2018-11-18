using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform followTransform;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(followTransform.position.x, transform.position.y, transform.position.z);
    }
}
