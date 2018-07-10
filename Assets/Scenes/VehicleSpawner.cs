using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour {

	public Transform spawn;
    int step = 0;
	bool isStuck = false;
	int spawnInt = 180;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		step++;
        if (step % spawnInt == 0 && !isStuck)
        {
	        var obj = Instantiate(spawn, new Vector3(GetComponent<Transform>().position.x, 0.5f, GetComponent<Transform>().position.z), Quaternion.identity);
		    Vector3 rot = transform.rotation.eulerAngles;
 			obj.GetComponent<Transform>().rotation = Quaternion.Euler(rot);
        }
		if (step > spawnInt) {
			step = 0;
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Car") {
			isStuck = true;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "Car") {
			isStuck = false;
		}
	}
}
