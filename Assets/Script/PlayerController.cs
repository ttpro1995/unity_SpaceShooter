using UnityEngine;
using System.Collections;


[System.Serializable] //viewable in inspector mode
public class Boundary
{
	public int xMax,xMin,zMax,zMin;
}

public class PlayerController : MonoBehaviour {

	Rigidbody rb;
	public int speed;
	public Boundary boundary;
	public GameObject projectile;
	//public Transform ShotSpawm;
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;
	public float sensitive;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject clone = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
		}
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		moveHorizontal += Input.acceleration.x;
		moveVertical += Input.acceleration.y;

		moveHorizontal += Input.GetAxis("Mouse X");
		moveVertical += Input.GetAxis("Mouse Y");

		float x = 0;
		float y = 0;
		
		if (moveHorizontal > 0)
			x = 1;
		else if (moveHorizontal < 0)
			x = -1;
		
		if (moveVertical > 0)
			y = 1;
		else if (moveVertical < 0)
			y = -1;

		x += Input.GetAxis("Mouse X")*sensitive;
		y += Input.GetAxis("Mouse Y")*sensitive;
		
		
		Vector3 moving = new Vector3 (x, 0, y);
		
		rb.velocity =moving*speed;
		
		
		Vector3 pos = new Vector3(
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax)
			,1
			,Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax));
		rb.position = pos;
	}
}
