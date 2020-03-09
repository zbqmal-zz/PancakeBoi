using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableLogic : MonoBehaviour
{
    // Start is called before the first frame update
    private int collectableCount;
    private int collectableTotal;
    public int levelNumber;
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
    private Text pepperText;
    private Text cheeseText;
    private Text butterText;
    private Text tortillaText;
    private Text beansText;
    private Text onionText;
    private Text cilantroText;
    private Text jalapenoText;
    private Text hamText;
    private Text hotSauceText;

    void Start()
    {
        collectableCount = 0;
        pan = GameObject.FindGameObjectWithTag("Pan");
        if(pan != null){
            pan.SetActive(false);
        }

        if(levelNumber == 0 || levelNumber == null){
            Debug.Log("Please set level number");
        }
        switch (levelNumber){
            case 1:
                milkText = GameObject.Find("Milk Text").GetComponent<Text>();
                eggText = GameObject.Find("Egg Text").GetComponent<Text>();
                saltText = GameObject.Find("Salt Text").GetComponent<Text>();
                pepperText = GameObject.Find("Pepper Text").GetComponent<Text>();
                cheeseText = GameObject.Find("Cheese Text").GetComponent<Text>();
                collectableTotal = 5;
                break;
            case 2:
                sugarText = GameObject.Find("Sugar Text").GetComponent<Text>();
                vanillaText = GameObject.Find("Vanilla Text").GetComponent<Text>();
                nutmegText = GameObject.Find("Nutmeg Text").GetComponent<Text>();
                cinnamonText = GameObject.Find("Cinnamon Text").GetComponent<Text>();
                milkText = GameObject.Find("Milk Text").GetComponent<Text>();
                eggText = GameObject.Find("Egg Text").GetComponent<Text>();
                breadText = GameObject.Find("Bread Text").GetComponent<Text>();
                collectableTotal = 7;
                break;
            case 3:
                flourText = GameObject.Find("Flour Text").GetComponent<Text>();
                bakingSodaText = GameObject.Find("Baking Soda Text").GetComponent<Text>();
                blueberryText = GameObject.Find("Blueberries Text").GetComponent<Text>();
                milkText = GameObject.Find("Milk Text").GetComponent<Text>();
                saltText = GameObject.Find("Salt Text").GetComponent<Text>();
                vanillaText = GameObject.Find("Vanilla Text").GetComponent<Text>();
                sugarText = GameObject.Find("Sugar Text").GetComponent<Text>();
                butterText = GameObject.Find("Butter Text").GetComponent<Text>();
                eggText = GameObject.Find("Egg Text").GetComponent<Text>();
                collectableTotal = 9;
                break;
            case 4:
                tortillaText = GameObject.Find("Tortilla Text").GetComponent<Text>();
                eggText = GameObject.Find("Egg Text").GetComponent<Text>();
                beansText = GameObject.Find("Beans Text").GetComponent<Text>();
                saltText = GameObject.Find("Salt Text").GetComponent<Text>();
                onionText = GameObject.Find("Onion Text").GetComponent<Text>();
                cilantroText = GameObject.Find("Cilantro Text").GetComponent<Text>();
                jalapenoText = GameObject.Find("Jalapeno Text").GetComponent<Text>();
                cheeseText = GameObject.Find("Cheese Text").GetComponent<Text>();
                hotSauceText = GameObject.Find("Hot Sauce Text").GetComponent<Text>();
                hamText = GameObject.Find("Ham Text").GetComponent<Text>();
                butterText = GameObject.Find("Butter Text").GetComponent<Text>();
                collectableTotal = 11;
                break;
        }
        if(collectableTotal == null || collectableTotal == 0){
            Debug.Log("Must set collectable total for level");
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collsion entered");
        switch(collider.gameObject.name){
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
            case "Pepper Shaker Obj":
                collectableCount++;
                pepperText.color = Color.black;
                break;
            case "Cheese Body":
                collectableCount++;
                cheeseText.color = Color.black;
                break;
            case "Butter Tilted":
                collectableCount++;
                butterText.color = Color.black;
                break;
            case "Tortilla Tilted":
                collectableCount++;
                tortillaText.color = Color.black;
                break;
            case "Bean Group":
                collectableCount++;
                beansText.color = Color.black;
                break;
            case "Onion Body":
                collectableCount++;
                onionText.color = Color.black;
                break;
            case "Cilantro Leaves":
                collectableCount++;
                cilantroText.color = Color.black;
                break;
            case "Jalapeno Body":
                collectableCount++;
                jalapenoText.color = Color.black;
                break;
            case "Hot Sauce Body":
                collectableCount++;
                hotSauceText.color = Color.black;
                break;
            case "ham body":
                collectableCount++;
                hamText.color = Color.black;
                break;
        }
    }
    void Update(){
        if(collectableCount == collectableTotal){
            Debug.Log(collectableCount);
            pan.SetActive(true);
        }
    }
}
