using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PullUp : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public ScrollRect scrollView;
    public RectTransform panel;
    public RectTransform canvas;
    private int top;
    private int bottom = 0;

    private bool isTop = false;

    private bool dragging = false;


    void Start()
    {
        this.top = (int)canvas.sizeDelta.y - 150; // 150 is the height of the scroll view
        // Set the height of the panel to the screen height + 400
        panel.sizeDelta = new Vector2(panel.sizeDelta.x, (int)canvas.sizeDelta.y + 400);
        // Allow vertical scrolling
        scrollView.vertical = true;
    }

    void FixedUpdate()
    {
        int center = (this.top - this.bottom) / 2;

        if (!this.dragging)
        {
            if (isTop)
            {
                if (panel.anchoredPosition.y > center * 1.5)
                {
                    LerpTo(this.top);
                }
                else
                {
                    LerpTo(this.bottom);
                }
            }
            else
            {
                if (panel.anchoredPosition.y < center * 0.5)
                {
                    LerpTo(this.bottom);
                }
                else
                {
                    LerpTo(this.top);
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
        double relativeY = data.position.y * (canvas.sizeDelta.y / Screen.height);

        if (!(relativeY > panel.anchoredPosition.y - 100))
        {
            scrollView.vertical = false;
            return;
        }
        else
        {
            scrollView.vertical = true;
        }

        int center = (this.top - this.bottom) / 2;
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
