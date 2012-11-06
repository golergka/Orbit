using UnityEngine;
using System.Collections;

public class Destroyable : MonoBehaviour {
	
	public Transform afterLife;

	void OnCollisionEnter(Collision collisionInfo) {
		
		GameObject collidedWith = collisionInfo.collider.gameObject;
		if (collidedWith.tag != "Ball")
			return;
		
		gameObject.active = false;
		
		if (afterLife != null)
			Instantiate(afterLife, transform.position, transform.rotation);
		
	}
}
