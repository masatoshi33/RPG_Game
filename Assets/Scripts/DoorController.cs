using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject door;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RotateDoor(60f);
        }
    }

    private void RotateDoor(float angular) => door.transform.Rotate(0f, 0f, -angular);
}
