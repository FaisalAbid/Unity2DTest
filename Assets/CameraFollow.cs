using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject targetObject;
	private float distanceToTarget;
	// Use this for initialization
	void Start () {
		distanceToTarget = GetComponent<Transform>().position.x - targetObject.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		float targetObjectX = targetObject.transform.position.x;
		
		Vector3 newCameraPosition = GetComponent<Transform>().position;
		newCameraPosition.x = targetObjectX + distanceToTarget;
		GetComponent<Transform>().position = newCameraPosition;
	}
}
