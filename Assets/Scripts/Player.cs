using UnityEngine;
using System.Collections;

//自機の処理
public class Player : MonoBehaviour {
	public float maxSpeed = 30.0f;
	private Rigidbody myRigidbody;

	// Use this for initialization
	void Start () {
		myRigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
    if (myRigidbody.velocity.magnitude > maxSpeed) {
      myRigidbody.velocity = Vector3.ClampMagnitude (myRigidbody.velocity, maxSpeed);
    }
  }

  void OnCollisionEnter(Collision coll) {
  	if (coll.gameObject.tag == "Stage") {
  		Timer.StartTime();
  	}
  }
}
