using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	
	void Start() {
		
		LevelManager.instance.RegisterGoal();
		
	}

	void OnDisable() {
		
		if (quitting)
			return;
		
		LevelManager.instance.CompleteGoal();
		
	}
	
	bool quitting = false;
	
	void OnApplicationQuit() {
		quitting = true;
	}
	
}
