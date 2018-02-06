using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraPan : MonoBehaviour {

    public Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //Debug.Log("Horizontal2 " + CrossPlatformInputManager.GetAxis("Horizontal2"));
        //transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        transform.LookAt(player.transform);
	}
}
