using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FireButtonBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public Color onPress;
    public Color onRelease;
    public BoolEvent IsButtonDown;

    private Image background;


    private void Awake()
    {
        background = GetComponent<Image>();
        background.color = onRelease;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        background.color = onPress;
        IsButtonDown.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        background.color = onRelease;
        IsButtonDown.Invoke(false);
    }
}
