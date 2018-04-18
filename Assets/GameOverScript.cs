using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

    public class GameOverScript : MonoBehaviour
    {
        public GameObject canvasgame;
        public GameObject canvascar;
        public GameObject canvastire;
        public GameObject canvastry;
                
        void OnTriggerEnter(Collider Collider)
        {
            if (Collider.tag == "CarAI")
            {
                Time.timeScale = 0;

                GetComponent<CarAudio>().pitchMultiplier = 0;

                canvasgame.SetActive(true);
                canvascar.SetActive(true);
                canvastire.SetActive(false);

                canvastry.SetActive(!StaticSettings.AutoDimmer);

                StaticSettings.AutoDimmer = false;
            }
            if (Collider.tag == "acid")
            {
                Time.timeScale = 0;

                GetComponent<CarAudio>().pitchMultiplier = 0;

                canvasgame.SetActive(true);
                canvascar.SetActive(false);
                canvastire.SetActive(true);

                canvastry.SetActive(!StaticSettings.AutoDimmer);

                StaticSettings.AutoDimmer = false;
            }
        }
    }

