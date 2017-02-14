using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public int level;
    public GameManager gameManager;

    [Header("Ball Settings")]
    public Transform dropPosition;
    public Transform ballParent;

    public GameObject ballPrefab;

    public Color[] levelColors;

    [Header("HUD Settings")]

    public GameObject nextLevelPanel;
    public Text nextLevelText;

    public float animationTime;
    public float postAnimationDelay;
    public Color nextLevelAnimationColor;
    public int nextLevelAnimationFontSize;
    

    private bool playAnimation;
    private float animationCounter;
    private float postAnimationDelayCounter;
    private int fontSizeRegular;
    private Color nextColor;

    // Use this for initialization
    void Start () {
        fontSizeRegular = gameManager.gameScore.fontSize;
	}
	
	// Update is called once per frame
	void Update () {

        if(ballParent.childCount == 0 && !playAnimation)
        {
            playAnimation = true;
            animationCounter = animationTime;
            postAnimationDelayCounter = postAnimationDelay;
            level++;
            nextColor = GetColor(level);
            gameManager.gameScore.text = level.ToString();
            nextLevelPanel.SetActive(true);
        }

        if(playAnimation && animationCounter >= 0)
        {
            animationCounter -= Time.deltaTime;

            var color = Color.Lerp(nextColor, Color.white, animationCounter);
            gameManager.gameScore.color = color;

            var size = Mathf.Lerp(nextLevelAnimationFontSize, 0, animationCounter);
            gameManager.gameScore.fontSize = (int)size;
        }

        if(playAnimation && animationCounter <= 0)
        {
            postAnimationDelayCounter -= Time.deltaTime;
        }

        if(playAnimation && postAnimationDelayCounter <= 0)
        {
            nextLevelPanel.SetActive(false);
            NextLevel();
            playAnimation = false;
        }
	}

    public void NextLevel()
    {
        Debug.Log("NextLevel :" + level);
        //level++;
        //nextLevelNumber.text = level.ToString();

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
