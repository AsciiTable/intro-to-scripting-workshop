using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PrebuiltShopper : MonoBehaviour
{
    // Class Variables: What does the shopper have?
    /** Currently, you, the shopper, has a limited amount of money in your
     wallet, a shopping bag, and eventually veggies.*/
    public float allowance = 0f;
    [HideInInspector] public TextMeshProUGUI allowanceText;
    [HideInInspector] public Button shoppingBag;
    [HideInInspector] public List<PrebuiltVeggie> veggiesInBag;
    public GameObject checkoutPanel;

    private void Start(){
        // NOTE: Be VERY careful with transform.Find(); it's very easy for bugs to happen here due to renaming or typos
        allowanceText = this.transform.Find("MoneyPurse").transform.Find("Allowance").GetComponent<TextMeshProUGUI>();
        allowanceText.SetText("$" + allowance.ToString("F2"));
        shoppingBag = this.transform.Find("Inventory").GetComponent<Button>();
        veggiesInBag = new List<PrebuiltVeggie>();
    }
    public bool validatePurchase(PrebuiltVeggie v) {
        if (allowance >= v.price)
        {
            allowance = allowance - v.price;
            allowanceText.text = "$" + allowance.ToString("F2");
            bool exists = false;
            foreach (PrebuiltVeggie heldVeggie in veggiesInBag)
            {
                if (v.name.Equals(heldVeggie.name))
                {
                    heldVeggie.quantity++;
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                veggiesInBag.Add(new PrebuiltVeggie(v.name, v.price, 1));
            }
            return true;
        }
        else {
            Debug.Log("You don't have enough money!!");
        }
        return false;
    }
    public void viewInventory() {
        string inv = "";
        foreach (PrebuiltVeggie heldVeggie in veggiesInBag)
        {
            inv = inv + heldVeggie.ToString() + "\t";
        }
        Debug.Log(inv);
    }
    public void checkout() {
        checkoutPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void shopAgain() {
        checkoutPanel.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
