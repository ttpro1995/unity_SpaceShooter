using UnityEngine;
using System.Collections;

public class random_rotate : MonoBehaviour {

	public float tumble;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
