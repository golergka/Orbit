using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	# region Singleton
	
	static public LevelManager instance;
	
	void Awake() {
		
		instance = this;
		
	}
	
	#endregion
	
	#region Balls factory
	
	public Transform[] ballList;
	private int ballsIndex = 0;
	
	public Transform PopBall() { return GetBall(true); }
	
	public Transform PeekBall() { return GetBall(false); }
	
	private Transform GetBall(bool pop) {
		
		if (ballsIndex == ballList.Length)
			return null;
		
		return ballList[pop ? ballsIndex++ : ballsIndex];
		
	}
	
	public int ballsLeft { get { return ballList.Length - ballsIndex; } }
	
	#endregion
	
	#region Score 
	
	private int score = 0;
	public TextMesh scoreLabel;
	
	public void AddScore(int newScore, Vector3 scorePosition) {
		
		if (newScore == 0)
			return;
		
		score = score + newScore;
		TextMesh newScoreLabel = (TextMesh) Instantiate(scoreLabel, scorePosition + new Vector3(0,0,-1) , Quaternion.identity);
		newScoreLabel.text = "+" + newScore.ToString();
		
	}
	
	#endregion
	
	#region Game State
	
	private float startTime = 0; // when game the started
	private float gameTime = 0; // total run time of the game
	
	public enum GameState {
		
		StartMenu,
		Playing,
		FailMenu,
		WinMenu,
		
	}
	
	private GameState _gameState = GameState.StartMenu;
	public GameState gameState { get { return _gameState; } }
	
	public bool showStartMenu = true;
	
	void Start() {
		
		if (!showStartMenu) {
			
			StartGame();
			
		}
		
	}
	
	private void StartGame() {
		
		_gameState = GameState.Playing;
		score = 0;
		goalsComplete = 0;
		startTime = Time.time;
		ballsIndex = 0;
		PullLauncher.instance.enabled = true;
		PullLauncher.instance.Reload();	
		Activatable.ActivateAll();
		
	}
	
	public void FailGame() {
		
		_gameState = GameState.FailMenu;
		FinishGame();
		
	}
	
	private void WinGame() {
		
		_gameState = GameState.WinMenu;
		FinishGame();
		
	}
	
	private void FinishGame() {
		
		gameTime = Time.time - startTime;
		PullLauncher.instance.enabled = false;
		
	}
	
	public void RestartGame() {
		
		// for now it's the same...
		StartGame();
		
	}
	
	#endregion
	
	#region Winning level
	
	int goals = 0;
	int goalsComplete = 0;
	
	public void RegisterGoal() {
		
		goals++;
		
	}
	
	public void CompleteGoal() {
		
		goalsComplete++;
		if (goalsComplete == goals)
			WinGame();
		
	}
	
	#endregion
	
	void OnGUI() {
		
		Rect gameResultRect = new Rect(Screen.width/2 - 50, Screen.height/2 - 25, 100, 20);
		string gameResultText = "Score: " + ((int) score).ToString() + " Time: " + (int) gameTime;
		
		switch (gameState) {
			
		case GameState.StartMenu:
			if (GUI.Button (new Rect(Screen.width/2 - 25, Screen.height/2 - 10, 50, 20), "Start"))
				StartGame();
			break;
			
		case GameState.Playing:
			GUI.Label ( new Rect(Screen.width - 160, 10, 150, 20), "Balls: " + ballsLeft + " Score: " + ((int) score).ToString() );
			break;
			
		case GameState.FailMenu:
			GUI.Label (gameResultRect, gameResultText);
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height/2 + 25, 100, 20), "Try again!") )
				StartGame();
			break;
			
		case GameState.WinMenu:
			GUI.Label (gameResultRect, gameResultText);
			
			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height/2 + 25, 100, 20), "Next level") )
				GameManager.instance.NextLevel();
			
			break;
			
		}
		
	}
	
}
