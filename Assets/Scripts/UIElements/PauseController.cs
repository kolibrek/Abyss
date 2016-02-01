using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseController : MonoBehaviour {

	bool isPaused;

	// Use this for initialization
	void Start () {
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Pause();
		}
		if (Input.GetKeyDown(KeyCode.Q) && isPaused) {
			Quit();
		}
	}

	public void Pause() {
		if (!isPaused) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
		isPaused = !isPaused;
	}

	public void Quit() {
		#if UNITY_EDITOR 
		EditorApplication.isPlaying = false;
		#else 
		Application.Quit();
		#endif
	}
}
