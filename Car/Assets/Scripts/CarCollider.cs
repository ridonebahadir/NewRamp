using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using DG.Tweening;
using System;

public class CarCollider : MonoBehaviour
{
    public CarController carController;
    public Vector3 carRotate;
    public bool hit;
    public WheelCollider[] m_WheelColliders;
    private void Start()
    {
        carRotate = transform.eulerAngles;
    }
    private void FixedUpdate()
    {
        if (hit)
        {
           transform.DORotate(carRotate, 1f)/*.SetEase(Ease.OutExpo)*/;
        }
        //WheelGround();
    }

    private void WheelGround()
    {
        for (int i = 0; i < 4; i++)
        {
            WheelHit wheelhit;
            m_WheelColliders[i].GetGroundHit(out wheelhit);
            if (wheelhit.normal == Vector3.zero)
                return; // wheels arent on the ground so dont realign the rigidbody velocity
            else
            {
                Debug.Log("Ground Wheel");
                Invoke("Late",0.5f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        if (other.tag=="Speed")
        {
           
            carController.m_Topspeed += 25;
            Debug.Log("Current "+ carController.m_Topspeed);

        }
        if (other.gameObject.tag == "Obstacle")
        {
           
            carController.m_Topspeed -= 25;
            Debug.Log("Current " + carController.m_Topspeed);
        }
        if (other.tag=="Hit")
        {
            //carRotate = transform.eulerAngles;
            hit = true;
            Invoke("Late",1f);
        }
      
    }

    public void Late()
    {
        hit = false;
    }
}
