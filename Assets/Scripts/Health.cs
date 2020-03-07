using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float health = 3;
    private int heartsTotal = 3;
    public Image[] hearts;
    public Sprite halfHeart;
    public Sprite fullHeart;

    public void Update(){
        //3 hearts total
        for (int i = 0; i< hearts.Length; i++){
            //Setting sprite to full or half heart depending on health value
            if(i < health - .5f){
                hearts[i].sprite = fullHeart;
            }else if (i < health){
                hearts[i].sprite = halfHeart;
            }

            //enabling or disabling sprites to show or not show. Full heart gone means it won't show a heart
            if(i < health){
                hearts[i].enabled = true;
            }else{
                hearts[i].enabled = false;
            }
        }
    }

}
