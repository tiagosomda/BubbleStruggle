using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

    public Transform wallRight;
    public Transform wallLeft;
    public Transform wallTop;
    public Transform wallBottom;
    private Camera cam;

    private float mapX;
    private float mapY;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private float screenWidth;
    private float screenHeight;


	// Use this for initialization
	void Start () {


        UpdateCameraValues();
        UpdateWalls();

        Debug.Log(string.Format("min : {0}/{1} max: {2}/{3}", minX, minY, maxX, maxY));
        
    }

    void UpdateBottomWall(Transform wall)
    {
        var pos = wall.position;
        pos.y = maxY;

        wall.transform.position = pos;

        var scale = wall.localScale;
        scale.x = (Mathf.Abs(maxX) + Mathf.Abs(minX));
        wall.localScale = scale;
    }

    void UpdateTopWall(Transform wall)
    {
        var pos = wall.position;
        pos.y = minY;

        wall.transform.position = pos;

        var scale = wall.localScale;
        scale.x = (Mathf.Abs(maxX) + Mathf.Abs(minX));
        wall.localScale = scale;
    }

    void UpdateLeftWall(Transform wall)
    {
        var pos = wall.position;
        pos.x = minX;

        wall.transform.position = pos;

        var scale = wall.localScale;
        scale.y = (Mathf.Abs(maxY) + Mathf.Abs(minY));
        wall.localScale = scale;
    }

    void UpdateRightWall(Transform wall)
    {
        var pos = wall.position;
        pos.x = maxX;

        wall.transform.position = pos;

        var scale = wall.localScale;
        scale.y = (Mathf.Abs(maxY) + Mathf.Abs(minY));
        wall.localScale = scale;
    }


    void UpdateCameraValues()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        var vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;
    }


    void UpdateWalls()
    {
        UpdateBottomWall(wallBottom);
        UpdateTopWall(wallTop);
        UpdateLeftWall(wallLeft);
        UpdateRightWall(wallRight);
    }

    // Update is called once per frame
    void Update () {

        if(screenHeight != Screen.height || screenWidth != Screen.width)
        {
            Debug.Log("Update Walls...");
            UpdateCameraValues();
            UpdateWalls();
        }
    }
}
