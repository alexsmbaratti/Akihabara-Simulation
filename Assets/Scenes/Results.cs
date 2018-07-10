using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Results : MonoBehaviour {

	GameObject uiAgents;
	GameObject uiTime;
	GameObject saveButton;
	GameObject saveText;
	GameObject uiAverage;
	int agents;
	float time;
	float avgTime;

	// Use this for initialization
	void Start () {
		agents = PlayerPrefs.GetInt("AgentsProcessed");
		uiAgents = GameObject.Find("Goal Reaching Agents");
		uiTime = GameObject.Find("Time");
		uiAverage = GameObject.Find("Average Time");
		time = PlayerPrefs.GetFloat("Timer");
		avgTime = PlayerPrefs.GetFloat("AverageTime");
		avgTime = avgTime / agents;
		saveButton = GameObject.Find("Save");
		saveText = GameObject.Find("SaveText");
		saveText.GetComponent<Text>().text = "Save Results";
		saveButton.GetComponent<Button>().interactable = true;
	}
	
	// Update is called once per frame
	void Update () {
		uiAgents.GetComponent<Text>().text = "Agents that reached their goal: " + agents;
		uiTime.GetComponent<Text>().text = "Time: " + time.ToString("F2") + " seconds";
		uiAverage.GetComponent<Text>().text = "Average Pedestrian Time: " + avgTime.ToString("F2") + " seconds";
	}

	public void ReturnToTitle() {
		Application.LoadLevel("Title Scene");
	}

	public void FSE394WriterFile() {
		string filename = Application.dataPath + "/akihabara.txt";
		if (File.Exists(filename)) {
			saveText.GetComponent<Text>().text = "File Already Exists!";
			return;
		}
		StreamWriter sw = File.CreateText(filename);
		sw.WriteLine("-- AKIHABARA SIMULATION --");
		sw.WriteLine("Agents that reached their goal: {0}", agents);
		sw.WriteLine("Time: {0}", time.ToString("F2"));
		int spdLimit = PlayerPrefs.GetInt("SpeedLimit");
		int spwnRate = PlayerPrefs.GetInt("PedSpawn");
		int signalRate = PlayerPrefs.GetInt("SignalRate");
		sw.WriteLine("Settings Used");
		sw.WriteLine("Speed Limit: {0}", spdLimit);
		sw.WriteLine("Spawn Rate: {0}", spwnRate);
		sw.WriteLine("Signal Rate: {0}", signalRate);
		sw.Close();
		
		saveText.GetComponent<Text>().text = "Results Saved!";
		saveButton.GetComponent<Button>().interactable = false;
	}
}
