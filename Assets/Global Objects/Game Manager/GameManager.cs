using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;
	
	void Awake() {
		
		instance = this;
		DontDestroyOnLoad(this);
		
	}
	
	void Start() {
		
		NextLevel();
		
	}
	
	private int levelNumber = -1;
	public string[] levels;
	
	public void NextLevel() {
		
		if ( (levelNumber + 1) >= levels.Length) {
			Debug.LogError("No more levels!");
			return;
		}
		
		levelNumber++;
		Application.LoadLevel(levels[levelNumber]);
		
	}
	
	public void Menu() {
	}
	
}
