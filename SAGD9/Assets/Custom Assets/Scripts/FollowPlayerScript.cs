using UnityEngine;

public class FollowPlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    public Transform target;
    public float dampTime= 0.17f;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        if (target)
        {
            var point = camera.WorldToViewportPoint(target.position);
            var delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            var destination = transform.position + delta;

            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }

} 

