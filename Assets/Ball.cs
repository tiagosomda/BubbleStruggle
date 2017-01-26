using UnityEngine;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour {

    public float size;
    public float decreaseRate;

    public Vector2 startForce;
    public Rigidbody2D rb;

    public Transform parent;
    public GameObject nextBall;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(startForce, ForceMode2D.Impulse);
        parent = gameObject.transform.parent;

        transform.localScale = new Vector3(size, size, 1);
    }


    public void Split()
    {
        if(size-decreaseRate < 0.4)
        {
            Destroy(gameObject);
            return;
        }
        //if(nextBall == null)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        var ball1 = Instantiate(this, transform.position, Quaternion.identity);
        var ball2 = Instantiate(this, transform.position, Quaternion.identity);

        ball1.gameObject.transform.SetParent(parent);
        ball2.gameObject.transform.SetParent(parent);

        ball1.GetComponent<Ball>().startForce = new Vector2(4f, 4f);
        ball1.GetComponent<Ball>().size = size - decreaseRate;

        ball2.GetComponent<Ball>().startForce = new Vector2(-4f, 4f);
        ball2.GetComponent<Ball>().size = size - decreaseRate;

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
