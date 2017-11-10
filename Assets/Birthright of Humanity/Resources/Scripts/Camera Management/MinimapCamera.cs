using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour {
	[SerializeField]
	private Transform target;
	[SerializeField]
	private float offset = 10.0f;
	[SerializeField]
	private float motionDampining = 1.0f;

	private void Start ()
	{
		
	}

	private void Update ()
	{
		
	}
	private void FixedUpdate ()
	{

	}
	private void LateUpdate ()
	{
		Vector3 targetPosition = target.position;
		targetPosition.y += offset;
		transform.position = Vector3.Lerp(transform.position, targetPosition, motionDampining * Time.deltaTime);
	}
}
