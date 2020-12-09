using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float RotationSpeed;
    void Update()
    {
        transform.Rotate(new Vector3(0, 10, 0) * RotationSpeed * Time.deltaTime);
    }
}
