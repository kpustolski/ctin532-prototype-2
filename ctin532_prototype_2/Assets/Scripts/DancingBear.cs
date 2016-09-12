using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DancingBear : MonoBehaviour {

    // there are 2 dance moves. Each of which has two textures.
    //dance 1
    public Texture bearDanceMaterial_1;
    public Texture bearDanceMaterial_2;
    //dance 2
    public Texture bearDanceMaterial_3;
    public Texture bearDanceMaterial_4;

    // game score text
    public Text scoreText;
    private int score=0;


    private bool danceMove2=false;
    // Use this for initialization
    void Start () {
        scoreText = scoreText.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
    // space key will change the textures. DanceMove2 determines if it's dance move one or two.
        if (Input.GetKeyDown("space") && !danceMove2)
        {
            // check to see if material is on dance move 2 and reset if it is to dance move 1.
            checkIfOnDanceTwo();

            // switch between textures 1 and 2 of dance move one with space bar.
            if (GetComponent<Renderer>().material.mainTexture == bearDanceMaterial_1)
            {
               
                GetComponent<Renderer>().material.mainTexture = bearDanceMaterial_2;

            }
            else if (GetComponent<Renderer>().material.mainTexture == bearDanceMaterial_2)
            {
               
                GetComponent<Renderer>().material.mainTexture = bearDanceMaterial_1;
            }

            score += 10;
        }
        //dance move 2
        if(Input.GetKeyDown("space") && danceMove2)
        {
            // check to see if material is on dance move 1 and reset if it is to dance move 2.
            checkIfOnDanceOne();

            // switch between textures 1 and 2 of dance move two with space bar.
            if (GetComponent<Renderer>().material.mainTexture == bearDanceMaterial_3)
            {
                
                GetComponent<Renderer>().material.mainTexture = bearDanceMaterial_4;

            }
            else if (GetComponent<Renderer>().material.mainTexture == bearDanceMaterial_4)
            {
                
                GetComponent<Renderer>().material.mainTexture = bearDanceMaterial_3;
            }

            score += 15;
        }
        // use down arrow to change between dance move one and two
        if(Input.GetKeyDown("down"))
        {

            if (!danceMove2)
            {
                danceMove2 = true;
            }
            else if (danceMove2)
            {
                danceMove2 = false;
            }

            score += 20;
        }

        UpdateScore();
	}

    // for organizational purposes, keep this code in its own functions
    void checkIfOnDanceTwo()
    {
        if (GetComponent<Renderer>().material.mainTexture == bearDanceMaterial_3)
        {
            GetComponent<Renderer>().material.mainTexture = bearDanceMaterial_1;
        }
        if (GetComponent<Renderer>().material.mainTexture == bearDanceMaterial_4)
        {
            GetComponent<Renderer>().material.mainTexture = bearDanceMaterial_1;
        }
    }

    void checkIfOnDanceOne()
    {
        if (GetComponent<Renderer>().material.mainTexture == bearDanceMaterial_1)
        {
            GetComponent<Renderer>().material.mainTexture = bearDanceMaterial_3;
        }
        if (GetComponent<Renderer>().material.mainTexture == bearDanceMaterial_2)
        {
            GetComponent<Renderer>().material.mainTexture = bearDanceMaterial_3;
        }
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
