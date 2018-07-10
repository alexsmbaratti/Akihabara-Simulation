using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficBarrier : MonoBehaviour {

	public int step = 0;
	public int signalChange;
	public bool signal = false;
	bool delay = false;
	public Material redMat;
	public Material greenMat;

	// Use this for initialization
	void Start () {
		signalChange = 960;
	}
	
	// Update is called once per frame
	void Update () {
		step++;
		if (step == signalChange - 240 && signal) {
			signal = false;
			delay = true;
		}
		if (step == signalChange) {
			step = 0;
			if (!delay) {
				signal = !signal;
			}
		delay = false;
		}

		if (signal) {
			GetComponent<Renderer>().material = greenMat;
		} else {
			GetComponent<Renderer>().material = redMat;
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "CarView" && !signal) {
			other.gameObject.GetComponent<VehicleView>().isStop = true;
		}
	}

	private void OnTriggerStay(Collider other) {
		if (other.tag == "CarView" && signal) {
			other.gameObject.GetComponent<VehicleView>().isStop = false;
			other.gameObject.transform.parent.GetComponent<Vehicle>().speed = Random.Range(other.gameObject.transform.parent.GetComponent<Vehicle>().speed - 10f, other.gameObject.transform.parent.GetComponent<Vehicle>().speedLimit);
			other.gameObject.transform.parent.GetComponent<Renderer>().material = greenMat;
		}
	}
}
