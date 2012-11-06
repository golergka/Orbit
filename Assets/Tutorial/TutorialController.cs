using UnityEngine;
using System.Collections;

public class TutorialController : MonoBehaviour {
	
	public static TutorialController instance;
	
	void Awake() {
		
		instance = this;
		
	}

	public VanishingLabel pullLabel;
	public VanishingLabel hitLabel;
	public VanishingLabel avoidLabel;
	
	public void OnBallReload() {
		
		pullLabel.Reset();
		pullLabel.enabled = false;
		
	}
	
	public void OnPulledBall() {
		
		pullLabel.enabled = true;
		hitLabel.Reset ();
		hitLabel.enabled = false;
		
	}
	
	public void OnHitGoal() {
		
		if (isQuitting)
			return;
		
		hitLabel.enabled = true;
		avoidLabel.enabled = true;
		
	}
	
	public void OnHitPlanet() {
		
		avoidLabel.Reset();
		avoidLabel.enabled = false;
		
	}
	
	bool isQuitting = false;
	
	void OnApplicationQuit() {
		
		isQuitting = true;
		
	}
	
}
