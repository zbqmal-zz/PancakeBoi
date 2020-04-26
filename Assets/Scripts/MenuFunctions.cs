using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    private CameraController camera;
    void Start() {
        camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    public void QuitGame() {
        SceneManager.LoadScene(this.gameObject.scene.ToString());
    }

    public void adjustMouseSpeed(float m) {
        if (camera != null) {
            camera.speedMult = m;
        }
    }
}
