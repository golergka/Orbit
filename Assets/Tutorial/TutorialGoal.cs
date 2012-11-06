using UnityEngine;
using System.Collections;

public class TutorialGoal : MonoBehaviour {

	void OnDisable() {
		
		TutorialController.instance.OnHitGoal();
		
	}
}
