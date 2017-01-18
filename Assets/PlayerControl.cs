using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public static bool moveLeft;
    public static bool moveRight;

    public Rigidbody2D rb;
    public float movement;
    public float speed = 4f;

    public Transform parent;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        moveLeft = moveRight = false;

    }

    public void Move(float _movement)
    {
        movement = _movement * speed;
    }

	// Update is called once per frame
	void Update () {
        //movement = Input.GetAxis("Horizontal") * speed;

        if (parent.childCount == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void FixedUpdate()
    {
        movement = (moveLeft ? -1 : 0) + (moveRight ? 1 : 0);

        rb.MovePosition(rb.position + new Vector2(movement * speed * Time.fixedDeltaTime, 0f));
    }
}
