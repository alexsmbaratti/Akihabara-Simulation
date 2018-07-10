using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vehicle : MonoBehaviour {

	public float speed = 5.0f;
	Vector3 recordedPosition;
	int step = 0;
	public float speedLimit = 25.0f;
	public float initTime;

	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find("SpeedLimitSlider");
		speedLimit = obj.GetComponent<Slider>().value;
		speed = Random.Range(speedLimit - 10f, speedLimit);
		initTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < 60 && transform.position.x > -6 && transform.position.z < 130 && transform.position.z > 87 && speed == 0.0f) {
			step++;
			if (step > 180) {
				Debug.Log("Destroying collision");
				GameObject[] arr = GameObject.FindGameObjectsWithTag("Car");
				for (int i = 0; i < arr.Length; i++) {
					if (arr[i].GetComponent<Vehicle>().speed == 0) {
						Destroy(arr[i]);
					}
				}
				Destroy(gameObject);
			}
		} else {
			step = 0;
		}
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "StreetNode") {
			transform.position = other.transform.position;
			other.tag = "StreetNodeClosed";
			Transform[] nodes = other.GetComponent<VehicleNode>().nextNodes;
			if (nodes == null || nodes.Length == 0) {
				other.tag = "StreetNode";
				int temp = PlayerPrefs.GetInt("CarsProcessed");
				temp++;
				PlayerPrefs.SetInt("CarsProcessed", temp);
				float temp1 = PlayerPrefs.GetFloat("AverageCarTime");
				temp1 += (Time.time - initTime);
				PlayerPrefs.SetFloat("AverageCarTime", temp1);
				Destroy(gameObject);
			}
			if (nodes != null && nodes.Length > 0) {
				int rnd = Random.Range(0, nodes.Length);
				Vector3 dir = other.GetComponent<VehicleNode>().directions[rnd];
				GetComponent<Rigidbody>().velocity = dir * speed;
				transform.forward = dir;
			}
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.tag == "StreetNodeClosed") {
			other.tag = "StreetNode";
		}
	}
}
