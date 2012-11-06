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
	
	// Update is called once per frame
	void Update () {
		
		foreach(Rigidbody rb in agents) {
			
			if (rb == rigidbody)
				continue;
			
			Vector3 force = rb.position - rigidbody.position;
			float distance = force.magnitude;
			force.Normalize();
			
			float forceAmount = GRV * rb.mass; // float math shit, that's why I'm writing this strange
			forceAmount *= rigidbody.mass;
			forceAmount /= distance;
			forceAmount /= distance;
			
			force *= forceAmount;
			
			rigidbody.AddForce(force, ForceMode.Force);
			
		}
	
	}
}
