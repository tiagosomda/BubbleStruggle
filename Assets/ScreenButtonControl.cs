using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenButtonControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public enum ActionButton { MoveLeft, MoveRight, Fire};
    public ActionButton action;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(action == ActionButton.MoveLeft)
        {
            PlayerMove.moveLeft = true;
        }
        else if(action == ActionButton.MoveRight)
        {
            PlayerMove.moveRight = true;
        } else
        {
            Chain.IsFiring = true;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (action == ActionButton.MoveLeft)
        {
            PlayerMove.moveLeft = false;
        }
        else if (action == ActionButton.MoveRight)
        {
            PlayerMove.moveRight = false;
        }
        //else
        //{
        //    Chain.IsFiring = true;
        //}
    }
}
