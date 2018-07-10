using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PassengerTrain : MonoBehaviour {

	public GameObject goal;
	public float dis;

	// Use this for initialization
	void Start () {
		goal = GameObject.Find("ped_train_destination");
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		GetComponent<NavMeshAgent>().speed = 15.0f;
		agent.SetDestination(new Vector3(goal.GetComponent<Transform>().position.x, goal.GetComponent<Transform>().position.y, goal.GetComponent<Transform>().position.z));
	}
	
	// Update is called once per frame
	void Update () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(new Vector3(goal.GetComponent<Transform>().position.x, goal.GetComponent<Transform>().position.y, goal.GetComponent<Transform>().position.z));
		if (GetComponent<NavMeshAgent>().isStopped == false) {
			dis = Vector3.Distance(transform.position, goal.GetComponent<Transform>().position);
			if (dis < 2) {
				Destroy(gameObject);
			}
		}
	}
}
