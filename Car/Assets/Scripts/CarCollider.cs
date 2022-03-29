using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using DG.Tweening;
public class CarCollider : MonoBehaviour
{
    public CarController carController;
    public Vector3 carRotate;
    bool hit;
    private void Start()
    {
        carRotate = transform.eulerAngles;
    }
    private void FixedUpdate()
    {
        if (hit)
        {
           transform.DORotate(carRotate, 0.5f)/*.SetEase(Ease.OutExpo)*/;
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

    private void Late()
    {
        hit = false;
    }
}
