using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float Speed;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.forward * Speed;
	}
	

}
