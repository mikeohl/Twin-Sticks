using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SelfieStick : MonoBehaviour {

    public Player player;
    public float panSpeed = 1f;
    private Vector3 armRotation;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        armRotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        armRotation.y += CrossPlatformInputManager.GetAxis("Horizontal2") * panSpeed;
        armRotation.x += CrossPlatformInputManager.GetAxis("Vertical2") * panSpeed;
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(armRotation);
    }
}