using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupBoundaries : MonoBehaviour
{
    [SerializeField] bool isTop;

    float padding;

    Vector2 yBounds;
    void Start()
    {
        padding = transform.localScale.y;
        transform.localScale = new Vector2(Screen.width, padding);

        if (isTop)
        {
            yBounds = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            Vector2 newPos = new Vector2(0, yBounds.y - padding);
        }
        else
        {
            yBounds = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 newPos = new Vector2(0, yBounds.y + padding);
        }
    }
}
