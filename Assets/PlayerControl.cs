using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public Button moveLeft;
    public Button moveRight;

    public Rigidbody2D rb;
    public static float movement;
    public float speed = 4f;

    public Transform parent;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
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
        rb.MovePosition(rb.position + new Vector2(movement * speed * Time.fixedDeltaTime, 0f));
    }
}
