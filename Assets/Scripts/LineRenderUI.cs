using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRenderUI : MonoBehaviour
{
    [SerializeField] private RectTransform m_transform;
    [SerializeField] private Image m_image;

    public void CreateLine(Vector3 positionOne, Vector3 positionTwo, Color color)
    {
        m_image.color = color;
        Vector2 point1 = new Vector2(positionTwo.x, positionTwo.y);
        Vector2 point2 = new Vector2(positionOne.x, positionOne.y);
        Vector2 midpoint = (point1 + point2) / 2f;

        m_transform.position = midpoint;

        Vector2 dir = point1 - point2;
        m_transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        m_transform.localScale = new Vector3(dir.magnitude, 1f, 1f);
    }
}
