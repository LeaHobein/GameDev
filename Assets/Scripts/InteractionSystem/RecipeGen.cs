
using TMPro;
using UnityEngine;

public class RecipeGen : MonoBehaviour

{
    string[] materials = { "Profil", "Dichtung", "Beschlag", "Glasleiste", "Isolierglas", "Flügel"};
    public TMP_Text recipeText;

    public string[] GenerateRecipe()
    {
        int numberOfMaterials = UnityEngine.Random.Range(2, 4); //bestimmt, ob 2 oder 3 Materials in einem Rezept enthalten sind
        string[] recipe = new string[numberOfMaterials];

        for (int i = 0; i < numberOfMaterials; i++)
        {
            recipe[i] = materials[UnityEngine.Random.Range(0, materials.Length)]; //steckt zufällige Materials in recipe[]
            //Debug.Log(materials[UnityEngine.Random.Range(0, materials.Length)]);
        }

        return recipe;
    }

    void Start()
    {
        string[] newRecipe = GenerateRecipe(); //holt ein 2-3 langes Array mit zufälligen Materials drin
        Debug.Log(string.Join(", ", newRecipe));
        recipeText.text = (string.Join(", ", newRecipe));
    }

    void Update()
    {
        
    }
}
