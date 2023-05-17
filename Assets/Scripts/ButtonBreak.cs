using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBreak : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public CarController _carController;
    public bool basıyomu;
    public void OnpointerdOWNGERİ()
    {
        basıyomu = true;
        _carController.geri();
    }

    
    public void OnPointerUp(PointerEventData eventData)
    {
        basıyomu = false;
         //   _carController.Brake();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        basıyomu = true;
        if(basıyomu)
            _carController.geri();
    }
}
