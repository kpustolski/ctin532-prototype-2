using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

    public Text scoreNum;
    public Text timeNum;
    public float countDownNum;
    public GameObject floorObj;
    public GameObject bgObj;
    public Texture floorTexture;
    public Texture bgTexture;
    public GameObject discoBall;
    public GameObject discoBallEndPosition;
    public GameObject[] strobeLightsArray;
    public GameObject starParticleSystem;


    private bool discoBallMoved = false;
    private bool texturesSet = false;
    private bool lightsOn = false;
    private bool starParticlesStart = false;

    private float duration = 1.0f;
    private float alpha = 0f;
    // Use this for initialization
    void Start () {
        scoreNum = scoreNum.GetComponent<Text>();
        timeNum = timeNum.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
        // begin timer
        timer();
        // convert score text to int
        int s = Convert.ToInt32(scoreNum.text);
        // if the score reaches a certain number, add texture
        // make sure it only happens once
        if (s >= 300 && !texturesSet)
        {
            floorObj.GetComponent<Renderer>().material.mainTexture = floorTexture;
            bgObj.GetComponent<Renderer>().material.mainTexture = bgTexture;
            texturesSet = true;
        }
        // turn on dicso lights
        if (s >= 1000 && !lightsOn)
        {
            
            for(int i =0; i< strobeLightsArray.Length; i++)
            {
                if (i == 3)
                {
                    strobeLightsArray[i].GetComponent<DiscoLights>().enabled = true;
                }
                else
                {
                    strobeLightsArray[i].GetComponent<StrobeLights>().enabled = true;
                    
                }
            }
            lightsOn = true;
        }
        // move the discoball down
        if (s >= 1500 && !discoBallMoved)
        {

            iTween.MoveTo(discoBall, discoBallEndPosition.GetComponent<Transform>().position, 1.0f);
            discoBallMoved = true;
        }

        if (s >= 2000 && !starParticlesStart)
        {

            starParticleSystem.GetComponent<ParticleSystem>().Play();
            starParticlesStart = true;
        }

    }
    // add the timer element
    void timer()
    {
        countDownNum -= Time.deltaTime;
        timeNum.text = Mathf.Round(countDownNum).ToString();
        if (countDownNum < 0)
        {
           // Debug.Log("Times up!");
            Application.LoadLevel("gameOver");
        }
    }
}
