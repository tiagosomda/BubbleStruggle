using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    [Header("Game")]
    public GameObject gameEntities;

    [Header("Game UI")]
    public GameObject gameHUD;
    public Text gameScore;

    public float animationTime;
    public float postAnimationDelay;
    public Color nextLevelAnimationColor;
    public int nextLevelAnimationFontSize;

    [Header("Game Over UI")]
    public GameObject gameOverHUD;
    public Text scoreNumber;
    public float gameOverAnimationTime;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
