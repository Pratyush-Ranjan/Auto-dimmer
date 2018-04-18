using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

static class StaticSettings
{
    public static bool AutoDimmer { get; set; }
}

public class ScoreScript : MonoBehaviour {
    public Toggle AutodimmerToggle;
    public Text ScoreText;

    double score;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    void OnGUI()
    {
        //StaticSettings.AutoDimmer = GUI.Toggle(new Rect(20, 10,20, 40),StaticSettings.AutoDimmer, "");

        ScoreText.text = "Score: " + score.ToString("0");
    
    }
	
	void Update () {
        score += rb.velocity.magnitude * Time.deltaTime * 0.1;
	}
}
