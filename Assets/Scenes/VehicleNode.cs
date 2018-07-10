using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleNode : MonoBehaviour {

	public Transform[] nextNodes;
	public Vector3[] directions;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().enabled = false;
		if (nextNodes == null) return;
		directions = new Vector3[nextNodes.Length];
		for (int i = 0; i < nextNodes.Length; i++) {
			directions[i] = Vector3.Normalize(nextNodes[i].position - transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
