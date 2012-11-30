using UnityEngine;
using System.Collections;

public class Pulsar_force : MonoBehaviour 
{
	public float pulsarForce = 0.1f;
	
	private bool inZone = false;
	private GameObject obj;
	
	void forcePulcare(GameObject obje, bool active)
	{
		if(active)
		{	
			float dist = Vector3.Distance(obje.transform.position,transform.position);
			Vector2 Vect = new Vector2(obje.transform.position.x - transform.position.x, obje.transform.position.y - transform.position.y);
			Vect.Normalize();
			Vector3 VectF = new Vector3(Vect.x,Vect.y,0);
			obje.rigidbody.AddForce(VectF*dist*pulsarForce);
		}
		
	}
	void OnTriggerEnter(Collider infoCollision)
	{
		obj = infoCollision.gameObject;
		inZone = true;
	}
	void OnTriggerExit(Collider infoCollision)
	{
		inZone = false;
	}
	
	void Update()
	{
		forcePulcare(obj, inZone);
	}
}
