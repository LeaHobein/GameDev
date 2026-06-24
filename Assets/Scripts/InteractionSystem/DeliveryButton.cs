using System;
using UnityEngine;

public class DeliveryButton : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject spotOne;
    [SerializeField]
    private GameObject spotTwo;
    [SerializeField]
    private GameObject spotThree;
    [SerializeField]
    private GameObject window;

    string[] deliveryorder;
    string[] recipe = { "Dichtung" };

    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private TimeManager timeManager;

    void Start() 
    {
        Debug.Log("number of materials: " + GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials);
        Debug.Log("recipe: " + recipe[0]); 

        deliveryorder = new string[GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials];
        //recipe = new string[GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials];
        //recipe = GameObject.Find("RecipeGen").GetComponent<RecipeGen>().newRecipe;
    }

    public void Press()
    {
        // ueberprüfe die Abgabestation
        checkup(spotOne, spotTwo, spotThree);

        Debug.Log("Button Pressed");

        AudioManager.Instance.Play(AudioManager.SoundType.DeliveryButtonPress);

        Renew();
    }

    public void Renew()
    {
        //setup für nächsten neuen Rezept-Durchgang

        emptySpot(spotOne);
        emptySpot(spotTwo);
        emptySpot(spotThree);

        spotOne.GetComponent<DeliverySpot>().occupado = false;
        spotTwo.GetComponent<DeliverySpot>().occupado = false;
        spotThree.GetComponent<DeliverySpot>().occupado = false;

        // neues Rezept hier
        deliveryorder = new string[GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials];
        recipe = new string[GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials];
        recipe = GameObject.Find("RecipeGen").GetComponent<RecipeGen>().newRecipe;
    }

    private void emptySpot(GameObject spot)
    {
        Renderer[] materialMeshes = spot.GetComponentsInChildren<Renderer>();
        foreach (Renderer m in materialMeshes)
        {
            m.enabled = false;
        }
    }

    private void checkup(GameObject one, GameObject two, GameObject three)
    {
        //definiere Indiz 0
        if (one.transform.Find("spawnee").GetComponent<MeshRenderer>().enabled == true)
        {
            deliveryorder[0] = "Profil";
            print("Abgabe 1: Profil");
        }
        else if (one.transform.Find("spawnee2").GetComponent<MeshRenderer>().enabled == true)
        {
            deliveryorder[0] = "Dichtung";
            print("Abgabe 1: Dichtung");
        }
        else if (one.transform.Find("spawnee3").GetComponent<MeshRenderer>().enabled == true)
        {
            deliveryorder[0] = "Beschlag";
            print("Abgabe 1: Beschlag");
        }
        else if (one.transform.Find("spawnee4").GetComponent<MeshRenderer>().enabled == true)
        {
            deliveryorder[0] = "Glasleiste";
            print("Abgabe 1: Glasleiste");
        }
        else if (one.transform.Find("spawnee5").GetComponent<MeshRenderer>().enabled == true)
        {
            deliveryorder[0] = "Isolierglas";
            print("Abgabe 1: Isolierglas");
        }
        else if (one.transform.Find("spawnee6").GetComponent<MeshRenderer>().enabled == true)
        {
            deliveryorder[0] = "Fluegel";
            print("Abgabe 1: Fluegel");
        }
        else
        {
            deliveryorder[0] = "none";
        }

        //definiere Indiz 1, wenn Anzahl der Abgabe ist 2
        if (GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials >= 2)
        {
            if (two.transform.Find("spawnee").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[1] = "Profil";
                print("Abgabe 2: Profil");
            }
            else if (two.transform.Find("spawnee2").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[1] = "Dichtung";
                print("Abgabe 2: Dichtung");
            }
            else if (two.transform.Find("spawnee3").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[1] = "Beschlag";
                print("Abgabe 2: Beschlag");
            }
            else if (two.transform.Find("spawnee4").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[1] = "Glasleiste";
                print("Abgabe 2: Glasleiste");
            }
            else if (two.transform.Find("spawnee5").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[1] = "Isolierglas";
                print("Abgabe 2: Isolierglas");
            }
            else if (two.transform.Find("spawnee6").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[1] = "Fluegel";
                print("Abgabe 2: Fluegel");
            }
            else
            {
                deliveryorder[1] = "none";
            }
        }

        //definiere Indiz 2, wenn Anzahl der Abgabe ist 3
        if (GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials == 3)
        {
            if (three.transform.Find("spawnee").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[2] = "Profil";
                print("Abgabe 3: Profil");
            }
            else if (three.transform.Find("spawnee2").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[2] = "Dichtung";
                print("Abgabe 3: Dichtung");
            }
            else if (three.transform.Find("spawnee3").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[2] = "Beschlag";
                print("Abgabe 3: Beschlag");
            }
            else if (three.transform.Find("spawnee4").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[2] = "Glasleiste";
                print("Abgabe 3: Glasleiste");
            }
            else if (three.transform.Find("spawnee5").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[2] = "Isolierglas";
                print("Abgabe 3: Isolierglas");
            }
            else if (three.transform.Find("spawnee6").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[2] = "Fluegel";
                print("Abgabe 3: Fluegel");
            }
            else
            {
                deliveryorder[2] = "none";
            }
        }

        //print(deliveryorder[0] + ", " + recipe[0] + ", " + deliveryorder[1] + ", " + recipe[1] + ", " + deliveryorder[2] + ", " + recipe[2]);

        if (GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials == 1) //checke für 1 Abgabe
        {
            string[] recipe = { "Dichtung" };

            if (deliveryorder[0] == recipe[0])
            {
                Debug.Log("slay brudi");
                GameObject.Find("checkup").GetComponent<MeshRenderer>().material.color = new Color(0f, 1f, 0f);
                GameObject.Find("checkup2").GetComponent<MeshRenderer>().material.color = new Color(0f, 1f, 0f);
                //Nach richtiger Abgabe -> neues Rezept in RecipeGen
                GameObject.Find("RecipeGen").GetComponent<RecipeGen>().RoundRecipe();
                //das Tutorial wurde abgeschlossen, starte die Runde
                GameObject.Find("timerText").GetComponent<TimeManager>().StartRound();
                moveit();
            }
            else
            {
                GameObject.Find("checkup").GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
                GameObject.Find("checkup2").GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
                AudioManager.Instance.Play(AudioManager.SoundType.Fail);
            }
        }
        else if (GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials == 2)   //checke für 2 Abgaben
        {
            if (deliveryorder[0] == recipe[0] && deliveryorder[1] == recipe[1])
            {
                GameObject.Find("checkup").GetComponent<MeshRenderer>().material.color = new Color(0f, 1f, 0f);
                GameObject.Find("checkup2").GetComponent<MeshRenderer>().material.color = new Color(0f, 1f, 0f);
                // sende fertiges Fenster uebers Band
                 moveit();
                //Nach richtiger Abgabe -> neues Rezept in RecipeGen
                GameObject.Find("RecipeGen").GetComponent<RecipeGen>().RoundRecipe();
                //Nach richtiger Abgabe -> gib einen Punkt
                scoreManager.addScore();
            }
            else
            {
                GameObject.Find("checkup").GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
                GameObject.Find("checkup2").GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
                AudioManager.Instance.Play(AudioManager.SoundType.Fail);
            }
        }
        else if (GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials == 3)   //checke für 3 Abgaben
        {
            if (deliveryorder[0] == recipe[0] && deliveryorder[1] == recipe[1] && deliveryorder[2] == recipe[2])
            {
                GameObject.Find("checkup").GetComponent<MeshRenderer>().material.color = new Color(0f, 1f, 0f);
                GameObject.Find("checkup2").GetComponent<MeshRenderer>().material.color = new Color(0f, 1f, 0f);
                // sende fertiges Fenster uebers Band
                moveit();
                //Nach richtiger Abgabe -> neues Rezept in RecipeGen
                GameObject.Find("RecipeGen").GetComponent<RecipeGen>().RoundRecipe();
                //Nach richtiger Abgabe -> gib einen Punkt
                scoreManager.addScore();
            }
            else
            {
                GameObject.Find("checkup").GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
                GameObject.Find("checkup2").GetComponent<MeshRenderer>().material.color = new Color(1f, 0f, 0f);
                AudioManager.Instance.Play(AudioManager.SoundType.Fail);
            }
        }
    }

    private void moveit()
    {
        window.GetComponent<CtoD>().goal = true;
    }

    public void Interact(GameObject player)
    {
        Press();
    }
}
