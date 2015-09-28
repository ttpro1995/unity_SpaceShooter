using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public Object explosion;
	public Object playerExplosion;

	void OnTriggerEnter(Collider other) {
		if (other.tag != "Boundary") {
			Instantiate(explosion,transform.position,transform.rotation);
			if (other.tag == "Player"){
				Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
			}
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}

}
