using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MasterScript : MonoBehaviour {

	public GameObject train;
	int step = 0;
	bool isNS = false;

	// Crosswalks
	GameObject cwNorth;
	GameObject cwSouth;
	GameObject cwEast;
	GameObject cwWest;

	// Traffic Signals
	GameObject trafficNorth;
	GameObject trafficSouth;
	GameObject trafficEast;
	GameObject trafficWest;

	// Pesdestrian Barrier
	GameObject pedNorth;
	GameObject pedSouth;
	GameObject pedEast;
	GameObject pedWest;

	GameObject camera;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("AgentsProcessed", 0);
		PlayerPrefs.SetFloat("AverageTime", 0f);
		PlayerPrefs.SetFloat("Timer", 0f);
		PlayerPrefs.SetInt("CarsProcessed", 0);
		PlayerPrefs.SetFloat("AverageCarTime", 0f);

		cwNorth = GameObject.Find("Crosswalk North");
		cwSouth = GameObject.Find("Crosswalk South");
		cwEast = GameObject.Find("Crosswalk East");
		cwWest = GameObject.Find("Crosswalk West");

		trafficNorth = GameObject.Find("TrafficSignal North");
		trafficSouth = GameObject.Find("TrafficSignal South");
		trafficEast = GameObject.Find("TrafficSignal East");
		trafficWest = GameObject.Find("TrafficSignal West");

		pedNorth = GameObject.Find("Ped Barrier North");
		pedSouth = GameObject.Find("Ped Barrier South");
		pedEast = GameObject.Find("Ped Barrier East");
		pedWest = GameObject.Find("Ped Barrier West");

		GameObject obj = GameObject.Find("SpeedLimitSlider");
		PlayerPrefs.SetInt("SpeedLimit", (int) obj.GetComponent<Slider>().value);
		obj = GameObject.Find("PedSpawnSlider");
		PlayerPrefs.SetInt("PedSpawn", (int) obj.GetComponent<Slider>().value);
		obj = GameObject.Find("TrafficSignalSlider");
		PlayerPrefs.SetInt("SignalRate", (int) obj.GetComponent<Slider>().value);

		camera = GameObject.Find("Main Camera");
		camera.GetComponent<Transform>().position = new Vector3(25, 25, 250);
		camera.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, 180, 0));

		trafficEast.GetComponent<TrafficBarrier>().signal = true;
		trafficWest.GetComponent<TrafficBarrier>().signal = true;

		pedNorth.GetComponent<NavMeshObstacle>().enabled = false;
		pedSouth.GetComponent<NavMeshObstacle>().enabled = false;
		pedEast.GetComponent<NavMeshObstacle>().enabled = true;
		pedWest.GetComponent<NavMeshObstacle>().enabled = true;

		cwNorth.GetComponent<Renderer>().enabled = false;
		cwSouth.GetComponent<Renderer>().enabled = false;
		cwEast.GetComponent<Renderer>().enabled = false;
		cwWest.GetComponent<Renderer>().enabled = false;

		// changeTrafficFlow();
	}
	
	// Update is called once per frame
	void Update () {
			step++;
			if (step % 900 == 0) { // Spawn Train
			step = 0;
			int rand = Random.Range(0, 2);
				GameObject obj;
				if (rand == 0) {
					obj = Instantiate(train, new Vector3(-480, 65, -170), Quaternion.identity);
					obj.GetComponent<JRLine>().west = true;
				} else {
					obj = Instantiate(train, new Vector3(480, 65, -150), Quaternion.identity);
					obj.GetComponent<JRLine>().west = false;
				}
		}
	}

	public void TimeScaleSlider() {
		GameObject obj = GameObject.Find("TimeSlider");
		Time.timeScale = obj.GetComponent<Slider>().value;
	}

	public void Position1() {
		camera.GetComponent<Transform>().position = new Vector3(25, 25, 250);
		camera.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, 180, 0));
	}

	public void Position2() {
		camera.GetComponent<Transform>().position = new Vector3(25, 90, 108);
		camera.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(90, 180, 0));
	}

	public void Position3() {
		camera.GetComponent<Transform>().position = new Vector3(160, 180, -160);
		camera.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(90, 180, 0));
	}

	public void ToggleHiddenElements() {
		GameObject.Find("Plane (1)").GetComponent<MeshRenderer>().enabled = !GameObject.Find("Plane (1)").GetComponent<MeshRenderer>().enabled;
		GameObject.Find("Plane (2)").GetComponent<MeshRenderer>().enabled = !GameObject.Find("Plane (2)").GetComponent<MeshRenderer>().enabled;;
		GameObject.Find("Plane (3)").GetComponent<MeshRenderer>().enabled = !GameObject.Find("Plane (3)").GetComponent<MeshRenderer>().enabled;;
		GameObject.Find("Plane (4)").GetComponent<MeshRenderer>().enabled = !GameObject.Find("Plane (4)").GetComponent<MeshRenderer>().enabled;;
	}

	public void changeSignalRate() {
		GameObject obj = GameObject.Find("TrafficSignalSlider");
		GameObject.Find("TrafficSignal East").GetComponent<TrafficBarrier>().signalChange = (int) obj.GetComponent<Slider>().value;
		GameObject.Find("TrafficSignal West").GetComponent<TrafficBarrier>().signalChange = (int) obj.GetComponent<Slider>().value;
		GameObject.Find("TrafficSignal North").GetComponent<TrafficBarrier>().signalChange = (int) obj.GetComponent<Slider>().value;
		GameObject.Find("TrafficSignal South").GetComponent<TrafficBarrier>().signalChange = (int) obj.GetComponent<Slider>().value;

		GameObject.Find("Ped Barrier South").GetComponent<PedBarrier>().signalChange = (int) obj.GetComponent<Slider>().value;
		GameObject.Find("Ped Barrier North").GetComponent<PedBarrier>().signalChange = (int) obj.GetComponent<Slider>().value;
		GameObject.Find("Ped Barrier West").GetComponent<PedBarrier>().signalChange = (int) obj.GetComponent<Slider>().value;
		GameObject.Find("Ped Barrier East").GetComponent<PedBarrier>().signalChange = (int) obj.GetComponent<Slider>().value;

		GameObject.Find("TrafficSignal East").GetComponent<TrafficBarrier>().step = 0;
		GameObject.Find("TrafficSignal West").GetComponent<TrafficBarrier>().step = 0;
		GameObject.Find("TrafficSignal North").GetComponent<TrafficBarrier>().step = 0;
		GameObject.Find("TrafficSignal South").GetComponent<TrafficBarrier>().step = 0;

		GameObject.Find("Ped Barrier South").GetComponent<PedBarrier>().step = 0;
		GameObject.Find("Ped Barrier North").GetComponent<PedBarrier>().step = 0;
		GameObject.Find("Ped Barrier West").GetComponent<PedBarrier>().step = 0;
		GameObject.Find("Ped Barrier East").GetComponent<PedBarrier>().step = 0;
	}

	public void changePedSpawn() {
		GameObject obj = GameObject.Find("PedSpawnSlider");
		GameObject[] arr = GameObject.FindGameObjectsWithTag("Respawn");
				for (int i = 0; i < arr.Length; i++) {
					arr[i].GetComponent<Spawner>().rate = (int) obj.GetComponent<Slider>().value;
				}
	}

	public void changeSpeedLimit() {
		GameObject obj = GameObject.Find("SpeedLimitSlider");
		GameObject[] arr = GameObject.FindGameObjectsWithTag("Car");
				for (int i = 0; i < arr.Length; i++) {
					arr[i].GetComponent<Vehicle>().speedLimit = obj.GetComponent<Slider>().value;
					Debug.Log(arr[i].GetComponent<Vehicle>().speedLimit);
				}
	}
}
