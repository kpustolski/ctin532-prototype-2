using UnityEngine;
using System.Collections;

public class StrobeLights : MonoBehaviour {

    //https://www.youtube.com/watch?v=DhoXfhHamxY
    public float time;
    private bool isStrobe=true;
	// Use this for initialization
	void Start () {
        StartCoroutine("Flicker");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator Flicker()
    {
        while (isStrobe)
        {
            GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(time);
            GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(time);
        }

    }
}
