using UnityEngine;
using System.Collections;

public class TutorialBall : MonoBehaviour {
	
	void OnEnable() {
		
		TutorialController.instance.OnBallReload();
		
	}
	
	void OnMouseDrag() {
		
		TutorialController.instance.OnPulledBall();
		
	}
	
}
