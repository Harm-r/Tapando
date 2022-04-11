using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PullUp : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    public ScrollRect scrollView;
    public RectTransform panel;
    private int top = Mathf.Max(Screen.height, 1920)-150;
    private int bottom = 0;

    private bool isTop = false;

    private bool dragging = false;


    void Start()
    {
        // Set the height of the panel to the screen height + 200
        panel.sizeDelta = new Vector2(panel.sizeDelta.x, Mathf.Max(1920,Screen.height) + 400);
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
        //Debug.Log(data.position.y);
        //Debug.Log(panel.anchoredPosition.y);
        if (!(data.position.y > panel.anchoredPosition.y - 100))
        {
            // is there a better way to do this?
            Debug.Log(data.position.y);
            Debug.Log(panel.anchoredPosition.y);
            Debug.Log("Je mag niet draggen!");
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
