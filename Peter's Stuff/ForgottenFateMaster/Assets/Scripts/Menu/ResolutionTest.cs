using UnityEngine;
using System.Collections;

public class ResolutionTest : MonoBehaviour {

	public int width;
	public int height;
	// Use this for initialization
	void Start () {
		Screen.SetResolution(1024, 768, true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Change () {

		Screen.SetResolution(width, height, true);
		Debug.Log ("the screen changed");
	}
}
