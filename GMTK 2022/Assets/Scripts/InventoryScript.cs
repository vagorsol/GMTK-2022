using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class InventoryScript : MonoBehaviour, IDropHandler
{
    [SerializeField]
    private PhaserScript phaser;
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
            dragTransform.SetParent(gameObject.GetComponent<GridLayoutGroup>().transform, false);
            if (ks.position >= 0) {
                phaser.SetKey(-1, ks.position);
            }
            ks.position = -1;
        }
        
    }
}
