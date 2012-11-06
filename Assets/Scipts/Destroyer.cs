using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void OnCollisionEnter(Collision collisionInfo) {
		
		GameObject collidedWith = collisionInfo.collider.gameObject;
		if (collidedWith.tag != "Ball")
			return;
		
		Destroy (collidedWith);
		
	}
	
}
