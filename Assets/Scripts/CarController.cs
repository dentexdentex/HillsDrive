using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Axel
{
    Front,
    Rear
}

[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public Axel axel;
}

public class CarController : MonoBehaviour
{

    public ButtonGo buttonGo;
    public ButtonBreak buttonBreak;
    [SerializeField]
    private float maxAcceleration = 20.0f;
    [SerializeField]
    private float turnSensitivity = 1.0f;
    [SerializeField]
    private float maxSteerAngle = 45.0f;
    [SerializeField]
    private float maxSpeed =5f; // add max speed variable
    [SerializeField]
    private Vector3 _centerOfMass;
    [SerializeField]
    private List<Wheel> wheels;
    private otonom otonom;
    private Rigidbody _rb;
    private bool basıyomu;
    private float acceleration = 0f;
    public float rotationSpeed = 0.5f;
    public GameObject[] objectsToRotate;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = false;

        _rb.centerOfMass = _centerOfMass;
        otonom = gameObject.GetComponent<otonom>();
        transform.position = otonom.markers[otonom.markers.Count - 1].transform.position;
    }

    private void Update()
    {
        IsCarAirborne();
    }

    private void LateUpdate()
    {
        Vector3 currentEulerAngles;
        currentEulerAngles = new Vector3(transform.rotation.eulerAngles.x, 90, transform.rotation.eulerAngles.z);
        transform.eulerAngles = currentEulerAngles;

        Move();
    }

    public void ileri()
    {
        acceleration = maxAcceleration;
    }

    public void geri()
    {
        acceleration = -maxAcceleration;
    }

    private void Move()
    {
        // Calculate current speed
        float currentSpeed = _rb.velocity.magnitude;

        // Limit speed if necessary
        if (currentSpeed > maxSpeed)
        {
         //   Debug.Log("sınırla");
            _rb.velocity = _rb.velocity.normalized * maxSpeed;
        }

        foreach (var wheel in wheels)
        {
            if (buttonBreak.basıyomu || buttonGo.basıyomu)
            {
                wheel.collider.motorTorque = acceleration * 500 * Time.deltaTime;
                foreach (GameObject obj in objectsToRotate)
                {
                    obj.transform.Rotate(-Vector3.left * rotationSpeed * Time.deltaTime);
                }
                if (IsCarAirborne())
                {
                    if (buttonBreak.basıyomu)
                    {
                        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);

                    }

                    if (buttonGo.basıyomu)
                    {
                        transform.Rotate(Vector3.right * -rotationSpeed * Time.deltaTime);

                    }
                    Debug.Log("DÖNÜYO");
                }  
            }
            else
            {
                wheel.collider.motorTorque = 0;
  
            }
        }
    }
    private bool IsCarAirborne()
    {
        bool airborne = true;
        foreach (var wheel in wheels)
        {
            WheelHit hit;
            if (wheel.collider.GetGroundHit(out hit))
            {
                airborne = false;
                break;
            }
        }
        return airborne;
    }
}