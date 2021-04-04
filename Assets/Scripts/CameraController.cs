using UnityEngine;
using System.Collections;

public class CameraController: MonoBehaviour {

[SerializeField] GameObject Player;
private Vector3 offset;

    void Start() 
    {
        offset = transform.position - Player.transform.position;
    }

    void LateUpdate() 
    {
        transform.position = Player.transform.position + offset;
    }
}