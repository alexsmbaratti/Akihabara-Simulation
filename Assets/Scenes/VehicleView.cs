using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleView : MonoBehaviour {

	public bool isClose = false;
	public bool isStop = false;
	public Material greenMat;
	public Material redMat;
	float speedLimit;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().enabled = false;
		speedLimit = gameObject.transform.parent.GetComponent<Vehicle>().speedLimit;
	}
	
	// Update is called once per frame
	void Update () {
		if (isClose || isStop) {
			gameObject.transform.parent.GetComponent<Vehicle>().speed = 0;
			gameObject.transform.parent.GetComponent<Renderer>().material = redMat;
		}
		if (!isClose && !isStop) {
			gameObject.transform.parent.GetComponent<Renderer>().material = greenMat;
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Car") {
			isClose = true;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "Car") {
			isClose = false;
			gameObject.transform.parent.GetComponent<Vehicle>().speed = Random.Range(speedLimit - 10f, speedLimit);;
		}
	}
}
