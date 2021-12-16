using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatyBehavior : MonoBehaviour
{
    private float tiltAngle = 0;
    public float turnSpeed = .5f;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        tiltAngle += turnSpeed;
        transform.rotation = Quaternion.Euler (0, transform.rotation.y + tiltAngle, 0);
    }
}
