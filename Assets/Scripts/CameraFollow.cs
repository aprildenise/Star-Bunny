using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //Previous references
	//https://www.youtube.com/watch?v=MFQhpwc6cKE&t=171s

    public Transform target; //get location of the target (set within unity)
    public float followSpeed = .125f; //follow speed of the camera, higher value means faster follow speed
    public Vector3 offset; //location of the camera (set within unity) (originally 0,3,-0.5)


    private void FixedUpdate()
    {
		//Vector3 targetPos = target.position;

		//camera's current position (set within unity) = target position
		Vector3 desiredPosition = target.position + offset;

		//checks if the y vector value is greater or less than the edge
		//if so keep the x value the same
		if (desiredPosition.y >= 0) {
			desiredPosition.y = 0;
		}
		if (desiredPosition.y <= 0) {
			desiredPosition.y = 0;
		}

		//checks the x in similar fashion
		if (desiredPosition.x >= 2) {
			desiredPosition.x = 2;
		} 
		if (desiredPosition.x <= -2) {
			desiredPosition.x = -2;
		}

		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed);

		transform.position = smoothedPosition;
	}
}
