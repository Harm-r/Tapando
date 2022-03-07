using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PullUp : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public ScrollRect scrollView;
    public RectTransform panel;
    public int top = Screen.height-200;
    public int bottom;

    private bool isTop = false;

    private bool dragging = false;

    void FixedUpdate()
    {
        int center = (top - bottom) / 2;
        Debug.Log(scrollView.velocity.y);

        if (!this.dragging)
        {
            if (isTop)
            {
                if (panel.anchoredPosition.y > center * 1.5)
                {
                    LerpTo(top);
                }
                else
                {
                    LerpTo(bottom);
                }
            }
            else
            {
                if (panel.anchoredPosition.y < center * 0.5)
                {
                    LerpTo(bottom);
                }
                else
                {
                    LerpTo(top);
                }
            }
        }
    }

    void LerpTo(int position)
    {
        float newY = Mathf.Lerp(panel.anchoredPosition.y, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(panel.anchoredPosition.x, newY);
        
        panel.anchoredPosition = newPosition;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        int center = (top - bottom) / 2;
        this.dragging = true;
        if (panel.anchoredPosition.y > center)
        {
            this.isTop = true;
        }
        else
        {
            this.isTop = false;
        }
    }

    public void OnEndDrag(PointerEventData data)
    {
        this.dragging = false;
    }

}
