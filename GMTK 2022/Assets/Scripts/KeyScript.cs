using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class KeyScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Canvas canvas;
    [SerializeField]
    private Text keyNumber;
    private RectTransform rectTransform; 
    private CanvasGroup canvasGroup;
    private int key;
    public int position { get; set; } = -1;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData) {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void SetCanvas(Canvas cv) {
        canvas = cv;
    }

    public int GetKey() {
       return key;
    }

    public void SetKey(int k) {
        key = k;
        keyNumber.text = key.ToString("000");
    }
}
