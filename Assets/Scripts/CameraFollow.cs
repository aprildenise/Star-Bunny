using UnityEngine;

public class CameraFollow : MonoBehaviour {

    //Good reference: https://www.youtube.com/watch?v=MFQhpwc6cKE&t=171s

    public Transform target; //get location of the target (set within unity)
    public float followSpeed = .025f; //follow speed of the camera, higher value means faster follow speed
    public Vector3 offset; //location of the camera (set within unity) (originally 0,3,-0.5)


    private void FixedUpdate()
    {
		//Camera's current position (set within unity) = target position
		Vector3 desiredPosition = target.position + offset;

		if (desiredPosition.x > 0.64) {
			desiredPosition.x = (float)0.64;
		}
		if (desiredPosition.x < -2.12) {
			desiredPosition.x = (float)-2.12;
		}

		if (desiredPosition.y > 1.57) {
			desiredPosition.y = (float)1.57;
		}
		if (desiredPosition.y < -1.67){
			desiredPosition.y = (float)-1.64;
		}


		//Changes the position at the follow speed rate smoothly
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed);

	

		//move the camera
		transform.position = smoothedPosition;
    }

}
