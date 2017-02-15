using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int level;
    public GameManager gameManager;

    [Header("Ball Settings")]
    public Transform dropPosition;
    public Transform ballParent;

    public GameObject ballPrefab;
    public Color[] levelColors;  

    private bool playAnimation;
    private float animationCounter;
    private float postAnimationDelayCounter;
    private int fontSizeRegular;
    private Color nextColor;

    // game over variables
    private bool gameOverState;
    private float gameOverAnimationCounter;

    // Use this for initialization
    void Start () {
        fontSizeRegular = gameManager.gameScore.fontSize;
        gameOverState = false;

    }
	
	// Update is called once per frame
	void Update () {

        if(gameOverState)
        {
            GameOverLoop();
            return;
        }

        GameLoop();

    }


    public void GameLoop()
    {
        if (ballParent.childCount == 0 && !playAnimation)
        {
            playAnimation = true;
            animationCounter = gameManager.animationTime;
            postAnimationDelayCounter = gameManager.postAnimationDelay;
            level++;
            nextColor = GetColor(level);
            gameManager.gameScore.text = level.ToString();
            gameManager.gameHUD.SetActive(true);
        }

        if (playAnimation && animationCounter >= 0)
        {
            animationCounter -= Time.deltaTime;

            var color = Color.Lerp(nextColor, Color.white, animationCounter);
            gameManager.gameScore.color = color;

            var size = Mathf.Lerp(gameManager.nextLevelAnimationFontSize, 0, animationCounter);
            gameManager.gameScore.fontSize = (int)size;
        }

        if (playAnimation && animationCounter <= 0)
        {
            postAnimationDelayCounter -= Time.deltaTime;
        }

        if (playAnimation && postAnimationDelayCounter <= 0)
        {
            gameManager.gameHUD.SetActive(false);
            NextLevel();
            playAnimation = false;
        }
    }

    public void GameOverLoop()
    {

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

    public void SetGameOver()
    {
        gameOverState = true;
        gameManager.gameEntities.SetActive(false);
        gameManager.gameOverHUD.SetActive(true);
        gameManager.scoreNumber.text = level.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
