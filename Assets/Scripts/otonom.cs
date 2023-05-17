using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otonom : MonoBehaviour
{
    public List<Transform> markers;
    public float speed = 1.0f;
    public float maxSteerAngle = 45.0f;

    private int currentMarkerIndex = 0;
    private Rigidbody _rb;
    public GameObject[] objectsToRotate;
    public float rotationSpeed = 10f;

    public CarController carController;
    public GameObject car;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    Transform target;
    void Update()
    {

        foreach (GameObject obj in objectsToRotate)
        {
            obj.transform.Rotate(-Vector3.left * rotationSpeed * Time.deltaTime);
        }


        
        if (enabled)
        {
             target = markers[currentMarkerIndex];
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
     

        if (transform.position == target.position)
        {
            currentMarkerIndex++;

            if (currentMarkerIndex >= markers.Count)
            {
                enabled = false;
                carController.enabled = true;

            }
            

            
        }

       

    }

    
}