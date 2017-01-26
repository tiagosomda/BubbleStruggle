using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    public bool keyboardEnabled;
    private float horizontal;
    private void Update()
    {
        if(!keyboardEnabled)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Chain.IsFiring = true;
        }


        horizontal = Input.GetAxis("Horizontal");
        if(horizontal < 0)
        {
            PlayerMove.moveLeft = true;
        } else if (horizontal > 0)
        {
            PlayerMove.moveRight = true;
        } else
        {
            PlayerMove.moveLeft = PlayerMove.moveRight = false;
        }
    }
}
