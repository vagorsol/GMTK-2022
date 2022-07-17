using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class KeySlotScript : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private int ID = 0;

    [SerializeField]
    private Canvas menuCanvas;
    [SerializeField]
    private PhaserScript phaser;
    private RectTransform rTransform;
    private int id;

    void Awake() {
        rTransform = GetComponent<RectTransform>();
        id = ID++;
    }

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
        KeyScript ks = dragTransform.gameObject.GetComponent<KeyScript>();
        if (dragTransform != null && ks != null) {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(menuCanvas.transform as RectTransform,
                                                                    rTransform.position,
                                                                    menuCanvas.worldCamera,
                                                                    out pos);

            dragTransform.SetParent(transform, false);
            dragTransform.position = menuCanvas.transform.TransformPoint(pos);
            if (ks.position >= 0) {
                phaser.SetKey(-1, ks.position);
            }
            Debug.Log(id);
            ks.position = id;
            phaser.SetKey(ks.GetKey(), ks.position);
        }
    }
}
