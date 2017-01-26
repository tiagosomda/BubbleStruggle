using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{

    public GameObject touchControls;
    private PlayerMove playerMove;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        touchControls.SetActive(playerMove.isTouchEnabled);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            playerMove.isTouchEnabled = !playerMove.isTouchEnabled;

            touchControls.SetActive(playerMove.isTouchEnabled);
        }

        if(playerMove.isTouchEnabled)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Chain.IsFiring = true;
        }

        playerMove.movement = Input.GetAxis("Horizontal");
    }
}
