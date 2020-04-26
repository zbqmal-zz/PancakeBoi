using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;
    private CameraController camera;
    private float cameraSpeedH;
    private float cameraSpeedV;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("Menu");
        pauseMenu.SetActive(false);
        camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
        cameraSpeedH = camera.cameraSpeedH;
        cameraSpeedV = camera.cameraSpeedV;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.O)) {
            if(!pauseMenu.activeSelf) {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                camera.cameraSpeedH = 0f;
                camera.cameraSpeedV = 0f;
            } else {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                camera.cameraSpeedH = cameraSpeedH;
                camera.cameraSpeedV = cameraSpeedV;
            }
        }
    }


}
