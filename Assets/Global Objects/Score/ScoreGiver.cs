using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreGiver : MonoBehaviour {
	
	List<GameObject> gifted = new List<GameObject>();
	
	public int score = 50;
	
	void OnEnable() {
		
		gifted.Clear();
		
	}

	void OnCollisionEnter(Collision collisionInfo) {
		
		GameObject collidedWith = collisionInfo.collider.gameObject;
		
		GiveScore (collidedWith, collisionInfo.contacts[0].point);
		
	}
	
	void OnTriggerEnter(Collider other) {
		
		GiveScore(other.gameObject, other.transform.position);
		
	}
	
	void GiveScore(GameObject collidedWith, Vector3 position) {
		
		if (gifted.Contains(collidedWith))
			return;
		
		if (collidedWith.tag != "Ball")
			return;
		
		LevelManager.instance.AddScore(score, position);
		gifted.Add (collidedWith);
		
	}
	
}
