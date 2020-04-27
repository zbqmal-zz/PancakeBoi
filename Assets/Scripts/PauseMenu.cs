using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PauseMenu : MonoBehaviour
{
    private GameObject pauseMenu;
    private CameraController cam;
    private float cameraSpeedH;
    private float cameraSpeedV;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("Menu");
        pauseMenu.SetActive(false);
        cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
        cameraSpeedH = cam.cameraSpeedH;
        cameraSpeedV = cam.cameraSpeedV;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.O)) {
            if(!pauseMenu.activeSelf) {
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                cam.cameraSpeedH = 0f;
                cam.cameraSpeedV = 0f;
            } else {
                Cursor.visible = false;
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
                cam.cameraSpeedH = cameraSpeedH;
                cam.cameraSpeedV = cameraSpeedV;
            }
        }
    }


}
