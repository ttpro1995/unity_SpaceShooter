using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {

	public GameObject rock;
	public int rockCount;

	public Vector3 spawmValue;
	public float waitTime;
	public float waitBetweenWave;

	// Use this for initialization
	void Start () {
		StartCoroutine (spawmRock());//must use Coruotine to wait
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator spawmRock(){
		while (true) {
			yield return new WaitForSeconds (waitBetweenWave);
			for (int i = 0; i<rockCount; i++) {
				Vector3 spawmPosition = new Vector3 (Random.Range (-spawmValue.x, spawmValue.x), spawmValue.y, spawmValue.z);
				Quaternion q = Quaternion.identity;

				Instantiate (rock, spawmPosition, q);
				yield return new WaitForSeconds (waitTime);//must use Coruotine to wait
			}
		
		}
	}
}
