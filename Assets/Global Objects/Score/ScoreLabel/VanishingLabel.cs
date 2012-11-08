using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]

public class VanishingLabel : Lifetime {
	
	public float moveUpVelocity = 1f;
	
	public Color textColor = Color.white;
	private Color textColorFaded;
	
	Vector3 initialPosition;
	
	void Awake() {
		
		initialPosition = transform.position;
		
	}
	
	protected override void Start() {
		
		base.Start();
		textColorFaded = textColor;
		textColorFaded.a = 0;
		
	}
	
	// Update is called once per frame
	protected override void Update () {
		
		base.Update();
		
		transform.position += new Vector3(0, moveUpVelocity * Time.deltaTime ,0);
		float lifePercentageElapsed = ( Time.time - startTime ) / lifeTime;
		renderer.material.color = Color.Lerp(textColor, textColorFaded, lifePercentageElapsed);
	
	}
	
	public override void Reset() {
		
		base.Reset ();
		transform.position = initialPosition;
		renderer.material.color = textColor;
		
	}
	
}
