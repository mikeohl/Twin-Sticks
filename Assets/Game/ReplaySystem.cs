using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 1000;
    private int frameCount = 0;
    private int endFrame = 0;
    private bool endPlayBack = false;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

    private Rigidbody rigidBody;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.isRecording)
        {
            if (endPlayBack)
            {
                frameCount = 0;
                endPlayBack = false;
            }
            Record();
        } else
        {
            PlayBack();
            endPlayBack = true;
        }
    }

    public void PlayBack ()
    {
        if (frameCount > 0)
        {
            rigidBody.isKinematic = true;
            int frame = (endFrame-frameCount) % bufferFrames;
            //Debug.Log("Reading frame " + frame);
            transform.position = keyFrames[frame].pos;
            transform.rotation = keyFrames[frame].rot;
            frameCount--;
        }
    }

    public void Record ()
    {
        if (frameCount < 1000) frameCount++;
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        //Debug.Log("Writing frame " + frame);
        keyFrames[frame] = new MyKeyFrame(Time.time, transform.position, transform.rotation);
        endFrame = Time.frameCount;
    }
}

/// <summary>
/// A structure for storing the time, position and rotation of dynamic objects in the game
/// </summary>
public struct MyKeyFrame
{
    public float time;
    public Vector3 pos;
    public Quaternion rot;

    public MyKeyFrame(float currentTime, Vector3 position, Quaternion rotation)
    {
        time = currentTime;
        pos = position;
        rot = rotation;
    }
}
