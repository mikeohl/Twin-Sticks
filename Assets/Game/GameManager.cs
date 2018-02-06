using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    private const string replayButton = "Jump";

    public bool isRecording = false;
    private float defaultFixedDeltaTime;
    private bool gamePaused = false;

	// Use this for initialization
	void Start () {
        defaultFixedDeltaTime = Time.fixedDeltaTime;
        PlayerPrefsManager.UnlockLevel(2);
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(1));
        Debug.Log(PlayerPrefsManager.IsLevelUnlocked(2));
    }
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButton(replayButton))
        {
            isRecording = false;
        } else
        {
            isRecording = true;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame(gamePaused);
            gamePaused = !gamePaused;
        }
	}

    void PauseGame (bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
        } else
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = defaultFixedDeltaTime;
        }
    }

    //private void OnApplicationPause(bool pause)
    //{
    //    PauseGame(pause);
    //}
}
