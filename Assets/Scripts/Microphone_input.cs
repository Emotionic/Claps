using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Microphone_input : MonoBehaviour {

    private AudioSource _audio;
    private LogViewer _viewer;
    public float sensitivity = 100;
    public float loudness = 0;
    public float lastLoudness;
    public LogViewer Viewer;

	// Use this for initialization
	void Start () {
        _audio = this.GetComponent<AudioSource>();
        _viewer = Viewer.GetComponent<LogViewer>();
        _audio.clip = Microphone.Start(null, true, 10, 44100);
        _audio.loop = true;
        //_audio.mute = true;
        while (!(Microphone.GetPosition(null) > 0)) { } // Wait until the recording has started
        _audio.Play(); // Play the audio source!

    }
	
	// Update is called once per frame
	void Update () {
        lastLoudness = loudness;
        loudness = lastLoudness * 0.8f + GetAveragedVolume() * sensitivity * 0.2f;
        //_viewer.AddLine("L : " + loudness);
        //loudness = GetAveragedVolume() * sensitivity;

    }
    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }

    public float DifLoudness
    {
        get
        {
            return loudness - lastLoudness;
        }
    }
}
