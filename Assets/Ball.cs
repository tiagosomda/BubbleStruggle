using UnityEngine;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour {

    public Vector2 startForce;
    public Rigidbody2D rb;

    public Transform parent;
    public GameObject nextBall;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(startForce, ForceMode2D.Impulse);

        parent = gameObject.transform.parent;
    }


    public void Split()
    {
        if(nextBall == null)
        {
            Destroy(gameObject);
            return;
        }

        var ball1 = Instantiate(nextBall, transform.position, Quaternion.identity);
        var ball2 = Instantiate(nextBall, transform.position, Quaternion.identity);

        ball1.gameObject.transform.SetParent(parent);
        ball2.gameObject.transform.SetParent(parent);

        ball1.GetComponent<Ball>().startForce = new Vector2(4f, 4f);
        ball2.GetComponent<Ball>().startForce = new Vector2(-4f, 4f);

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
