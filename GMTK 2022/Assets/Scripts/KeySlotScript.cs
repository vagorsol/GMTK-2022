using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class KeySlotScript : MonoBehaviour, IDropHandler
{
    [SerializeField]
    Canvas menuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData) {
        RectTransform dragTransform = eventData.pointerDrag.GetComponent<RectTransform>();
        if (dragTransform != null) {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(menuCanvas.transform as RectTransform,
                                                                    eventData.position,
                                                                    menuCanvas.worldCamera,
                                                                    out pos);

            dragTransform.position = menuCanvas.transform.TransformPoint(pos);
        }
    }
}
