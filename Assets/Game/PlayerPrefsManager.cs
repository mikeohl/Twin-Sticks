using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	public static void SetMasterVolume (float volume) {
		if (volume >= 0.0f && volume <= 1.0f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master volume out of range");
		}
	}
	
	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel (int level) {
		if (level <= Application.levelCount - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1);
		} else {
			Debug.LogError ("Cannot unlock level not in build order");
		}
	}
	
	public static bool IsLevelUnlocked (int level) {
		if (level <= Application.levelCount - 1) {
			if (PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ()) == 1) {
				return true;
			}
		} else {
			Debug.LogError ("Cannot check level not in build order");
		}
		return false;
	}
	
	public static void SetDifficulty (float difficulty) {
		Slider slider = GameObject.FindObjectOfType<Slider>();
		if (difficulty >= slider.minValue && difficulty <= slider.maxValue) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Difficulty must be in range 1 to 3");
		}
	}
	
	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat (DIFFICULTY_KEY);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
