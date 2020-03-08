using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private int collectableCount;
    public int collectableTotal;
    private GameObject pan;
    private Text sugarText;
    private Text vanillaText;
    private Text nutmegText;
    private Text cinnamonText;
    private Text milkText;
    private Text eggText;
    private Text breadText;
    private Text flourText;
    private Text bakingSodaText;
    private Text blueberryText;
    private Text saltText;
    private Text butterText;
    void Start()
    {
        collectableCount = 0;
        if(collectableTotal == null || collectableTotal == 0){
            Debug.Log("Must set collectable total for level");
        }
        pan = GameObject.FindGameObjectWithTag("Pan");
        sugarText = GameObject.Find("Sugar Text").GetComponent<Text>();
        vanillaText = GameObject.Find("Vanilla Text").GetComponent<Text>();
        nutmegText = GameObject.Find("Nutmeg Text").GetComponent<Text>();
        cinnamonText = GameObject.Find("Cinnamon Text").GetComponent<Text>();
        milkText = GameObject.Find("Milk Text").GetComponent<Text>();
        eggText = GameObject.Find("Egg Text").GetComponent<Text>();
        breadText = GameObject.Find("Bread Text").GetComponent<Text>();
        flourText = GameObject.Find("Flour Text").GetComponent<Text>();
        bakingSodaText = GameObject.Find("Baking Soda Text").GetComponent<Text>();
        blueberryText = GameObject.Find("Blueberries Text").GetComponent<Text>();
        saltText = GameObject.Find("Salt Text").GetComponent<Text>();
        butterText = GameObject.Find("Butter Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collsion entered");
        switch(collision.collider.gameObject.name){
            case "Sugar Jar":
                Debug.Log("saw it was sugar");
                collectableCount++;
                sugarText.color = Color.black;
                break;
            case "Vanilla Extract Bottle":
                collectableCount++;
                vanillaText.color = Color.black;
                break;
            case "Nutmeg Bottle":
                collectableCount++;
                nutmegText.color = Color.black;
                break;
            case "Cinnamon Bottle":
                collectableCount++;
                cinnamonText.color = Color.black;
                break;
            case "Milk Carton":
                collectableCount++;
                milkText.color = Color.black;
                break;
            case "Egg Body":
                collectableCount++;
                eggText.color = Color.black;
                break;
            case "Bread Body":
                collectableCount++;
                breadText.color = Color.black;
                break;
            case "Flour Jar":
                collectableCount++;
                flourText.color = Color.black;
                break;
            case "Baking Soda Box":
                collectableCount++;
                bakingSodaText.color = Color.black;
                break;
            case "Blueberry Bundle":
                collectableCount++;
                blueberryText.color = Color.black;
                break;
            case "Salt Shaker Obj":
                collectableCount++;
                saltText.color = Color.black;
                break;
            case "Butter Tilted":
                collectableCount++;
                butterText.color = Color.black;
                break;
        }
    }
    void Update(){
        if(collectableCount == collectableTotal){
            pan.SetActive(true);
        }
    }
}
