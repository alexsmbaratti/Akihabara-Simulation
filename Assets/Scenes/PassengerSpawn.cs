using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawn : MonoBehaviour {

	public Transform spawn;
    int step = 0;
	public int rate = 180;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		step++;
        if (step % rate == 0)
        {
	       var obj = Instantiate(spawn, new Vector3(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y, GetComponent<Transform>().position.z), Quaternion.identity);
        }
	}
}
