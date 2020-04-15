using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target; //what the camera will be following
    public float Smoothing; // how fast the camera move to the target

    public Vector2 MaxPosition;
    public Vector2 MinPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != Target.position)
        {
            //the target position used for the transform so the z position doesn't change 
            Vector3 targetPosition = new Vector3(Target.position.x, Target.position.y, transform.position.z);
            
            targetPosition.x = Mathf.Clamp(targetPosition.x, MinPosition.x, MaxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, MinPosition.y, MaxPosition.y);

            transform.position =  Vector3.Lerp(transform.position, targetPosition, Smoothing);
        }
    }
}
