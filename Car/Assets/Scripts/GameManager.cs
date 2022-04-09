using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

namespace UnityStandardAssets.CrossPlatformInput {

    public class GameManager : MonoBehaviour
    {
        
        public void ResetScene()
        {
            

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
       
    }

}

