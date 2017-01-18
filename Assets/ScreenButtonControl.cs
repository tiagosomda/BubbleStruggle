using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenButtonControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isMoveLeft;

    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerControl.movement += isMoveLeft ? -1f : 1f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerControl.movement += !isMoveLeft ? -1f : 1f;
    }
}
