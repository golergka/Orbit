using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Ball))]

public class PullLauncherDelegate : MonoBehaviour {
	
	PullLauncher father;
	Vector3 originPoint;
	LineRenderer lineRenderer;
	
	void Start() {
		
		originPoint = transform.position;
		rigidbody.isKinematic = true;
		
	}
	
	public void Init(PullLauncher father) {
		
		this.father = father;
		lineRenderer = father.GetComponent<LineRenderer>();
		
		float ballSize = transform.localScale.x;
		lineRenderer.SetWidth(ballSize/2, ballSize);
		
	}
	
	bool dragging = false;
	
	void OnMouseDrag() {
		
		dragging = true;
		abortLaunch = false;
		
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				
		Vector3 toPointer = ray.origin - originPoint;
		toPointer.z = 0;
		toPointer = Vector3.ClampMagnitude(toPointer, father.maxDistance);
		
		transform.position = originPoint + toPointer;
		
		lineRenderer.SetPosition(1, toPointer);
		Color powerColor = Color.Lerp(father.maxPowerLine, father.minPowerLine, launchPowerPercentage);
		lineRenderer.SetColors(father.startPowerLine, powerColor);
		
	}
	
	bool abortLaunch = false;
	float abortLaunchSpeed = 0.5f;
	float abortLaunchDistance = 0.1f;
	
	void Update() {
		
		if (Input.GetMouseButtonUp(0) && dragging) {
			
			dragging = false;
			Launch ();
			
		}
		
		if (abortLaunch) {
			
			transform.position += (originPoint - transform.position).normalized * abortLaunchSpeed * Time.deltaTime;
			
			if ( (transform.position - originPoint).magnitude < abortLaunchDistance ) {
				transform.position = originPoint;
				abortLaunch = false;
			}
			
		}
		
	}
	
	float launchPowerPercentage {
		
		get {
			
			float result = (transform.position - originPoint).magnitude;
			result -= father.minDistance;
			result /= (father.maxDistance - father.minDistance);
			return result;
			
		}
		
	}
	
	float launchPower {
		
		get {
			
			float result = launchPowerPercentage;
			result *= (father.maxLaunchPower - father.minLaunchPower);
			result += father.minLaunchPower;
			return result;
			
		}
		
	}
	
	void Launch() {
		
		lineRenderer.SetPosition(1, Vector3.zero);
		
		if (launchPowerPercentage <= 0) {
			abortLaunch = true;
			return;
		}
		
		Vector3 force = originPoint - transform.position;
		force.Normalize();
		force *= launchPower;
		
		rigidbody.isKinematic = false;
		rigidbody.AddForce(force, ForceMode.VelocityChange);
		
		GetComponent<Ball>().enabled = true;
		
	}
	
	bool isShuttingDown = false;
	
	void OnApplicationQuit() {
		
		isShuttingDown = true;
		
	}
	
	void OnDestroy() {
		
		if (isShuttingDown)
			return;
		
		father.Reload();
		
	}
	
}
