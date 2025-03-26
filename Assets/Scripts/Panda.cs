using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda : MonoBehaviour
{
    [SerializeField]
    private Transform pandaPlace;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    public static bool locked;
    private bool isDragging = false;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Touch Screen
        if (Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                        isDragging = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    CheckPosition();
                    break;
            }
        }
    }

    private void OnMouseDown()
    {
        if (!locked)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
            {
                deltaX = mousePos.x - transform.position.x;
                deltaY = mousePos.y - transform.position.y;
                isDragging = true;
            }
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging && !locked)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePos.x - deltaX, mousePos.y - deltaY);
        }
    }

    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            CheckPosition();
        }
    }

    private void CheckPosition()
    {
        if (Mathf.Abs(transform.position.x - pandaPlace.position.x) <= 0.5f &&
            Mathf.Abs(transform.position.y - pandaPlace.position.y) <= 0.5f)
        {
            transform.position = new Vector2(pandaPlace.position.x, pandaPlace.position.y);
            locked = true;
        }
        else
        {
            transform.position = initialPosition;
        }
    }
}