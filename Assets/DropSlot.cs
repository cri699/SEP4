using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler, IEndDragHandler
{
    public bool isOccupied;
    [SerializeField]
    private PlacingPhase pp;
    public int slotNumber;
    void Start()
    {
        isOccupied = false;
        pp = GameObject.FindGameObjectWithTag("PlacingPhase").GetComponent<PlacingPhase>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null && isOccupied !=true)
        {
            
                if (this.gameObject.tag.Equals("DropSlot") && Draggable.inPlacingPhase == true)
                {
                    d.placedSlot = this.slotNumber;
                    pp.addCard(eventData.pointerDrag.gameObject);
                    
                    isOccupied = true;
                    d.canBeDragged = false;
                d.wasPlaced = true;
                }
                else if(this.gameObject.tag.Equals("DropSlot"))
                {
                pp.addCardInRemember(eventData.pointerDrag.gameObject);
                d.rememberSlot = this.slotNumber;
                isOccupied = true;
                d.canBeDragged = false;
                }

                


            eventData.pointerDrag.transform.position = this.transform.position;
            if (this.transform.tag.Equals("inventory"))
            {
                Debug.Log("Got here");

                d.transform.SetParent(GameObject.Find("Content").transform);
                d.canBeDragged = true;
                return;
            }
            d.currentParent = this.transform;
            isOccupied = true;
            d.lastParent = this.transform;




        }

    }

    //public bool checkChild(GameObject go)
    //{

    //    if(this.transform.childCount == 1)
    //    {
    //        if(pp.CheckCard(this.transform.GetChild(0).gameObject) == false)
    //        {
    //            return 
    //        }
    //    }
            
    //}
    


    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if(d.currentParent == this.transform)
            {
               
                pp.addCard(eventData.pointerDrag.gameObject);
            }
        }
    }
}
