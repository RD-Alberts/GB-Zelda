using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{
    public Vector2 CameraChange;
    public Vector3 PlayerChange;

    private CameraMovement cameraMain;

    // Start is called before the first frame update
    void Start()
    {
        cameraMain = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            cameraMain.MinPosition += CameraChange;
            cameraMain.MaxPosition += CameraChange;

            other.transform.position += PlayerChange;
        }
    }
}
