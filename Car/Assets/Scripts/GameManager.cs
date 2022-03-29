using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

namespace UnityStandardAssets.CrossPlatformInput {

    public class GameManager : MonoBehaviour
    {
        public CarController carController;
        public void ResetScene()
        {
            

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
        public void StartButton()
        {
            carController.m_Topspeed = 50;
        }
    }

}

