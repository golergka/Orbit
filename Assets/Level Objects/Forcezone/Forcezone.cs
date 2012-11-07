using UnityEngine;
using System.Collections;

public class Forcezone : MonoBehaviour {
	
	public float forcePower = 1f;
	private Vector3 forceDirection;
	
	void Awake() {
		
		forceDirection = transform.rotation * new Vector3(0,1,0);
		
	}

	void OnTriggerStay(Collider other) {
		
		other.attachedRigidbody.AddForce( forceDirection * forcePower, ForceMode.Force);
		
	}
	
}
