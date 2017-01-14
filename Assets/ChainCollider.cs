using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Chain.IsFiring = false;
    }
}
