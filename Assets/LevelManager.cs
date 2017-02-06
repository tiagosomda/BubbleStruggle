using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public int level;
    [Header("Ball Settings")]
    public Transform dropPosition;
    public Transform ballParent;

    public GameObject ballPrefab;

    public Color[] levelColors;

    [Header("HUD Settings")]

    public GameObject nextLevelPanel;
    public Text nextLevelText;
    public Text nextLevelNumber;

    // Use this for initialization
    void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {

        if(ballParent.childCount == 0)
        {
            NextLevel();
        }
	}


    public void NextLevel()
    {
        Debug.Log("NextLevel :" + level);
        level++;

        nextLevelNumber.text = level.ToString();

        var ball = Instantiate(ballPrefab, dropPosition.position, Quaternion.identity, ballParent);

        var script = ball.GetComponent<Ball>();
        script.size = 0.4f * level;
        script.decreaseRate = 0.4f;
        script.startForce = new Vector2(4f, 4f);

        //var sprite = ball.GetComponent<SpriteRenderer>();

        //sprite.color = GetColor(level);

        script.level = level;

        script.levelManager = this;
    }

    public Color GetColor(int level)
    {
        if(level -1 > levelColors.Length)
        {
            level = 1;
        }

        return levelColors[level - 1];
    }

}
