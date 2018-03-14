using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //Good reference: https://www.youtube.com/watch?v=MFQhpwc6cKE&t=171s

    public Transform target; //get location of the target (set within unity)
    public float followSpeed = .125f; //follow speed of the camera, higher value means faster follow speed
    public Vector3 offset; //location of the camera (set within unity) (originally 0,3,-0.5)


    private void LateUpdate()
    {
        transform.position = target.position + offset; //camera's current position (set within unity) = target position

    }

}
