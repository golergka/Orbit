using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]

public class Gravitation : MonoBehaviour {
	
	static List<Rigidbody> agents = new List<Rigidbody>();
	
	void OnEnable() {
		
		agents.Add(rigidbody);
		
	}
	
	void OnDisable() {
		
		agents.Remove (rigidbody);
		
	}
	
	const float GRV = 1f;
	
	const float MAX_FORCE = 1000f;
	
	public float manualRadius = 1f;
	float radius {
		
		get {
			
			SphereCollider sphere = GetComponent<SphereCollider>();
			if (sphere == null)
				return manualRadius;
			else
				return sphere.radius * transform.lossyScale.x;
			
		}
		
	}
	
	Vector3 gravForce = Vector3.zero;
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (gameObject.isStatic)
			return;
		
		gravForce = Vector3.zero;
		
		foreach(Rigidbody rb in agents) {
			
			if (rb == rigidbody)
				continue;
			
			Vector3 force = rb.position - rigidbody.position;
			float distance = force.magnitude;
			
			if (distance == 0)
				continue;
			
			force.Normalize();
			
			float forceAmount = GRV * rb.mass; // float math shit, that's why I'm writing this strange
			forceAmount *= rigidbody.mass;
			
			if (distance < radius) {
				forceAmount *= distance;
				forceAmount /= radius;
				forceAmount *= distance;
				forceAmount /= radius;
				forceAmount *= distance;
				forceAmount /= radius;
			}
			
			forceAmount /= distance;
			forceAmount /= distance;
			
			if (forceAmount >= MAX_FORCE) {
				forceAmount = MAX_FORCE;
				Debug.LogWarning("Exceeding maximum gravity force!");
			}
			
			force *= forceAmount;
			
			gravForce += force;
			
		}
		
		rigidbody.AddForce(gravForce, ForceMode.Force);
		
	}
	
	void OnDrawGizmos() {
		
		Gizmos.color = Color.grey;
		Gizmos.DrawLine(rigidbody.position, rigidbody.position + gravForce);
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(rigidbody.position, radius);
		
	}

}
