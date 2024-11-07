using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragnDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    [SerializeField] private Canvas m_canvas;

    private RectTransform m_rectTransform;
    private CanvasGroup m_canvasGroup;
    private Vector2 m_startPos;
    public UseCard use;

    private void Awake()
    {
        m_canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        m_rectTransform = GetComponent<RectTransform>();
        m_canvasGroup = GetComponent<CanvasGroup>();
        use = GetComponent<UseCard>();
    }
    private void Start()
    {
        m_canvasGroup.blocksRaycasts = true;
    }

    public void OnBeginDrag(PointerEventData _data)
    {
        Debug.Log("OnBeginDrag");
        use.beingDragged = true;
        m_startPos = GetComponent<RectTransform>().position;
        m_canvasGroup.alpha = .6f;
        m_canvasGroup.blocksRaycasts = false;
        
    }

    public void OnDrag(PointerEventData _data)
    {
        Debug.Log("Dragging");
        m_rectTransform.anchoredPosition += _data.delta / m_canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData _data)
    {
        Debug.Log("OnEndDrag");
        use.beingDragged = false;
        m_canvasGroup.alpha = 1f;
        GetComponent<RectTransform>().position = m_startPos;
        m_canvasGroup.blocksRaycasts = true;
        

    }

    public void OnDrop(PointerEventData _data)
    {

    }
}