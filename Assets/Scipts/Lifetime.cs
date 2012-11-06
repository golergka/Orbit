using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour {
	
	public float lifeTime;
	protected float startTime;
	public bool delete = true;
	
	// Use this for initialization
	protected virtual void Start () {
		
		startTime = Time.time;
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		
		if (Time.time - startTime >= lifeTime) {
			
			if (delete)
				Destroy(gameObject);
			else
				gameObject.active = false;
			
		}
	
	}
	
	public virtual void Reset() {
		
		startTime = Time.time;
		gameObject.active = true;
		
	}
	
}
