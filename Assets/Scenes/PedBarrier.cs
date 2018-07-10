using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedBarrier : MonoBehaviour {

	public int step = 0;
	public int signalChange;
	bool delay = false;
	public Material redMat;
	public Material greenMat;

	// Use this for initialization
	void Start () {
		signalChange = 960;
		GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		step++;
		if (step == signalChange - 240 && !GetComponent<NavMeshObstacle>().enabled) {
			delay = true;
			GetComponent<NavMeshObstacle>().enabled = true;
		}
		if (step == signalChange) {
			step = 0;
			if (!delay) {
				GetComponent<NavMeshObstacle>().enabled = !(GetComponent<NavMeshObstacle>().enabled);
			}
			delay = false;
		}
	}
}
