using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	
	void Start() {
		
		LevelManager.instance.RegisterGoal();
		
	}

	void OnDisable() {
		
		LevelManager.instance.CompleteGoal();
		
	}
	
}
