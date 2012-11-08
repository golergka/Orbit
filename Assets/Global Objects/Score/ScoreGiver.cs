using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreGiver : MonoBehaviour {
	
	public int score = 50;

	void OnCollisionEnter(Collision collisionInfo) {
		
		GiveScore ( collisionInfo.contacts[0].point);
		
	}
	
	void OnTriggerEnter(Collider other) {
		
		GiveScore( other.transform.position);
		
	}
	
	void GiveScore(Vector3 position) {
		
		LevelManager.instance.AddScore(score, position);
		
	}
	
}
