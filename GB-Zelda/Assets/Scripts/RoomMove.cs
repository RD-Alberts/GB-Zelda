using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{public Vector2 CameraChange;
    public Vector3 PlayerChange;

    private CameraMovement cameraMovement;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraMovement.MinPosition += CameraChange;
            cameraMovement.MaxPosition += CameraChange;
            other.transform.position += PlayerChange;
        }
    }
}
