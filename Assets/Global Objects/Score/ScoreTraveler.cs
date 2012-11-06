using UnityEngine;
using System.Collections;

public class ScoreTraveler : MonoBehaviour {

	Vector3 scoringPosition;
	float scoringTime;
	
	public float scoringPeriod = 0.3f;
	public float scoreSpeed = 10f;
	
	void Start() {
		
		scoringPosition = transform.position;
		scoringTime = Time.time;
		
	}

	void Update() {
		
		if (Time.time - scoringTime >= scoringPeriod) {
			
			int bonusScore = Mathf.RoundToInt( scoreSpeed * (transform.position - scoringPosition).magnitude );
			LevelManager.instance.AddScore(bonusScore, transform.position);
				
			scoringPosition = transform.position;
			scoringTime = Time.time;
			
		}
		
	}
		
	
}
