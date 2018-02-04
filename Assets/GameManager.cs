using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool isRecording = false;
    //private GameObject player;

	// Use this for initialization
	void Start () {
        //player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            isRecording = false;
            //Playback();
        } else
        {
            isRecording = true;
            //Record();
        }
	}

    //void Record()
    //{
    //    ReplaySystem buffer = player.GetComponent<ReplaySystem>();
    //    buffer.Record();
    //}

    //void Playback ()
    //{
    //    ReplaySystem buffer = player.GetComponent<ReplaySystem>();
    //    buffer.PlayBack();
    //}
}
