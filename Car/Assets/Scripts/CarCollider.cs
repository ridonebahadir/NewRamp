using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using DG.Tweening;
using System;
using UnityStandardAssets.Utility;

public class CarCollider : MonoBehaviour
{
    public CarController carController;
    public Vector3 carRotate;
    public bool hit;
    public WheelCollider[] m_WheelColliders;
    public GameObject finalCamera;
    public FollowTarget followTarget;
    public GameObject bomb;
    private void Start()
    {
        carRotate = transform.eulerAngles;
      
       
    }
    private void FixedUpdate()
    {
        if (hit)
        {
           transform.DORotate(carRotate, 1f)/*.SetEase(Ease.OutExpo)*/;
            WheelGround();
        }
       
    }
    public LayerMask layerMask;
    private void WheelGround()
    {
        if (m_WheelColliders[0].GetGroundHit(out WheelHit whit))
        {
            if (whit.collider.gameObject.tag=="Ground")
            {
                Debug.Log("Ground Wheel");
                Invoke("Late", 0.5f);
              
            }
          
        }

        //for (int i = 0; i < 4; i++)
        //{
        //    WheelHit wheelhit;
        //    m_WheelColliders[i].GetGroundHit(out wheelhit);

        //    if (wheelhit.normal == Vector3.zero)
        //        return; // wheels arent on the ground so dont realign the rigidbody velocity
        //    else
        //    {
        //        if (hit)
        //        {
        //            Debug.Log("Ground Wheel");
        //            Invoke("Late", 0.5f);

        //        }
        //    }
        //}
    }
    float balance = 25;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        if (other.tag=="Speed")
        {
            FloatLerp(25, carController.m_Topspeed, 0.1f);
            //float to = balance + carController.m_Topspeed;
            //float cur = carController.m_Topspeed;
            
            //DOTween.To(() => cur, x => cur = x, to, 0.5f)
            //    .OnUpdate(() => {
            //       carController.m_Topspeed= cur;
            //    });
           
            

        }
        if (other.gameObject.tag == "Obstacle")
        {
            FloatLerp(-25, carController.m_Topspeed, 0.5f);
            //float to = -balance + carController.m_Topspeed;
            //float cur = carController.m_Topspeed;

            //DOTween.To(() => cur, x => cur = x, to, 0.5f)
            //    .OnUpdate(() => {
            //       carController.m_Topspeed = cur;
            //    });
        }
        if (other.tag=="Hit")
        {
            //carRotate = transform.eulerAngles;
            hit = true;
            
            //Invoke("Late",1f);
        }
        if (other.tag == "FinalHitAfter")
        {
            //carRotate = transform.eulerAngles;
            hit = true;
            carController.m_Downforce = -100;
            FloatLerp(100, carController.m_Topspeed, 0.5f);
            Invoke("Late", 5f);
        }
        if (other.tag == "FinalHit")
        {
            finalCamera.transform.DORotate(new Vector3(0, 10, 0), 1f);
            finalCamera.transform.DOLocalMove(new Vector3(-2, 2, -5), 3f);
            //followTarget.offset = new Vector3(15,5,-5);
            //finalCamera.SetActive(true);
            carController.m_Downforce = -500;
            FloatLerp(100, carController.m_Topspeed, 0.5f);
            
        }
        if (other.tag=="Collect")
        {
            Instantiate(bomb,other.transform.position,Quaternion.Euler(0,0,0));
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Wall")
        {
            FloatLerp(-carController.m_Topspeed,carController.m_Topspeed,3);
            hit = true;
        }
    }

    public void Late()
    {
        hit = false;
    }


    void FloatLerp(float amount, float variable, float duration)
    {
        float to = amount + variable;
        float target = variable;

        DOTween.To(() => target, x => target = x, to, duration)
            .OnUpdate(() => {
                carController.m_Topspeed = target;
            });
    }
    
}
