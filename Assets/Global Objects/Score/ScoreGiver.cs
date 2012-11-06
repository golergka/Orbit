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
		
		if (gifted.Contains(collidedWith))
			return;
		
		if (collidedWith.tag != "Ball")
			return;
		
		LevelManager.instance.AddScore(50, collisionInfo.contacts[0].point);
		gifted.Add (collidedWith);
		
	}
	
}
