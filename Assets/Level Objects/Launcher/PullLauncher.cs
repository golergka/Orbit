using UnityEngine;
using System.Collections;

public class PullLauncher : MonoBehaviour {
	
	public float minLaunchPower = 1f;
	public float maxLaunchPower = 2f;
	
	public float minDistance = 0.5f;
	public float maxDistance = 1f;
	
	public Color minPowerLine;
	public Color maxPowerLine;
	public Color startPowerLine;
	
	public static PullLauncher instance;
	
	void Awake() {
		
		instance = this;
		
		if (minDistance >= maxDistance) {
			Debug.LogError("minDistance shouldn't be bigger than maxDistance!");
			enabled = false;
		}
		
		if (minLaunchPower >= maxLaunchPower) {
			Debug.LogError("minLaunchPower shouldn't be bigger than maxLaunchPower!");
			enabled = false;
		}
		
	}
	
	void OnEnabled() {
		
		Reload ();
		
	}
	
	private Transform newBall = null;
	
	public void Reload() {
		
		if (!this.enabled)
			return;
		
		Transform newBallPrefab = LevelManager.instance.PopBall();
		if (newBallPrefab == null) {
			LevelManager.instance.FailGame();
			return;
		}
		
		newBall = (Transform) Instantiate(newBallPrefab, transform.position, Quaternion.identity);
		newBall.gameObject.AddComponent<PullLauncherDelegate>().Init(this);
		
	}
	
	void OnDrawGizmos() {
		
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, maxDistance);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, minDistance);
		
	}
	
}
