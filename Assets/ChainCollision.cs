using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCollision : MonoBehaviour {

    private Chain chain;

    private void Start()
    {
        chain = GetComponentInParent<Chain>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        chain.SetNotFiring();

        if (collision.tag == "Ball")
        {

            //transform.position = chain.player.position;
            //transform.localScale = chain.NotFired;

            collision.gameObject.GetComponent<Ball>().Split();
        }
    }

}
