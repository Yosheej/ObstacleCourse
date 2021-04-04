using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] float xRotate = 0;
    [SerializeField] float yRotate = 0;
    [SerializeField] float zRotate = 0;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(xRotate, yRotate, zRotate) * Time.deltaTime);
    }
}
