using UnityEngine;
using System.Collections;

public class TutorialPlanet : MonoBehaviour {

	void OnCollisionEnter(Collision collisionInfo) {
		
		TutorialController.instance.OnHitPlanet();
		
	}
	
}
