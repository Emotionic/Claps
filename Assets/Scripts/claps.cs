using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class claps : MonoBehaviour
{

    private Microphone_input _loudness;
    public Microphone_input loudness;
    private int fps_count=0;
    private int clap_count=0;

	// Use this for initialization
	void Start ()
    {
        _loudness = loudness.GetComponent<Microphone_input>();   
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.GetComponent<Text>().text = clap_count.ToString();

        if (_loudness.loudness >= 15)
        {
            fps_count++;
        }
        else
        {
            if(1<=fps_count&&fps_count<=10)
            {
                clap_count++;

            }
            fps_count = 0;
        }
	}
}
