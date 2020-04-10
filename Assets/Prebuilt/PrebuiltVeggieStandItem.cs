using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrebuiltVeggieStandItem : MonoBehaviour
{
    // Class Variables: What does a Veggie Stand have?
    public PrebuiltVeggie veggie;
    public bool soldOut = false; // wether the veggie is sold out or not
    [HideInInspector] public TextMeshProUGUI NameText;
    [HideInInspector] public TextMeshProUGUI QuantityText;
    [HideInInspector] public Image SoldOutImage;
    [HideInInspector] public TextMeshProUGUI PriceTagText;
    [HideInInspector] public Button BuyButton;
    [HideInInspector] public PrebuiltShopper shopper;

    // Functions: What does the Veggie Stand want to do with their Veggies?
    // Set up Veggies for sale
    private void Start()
    {
        // NOTE: Be VERY careful with transform.Find(); it's very easy for bugs to happen here due to renaming or typos
        NameText = this.transform.Find("Name").GetComponent<TextMeshProUGUI>();
        NameText.text = name;
        QuantityText = this.transform.Find("Quantity").GetComponent<TextMeshProUGUI>();
        QuantityText.text = veggie.quantity.ToString();
        SoldOutImage = this.transform.Find("SoldOut").GetComponent<Image>();
        SoldOutImage.enabled = soldOut;
        PriceTagText = this.transform.Find("PriceTag").transform.Find("Price").GetComponent<TextMeshProUGUI>();
        PriceTagText.text = "$" + veggie.price.ToString("F2");
        BuyButton = this.GetComponent<Button>();
        shopper = GameObject.FindGameObjectWithTag("Shopper").GetComponent<PrebuiltShopper>();
    }
    // Sell Veggies
    public void sell()
    {
        if (soldOut == false && shopper.validatePurchase(veggie))
        { // or !soldOut
            veggie.quantity = veggie.quantity - 1;
            QuantityText.text = veggie.quantity.ToString(); // update displayed quantity
            //Debug.Log(name + ": " + veggie.quantity);
            if (veggie.quantity <= 0)
            { // if you run out of veggies
                soldOut = true;
                SoldOutImage.enabled = true;
            }
        }
    }
}
