using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Activatable : MonoBehaviour {
	
	static List<Activatable> activatables = new List<Activatable>();

	public static void ActivateAll() {
		
		foreach(Activatable act in activatables)
			act.gameObject.active = true;
		
	}
	
	void Awake() {
		
		activatables.Add (this);
		
	}
	
	void OnDestroy() {
		
		activatables.Remove(this); // you shouldn't normally destroy activatable objects
		
	}
	
}
