using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {
	
	void Start() {
		
		GameController.instance.RegisterGoal();
		
	}

	void OnDisable() {
		
		GameController.instance.CompleteGoal();
		
	}
	
}
