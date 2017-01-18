using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenButtonControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isMoveLeft;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(isMoveLeft)
        {
            PlayerControl.moveLeft = true;
        }
        else
        {
            PlayerControl.moveRight = true;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMoveLeft)
        {
            PlayerControl.moveLeft = false;
        }
        else
        {
            PlayerControl.moveRight = false;
        }
    }
}
