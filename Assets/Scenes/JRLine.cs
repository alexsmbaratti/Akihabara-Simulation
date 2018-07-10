using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JRLine : MonoBehaviour {

	public bool west = true;
	public float speed = 100.0f;
	Vector3 destination;
	bool isStopped;
	int step = 0;
	Vector3 freezePosition;
	GameObject barrier;
	public Transform spawn;

	// Use this for initialization
	void Start () {
		isStopped = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isStopped) {
		if (west) {
			GetComponent<Rigidbody>().velocity = new Vector3(100, 0, 0);
			if (GetComponent<Transform>().position.x > 500) {
				Destroy(gameObject);
			}
		} else {
			GetComponent<Rigidbody>().velocity = new Vector3(-100, 0, 0);
			if (GetComponent<Transform>().position.x < -500) {
				Destroy(gameObject);
			}
		}
		} else {
			step++;
			GetComponent<Transform>().position = freezePosition;
			if (step == 500) {
				isStopped = false;
				barrier.GetComponent<NavMeshObstacle>().enabled = true;
			}
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "TrainNode") {
			isStopped = true;
			freezePosition = GetComponent<Transform>().position;
			if (west) {
				barrier = GameObject.Find("North Barrier");
				for (int i = 0; i < 10; i++) {
				var obj = Instantiate(spawn, new Vector3(GetComponent<Transform>().position.x, 52f, GetComponent<Transform>().position.z - 5.0f), Quaternion.identity);
				}
			} else {
				barrier = GameObject.Find("South Barrier");
				for (int i = 0; i < 10; i++) {
				var obj = Instantiate(spawn, new Vector3(GetComponent<Transform>().position.x, 52f, GetComponent<Transform>().position.z + 5.0f), Quaternion.identity);
				}
			}
			barrier.GetComponent<NavMeshObstacle>().enabled = false;
		}
	}
}
