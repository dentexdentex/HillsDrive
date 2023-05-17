using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonGo : MonoBehaviour,IPointerUpHandler,IPointerDownHandler

{
    public CarController _carController;
    
    public bool basıyomu=false;
    
    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("upupupup");
       basıyomu = false;
    }

    public void OnPointerDowniLERİ()
    {
        basıyomu = true;
        if(basıyomu)
           _carController.ileri();
    }
  
    public void OnPointerDown(PointerEventData eventData)
    {
        basıyomu = true;
        if(basıyomu)
            _carController.ileri();
    }
}
