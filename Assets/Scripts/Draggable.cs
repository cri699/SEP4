using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform currentParent= null;
    public Transform lastParent = null;
    private PlacingPhase pp;
    public bool canBeDragged = true;
    public int placedSlot;
    public int rememberSlot;

    public bool wasPlaced = false;

    public static bool inPlacingPhase = true;

    void Start()
    {
        pp = GameObject.FindGameObjectWithTag("PlacingPhase").GetComponent<PlacingPhase>();
    }
    void Update()
    {
        //GetComponent<LayoutElement>().preferredHeight +=1;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canBeDragged)
        {
            DropSlot ds = this.transform.parent.GetComponent<DropSlot>();

            if (ds != null && ds.isOccupied == true)
            {
                ds.isOccupied = false;
                pp.removeCard(eventData.pointerDrag.gameObject);
            }
            currentParent = this.transform.parent;
            Debug.Log("Beggined dragging");
            AudioManagerScript.instance.playCardDraw();    //audio
            this.transform.SetParent(GameObject.Find("Canvas").transform);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        

       
        
    }

    public void OnDrag(PointerEventData eventData)
    {

        if (canBeDragged)
        {
            Debug.Log("DRAGGIN'");

            this.transform.position = eventData.position;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canBeDragged)
        {

            
            
            //Debug.Log("DRAG ENDED");
            //DropSlot ds = currentParent.GetComponent<DropSlot>();

            //if (!currentParent.transform.name.Equals("Content"))
            //{
            //    if (pp.CheckCard(eventData.pointerDrag.gameObject) == false)
            //    {
            //        Debug.Log("I get here IN FIRST ONE");
            //        if (inPlacingPhase == true)
            //        {
            //            pp.addCard(eventData.pointerDrag.gameObject);
            //        } else
            //        {
            //            pp.addCardInRemember(eventData.pointerDrag.gameObject);
            //        }

                    
            //    }
            //}

            //if (currentParent.transform.name.Equals("Content"))
            //{
            //    Debug.Log("I get here");
            //    currentParent.GetComponent<DropSlot>().isOccupied = false;
            //    currentParent = GameObject.Find("Content").transform;
            //    this.transform.parent = currentParent;
            //    GetComponent<CanvasGroup>().blocksRaycasts = true;
            //    return;

            //}


            //if (ds != null)
            //{
            //    ds.isOccupied = true;

            //}
            

            this.transform.SetParent(currentParent);
            
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}
