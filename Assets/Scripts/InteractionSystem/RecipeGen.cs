using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RecipeGen : MonoBehaviour

{
    string[] materials = { "Profil", "Dichtung", "Beschlag", "Glasleiste", "Isolierglas", "Fluegel" };

    public TMP_Text recipeText;

    public RawImage Material1;
    public RawImage Material2;
    public RawImage Material3;

    [SerializeField] Texture Profil;
    [SerializeField] Texture Dichtung;
    [SerializeField] Texture Beschlag;
    [SerializeField] Texture Glasleiste;
    [SerializeField] Texture Isolierglas;
    [SerializeField] Texture Fluegel;

    public int numberOfMaterials = 1;
    public string[] newRecipe = new string[1];

    [SerializeField] DeliveryButton deliveryButton;

    public void Start()
    {
        Debug.Log ("I exist");
        numberOfMaterials = 1;
        string[] newRecipe = { "Dichtung" };
        UpdateIcons(newRecipe);

    }

    public string[] GenerateRecipe()
    {
        numberOfMaterials = UnityEngine.Random.Range(2, 4); //bestimmt, ob 2 oder 3 Materials in einem Rezept enthalten sind
        string[] recipe = new string[numberOfMaterials];

        for (int i = 0; i < numberOfMaterials; i++)
        {
            recipe[i] = materials[UnityEngine.Random.Range(0, materials.Length)]; //steckt zufaellige Materials in recipe[]
        }

        return recipe;
    }

    public void RoundRecipe()
    {
        newRecipe = GenerateRecipe(); //holt ein 2-3 langes Array mit zufaelligen Materials drin
        Debug.Log(string.Join(", ", newRecipe));

        //code fuer recipe text on screen (aktuell hidden)
        string recipeString = (string.Join(", ", newRecipe));
        recipeText.text = recipeString;
        UpdateIcons(newRecipe);
 
    }

    void UpdateIcons(string[] newRecipe)
    {
        switch (newRecipe[0])
        {
            case "Profil":
                Material1.texture = Profil;
                break;
            case "Dichtung":
                Material1.texture = Dichtung;
                break;
            case "Beschlag":
                Material1.texture = Beschlag;
                break;
            case "Glasleiste":
                Material1.texture = Glasleiste;
                break;
            case "Isolierglas":
                Material1.texture = Isolierglas;
                break;
            case "Fluegel":
                Material1.texture = Fluegel;
                break;
            default:
                break;

        }

        if (newRecipe.Length >= 2)
        {
            switch (newRecipe[1])
            {
                case "Profil":
                    Material2.texture = Profil;
                    break;
                case "Dichtung":
                    Material2.texture = Dichtung;
                    break;
                case "Beschlag":
                    Material2.texture = Beschlag;
                    break;
                case "Glasleiste":
                    Material2.texture = Glasleiste;
                    break;
                case "Isolierglas":
                    Material2.texture = Isolierglas;
                    break;
                case "Fluegel":
                    Material2.texture = Fluegel;
                    break;
                default:
                    break;

            }
        }

        if (newRecipe.Length == 3)
        {
            switch (newRecipe[2])
            {
                case "Profil":
                    Material3.texture = Profil;
                    break;
                case "Dichtung":
                    Material3.texture = Dichtung;
                    break;
                case "Beschlag":
                    Material3.texture = Beschlag;
                    break;
                case "Glasleiste":
                    Material3.texture = Glasleiste;
                    break;
                case "Isolierglas":
                    Material3.texture = Isolierglas;
                    break;
                case "Fluegel":
                    Material3.texture = Fluegel;
                    break;
                default:
                    break;

            }
        }
    }
}
