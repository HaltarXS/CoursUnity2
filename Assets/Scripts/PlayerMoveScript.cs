using UnityEngine;
using System.Collections;

public class PlayerMoveScript : MonoBehaviour {

    public int Speed = 3;
	void Start () {
	
	}
	
	void Update () {
       
	}

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(-Input.GetAxis("Vertical") * Speed, 0f, Input.GetAxis("Horizontal") * Speed);
        rigidbody.velocity = direction;
        GetComponentInChildren<Animator>().SetBool("moving", Mathf.Abs(rigidbody.velocity.x) > 0.2 || Mathf.Abs(rigidbody.velocity.z) > 0.2);
        transform.LookAt(transform.position + direction);
        Camera.main.transform.position = new Vector3(transform.position.x + 5.0f, Camera.main.transform.position.y, transform.position.z); 
    }
}
