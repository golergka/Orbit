using UnityEngine;
using System.Collections;

public class ClickLauncher : MonoBehaviour {
	
	public float minLaunchPower = 1f;
	public float maxLaunchPower = 2f;
	public float launchPowerBuildUp = 2f;
	
	float launchPower;
	public static ClickLauncher instance;
	
	void Awake() {
		
		launchPower = minLaunchPower;
		instance = this;
		
	}
	
	float powerPercentage {
		
		get { return (launchPower - minLaunchPower ) / ( maxLaunchPower - minLaunchPower ); }
		
	}
	
	public Transform launchPoint;
	public Transform launchBody;
	
	private bool gotMouseDown = false;
	private bool justEnabled = false;
	
	public void OnEnable() {
		
		Debug.Log ("Enabled!");
		gotMouseDown = false;
		justEnabled = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// pointing transform
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 pointer = ray.origin;
		pointer.z = transform.position.z;
		transform.LookAt(pointer);
		
		// display power
		launchBody.renderer.material.color = Color.Lerp(Color.green, Color.red, powerPercentage);
		
		if (justEnabled) { // special check if that's the first frame after being enabled
			justEnabled = false;
			return;
		}
		
		if (Input.GetMouseButtonDown (0))
			gotMouseDown = true;
		
		if (Input.GetMouseButton(0))
			launchPower += launchPowerBuildUp * Time.deltaTime;
		
		if (launchPower > maxLaunchPower)
			launchPower = maxLaunchPower;
		
		if (Input.GetMouseButtonUp(0) && gotMouseDown) {
			if (LevelManager.instance.gameState == LevelManager.GameState.Playing)
				Launch ();
			launchPower = minLaunchPower;
			gotMouseDown = false;
		}
	
	}
	
	void OnGUI() {
		
		GUI.Label ( new Rect(10, 10, 200, 20), "Power: " + (powerPercentage * 100).ToString() + "%");
		
	}
	
	void Launch() {
		
		Transform ball = LevelManager.instance.PopBall();
		if (ball == null)
			return;
		Rigidbody newBall = ((Transform) Instantiate(ball, launchPoint.position, Quaternion.identity)).GetComponent<Rigidbody>();
		Vector3 launchForce = transform.forward.normalized * launchPower;
		newBall.AddForce(launchForce, ForceMode.VelocityChange);
		
	}
	
}
