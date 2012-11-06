using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;
	
	void Awake() {
		
		instance = this;
		
	}
	
	public List<string> levels;
	
	public void NextLevel() {
		
		int nextLevel = levels.IndexOf(Application.loadedLevelName) + 1;
		if (nextLevel < levels.Count)
			Application.LoadLevel( levels[nextLevel] );
		
	}
	
}
