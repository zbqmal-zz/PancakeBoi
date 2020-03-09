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
    public List<Text> ingredientsCollected;
    private GameObject pan;
    private GameObject[] pantriggers;
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
        pantriggers = GameObject.FindGameObjectsWithTag("Pan Trigger");
        if(pan != null){
            pan.SetActive(false);
        }
        if(pantriggers.Length > 0){
            for (int i = 0; i < pantriggers.Length; i++){
                pantriggers[i].SetActive(false);
            }
        }

        if(levelNumber == 0 || levelNumber == null){
            Debug.Log("Please set level number");
        }
        ingredientsCollected = new List<Text>();
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
                bakingSodaText = GameObject.Find("Baking Text").GetComponent<Text>();
                Debug.Log(bakingSodaText);
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
        Debug.Log("triggered");
        switch(collider.gameObject.name){
            case "Sugar Jar":
                Debug.Log("saw it was sugar");
                collectableCount++;
                sugarText.color = Color.black;
                AddCollectedIngredient(sugarText);
                break;
            case "Vanilla Extract Bottle":
                collectableCount++;
                vanillaText.color = Color.black;
                AddCollectedIngredient(vanillaText);
                break;
            case "Nutmeg Bottle":
                collectableCount++;
                nutmegText.color = Color.black;
                AddCollectedIngredient(nutmegText);
                break;
            case "Cinnamon Bottle":
                collectableCount++;
                cinnamonText.color = Color.black;
                AddCollectedIngredient(cinnamonText);
                break;
            case "Milk Carton":
                collectableCount++;
                milkText.color = Color.black;
                AddCollectedIngredient(milkText);
                break;
            case "Egg Body":
                collectableCount++;
                eggText.color = Color.black;
                AddCollectedIngredient(eggText);
                break;
            case "Bread Body":
                collectableCount++;
                breadText.color = Color.black;
                AddCollectedIngredient(breadText);
                break;
            case "Flour Jar":
                collectableCount++;
                flourText.color = Color.black;
                AddCollectedIngredient(flourText);
                break;
            case "Baking Soda Box":
                collectableCount++;
                bakingSodaText.color = Color.black;
                AddCollectedIngredient(bakingSodaText);
                break;
            case "Blueberry Bundle":
                collectableCount++;
                blueberryText.color = Color.black;
                AddCollectedIngredient(blueberryText);
                break;
            case "Salt Shaker Obj":
                collectableCount++;
                saltText.color = Color.black;
                AddCollectedIngredient(saltText);
                break;
            case "Pepper Shaker Obj":
                collectableCount++;
                pepperText.color = Color.black;
                AddCollectedIngredient(pepperText);
                break;
            case "Cheese Body":
                collectableCount++;
                cheeseText.color = Color.black;
                AddCollectedIngredient(cheeseText);
                break;
            case "Butter Tilted":
                collectableCount++;
                butterText.color = Color.black;
                AddCollectedIngredient(butterText);
                break;
            case "Tortilla Tilted":
                collectableCount++;
                tortillaText.color = Color.black;
                AddCollectedIngredient(tortillaText);
                break;
            case "Bean Group":
                collectableCount++;
                beansText.color = Color.black;
                AddCollectedIngredient(beansText);
                break;
            case "Onion Body":
                collectableCount++;
                onionText.color = Color.black;
                AddCollectedIngredient(onionText);
                break;
            case "Cilantro Leaves":
                collectableCount++;
                cilantroText.color = Color.black;
                AddCollectedIngredient(cilantroText);
                break;
            case "Jalapeno Body":
                collectableCount++;
                jalapenoText.color = Color.black;
                AddCollectedIngredient(jalapenoText);
                break;
            case "Hot Sauce Body":
                collectableCount++;
                hotSauceText.color = Color.black;
                AddCollectedIngredient(hotSauceText);
                break;
            case "ham body":
                collectableCount++;
                hamText.color = Color.black;
                AddCollectedIngredient(hamText);
                break;
        }
    }
    void Update(){
        //Debug.Log(ingredientsCollected.Count);
        if(ingredientsCollected.Count == collectableTotal){
            //Debug.Log(collectableCount);
            pan.SetActive(true);
            for (int i = 0; i<pantriggers.Length; i++){
                pantriggers[i].SetActive(true);
            }
        }
    }
    void AddCollectedIngredient(Text ingredient){
        bool dup = false;
        for (int i = 0; i < ingredientsCollected.Count; i++){
            if(ingredientsCollected[i] == ingredient){
                dup = true;
            }
        }
        if(!dup){
            ingredientsCollected.Add(ingredient);
        }
    }
}
