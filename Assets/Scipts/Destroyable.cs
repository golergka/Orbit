using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {
	
	public Transform afterLife;

	void OnCollisionEnter(Collision collisionInfo) {
		
		SelfDestruct(collisionInfo.collider.gameObject);
		
	}
	
	void OnTriggerEnter(Collider other) {
		
		SelfDestruct(other.gameObject);
		
	}
	
	void SelfDestruct(GameObject collidedWith) {
		
		gameObject.active = false;
		
		if (afterLife != null)
			Instantiate(afterLife, transform.position, transform.rotation);
		
	}
	
}
