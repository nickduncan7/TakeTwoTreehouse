using UnityEngine;

public class FollowPlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    public Transform target;
    public float smooth= 10.0f;


    void  LateUpdate (){
        if (target)
        {
            var x = target.position.x;
            var y = target.position.y;
            transform.position = new Vector3(x, y, transform.position.z);
        }


} 
}

