using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSceneSweep : MonoBehaviour
{
    public GameObject PlayerCam;
    public GameObject FlyByCam;
    public GameObject HUD;
    GameObject player;
    private bool playedscene;
    public int cameraTime;
    // Start is called before the first frame update
    void Start()
    {
        PlayerCam.SetActive(false);
        playedscene = false;
         StartCoroutine(ShowLevel());
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PancakBoiControl>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(!playedscene){
        
        //}
    }
    IEnumerator ShowLevel(){
        yield return new WaitForSeconds(cameraTime);
        PlayerCam.SetActive(true);
        FlyByCam.SetActive(false);
        HUD.SetActive(true);
        player.GetComponent<PancakBoiControl>().enabled = true;
        yield return new WaitForSeconds(3);
        HUD.SetActive(false);
        playedscene = true;
    }
}
