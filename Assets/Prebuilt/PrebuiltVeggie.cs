[System.Serializable]
public class PrebuiltVeggie
{
    // Use double foward slashes to comment out one line
    /** Or two forward slashes with two astricks in the
     *  middle to comment out a section! (Comments will not effect the code)*/

    // Class Variables: What traits do our veggies have? 
    /**There are different levels of protection, that being public, protected, and private.
       But for our purposes, we'll just be dealing with public*/
    public string name; // name of the veggie
    public float price; // the amount of money these veggies cost
    public int quantity; // the amount of veggies in stock
    public enum VeggieNames { 
        Eggplant,
        Carrot,
        Tomato,
        Spinach,
        Beet, 
        Broccoli,
        Pumpkin,
        Unidentified
    }
    public VeggieNames eName;

    public PrebuiltVeggie(string n, float p, int q) {
        name = n;
        price = p;
        quantity = q;
        switch (n.ToLower()) {
            case "eggplant":
                eName = VeggieNames.Eggplant;
                break;
            case "carrot":
                eName = VeggieNames.Carrot;
                break;
            case "tomato":
                eName = VeggieNames.Tomato;
                break;
            case "spinach":
                eName = VeggieNames.Spinach;
                break;
            case "beet":
                eName = VeggieNames.Beet;
                break;
            case "broccoli":
                eName = VeggieNames.Broccoli;
                break;
            case "pumpkin":
                eName = VeggieNames.Pumpkin;
                break;
            default:
                eName = VeggieNames.Unidentified;
                break;
        }
    }

    public PrebuiltVeggie() {
        name = "";
        price = 0f;
        quantity = 0;
        eName = VeggieNames.Unidentified;
    }

    public override string ToString()
    {
        return name +" ($" + price.ToString("F2") + ") - " + quantity;
    }
}
