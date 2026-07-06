using UnityEngine;
using System.Collections;

public class DeliveryButton : MonoBehaviour, IInteractable
{
    public GameObject spotOne;
    public GameObject spotTwo;
    public GameObject spotThree;
    public GameObject window;
    private bool useDoubleScore;
    string[] deliveryorder;
    string[] recipe = { "Dichtung" };
    public ScoreManager scoreManager;
    public TimeManager timeManager;
    void Start() 
    {
        deliveryorder = new string[GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials];
        GameObject.Find("checklight1").GetComponent<Light>().intensity = 0;
        GameObject.Find("checklight2").GetComponent<Light>().intensity = 0;
        GameObject.Find("checklight3").GetComponent<Light>().intensity = 0;
    }

    IEnumerator wait(float duration)
    {
        //AbgabeAnimation
        GameObject.Find("deliverystation").GetComponent<Animator>().SetBool("deliver", true);
        
        yield return new WaitForSeconds(duration);

        //AbgabeAnimationBack
        GameObject.Find("deliverystation").GetComponent<Animator>().SetBool("deliver", false);

        // ueberprüfe die Abgabestation
        checkup(spotOne, spotTwo, spotThree);

        AudioManager.Instance.Play(AudioManager.SoundType.DeliveryButtonPress);

        Renew();

        yield return new WaitForSeconds(duration);

        GameObject.Find("checklight1").GetComponent<Light>().intensity = 0;
        GameObject.Find("checklight2").GetComponent<Light>().intensity = 0;
        GameObject.Find("checklight3").GetComponent<Light>().intensity = 0;
    }

    public void Press()
    {
        useDoubleScore = ScoreManager.scoreMultiplier == 2;
        
        AudioManager.Instance.Play(AudioManager.SoundType.deliveryStation);

        gameObject.GetComponent<Animator>().SetTrigger("push");

        StartCoroutine(wait(2f));
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
        }
        else if (one.transform.Find("spawnee2").GetComponent<MeshRenderer>().enabled == true)
        {
            deliveryorder[0] = "Dichtung";
        }
        else if (one.transform.Find("spawnee3").GetComponent<MeshRenderer>().enabled == true)
        {
            deliveryorder[0] = "Beschlag";
        }
        else if (one.transform.Find("spawnee4").GetComponent<MeshRenderer>().enabled == true)
        {
            deliveryorder[0] = "Glasleiste";
        }
        else if (one.transform.Find("spawnee5").GetComponent<MeshRenderer>().enabled == true)
        {
            deliveryorder[0] = "Isolierglas";
        }
        else if (one.transform.Find("spawnee6").GetComponent<MeshRenderer>().enabled == true)
        {
            deliveryorder[0] = "Fluegel";
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
            }
            else if (two.transform.Find("spawnee2").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[1] = "Dichtung";
            }
            else if (two.transform.Find("spawnee3").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[1] = "Beschlag";
            }
            else if (two.transform.Find("spawnee4").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[1] = "Glasleiste";
            }
            else if (two.transform.Find("spawnee5").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[1] = "Isolierglas";
            }
            else if (two.transform.Find("spawnee6").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[1] = "Fluegel";
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
            }
            else if (three.transform.Find("spawnee2").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[2] = "Dichtung";
            }
            else if (three.transform.Find("spawnee3").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[2] = "Beschlag";
            }
            else if (three.transform.Find("spawnee4").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[2] = "Glasleiste";
            }
            else if (three.transform.Find("spawnee5").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[2] = "Isolierglas";
            }
            else if (three.transform.Find("spawnee6").GetComponent<MeshRenderer>().enabled == true)
            {
                deliveryorder[2] = "Fluegel";
            }
            else
            {
                deliveryorder[2] = "none";
            }
        }

        if (GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials == 1) //checke für 1 Abgabe
        {
            string[] recipe = { "Dichtung" };

            if (deliveryorder[0] == recipe[0])
            {
                GameObject.Find("checklight1").GetComponent<Light>().color = Color.green;
                GameObject.Find("checklight2").GetComponent<Light>().color = Color.green;
                GameObject.Find("checklight3").GetComponent<Light>().color = Color.green;
                GameObject.Find("checklight1").GetComponent<Light>().intensity = 300;
                GameObject.Find("checklight2").GetComponent<Light>().intensity = 300;
                GameObject.Find("checklight3").GetComponent<Light>().intensity = 300;
                //Nach richtiger Abgabe -> neues Rezept in RecipeGen
                GameObject.Find("RecipeGen").GetComponent<RecipeGen>().RoundRecipe();
                //das Tutorial wurde abgeschlossen, starte die Runde
                GameObject.Find("timerText").GetComponent<TimeManager>().StartRound();
                moveit();
            }
            else
            {
                GameObject.Find("checklight1").GetComponent<Light>().color = Color.red;
                GameObject.Find("checklight2").GetComponent<Light>().color = Color.red;
                GameObject.Find("checklight3").GetComponent<Light>().color = Color.red;
                GameObject.Find("checklight1").GetComponent<Light>().intensity = 300;
                GameObject.Find("checklight2").GetComponent<Light>().intensity = 300;
                GameObject.Find("checklight3").GetComponent<Light>().intensity = 300;
                AudioManager.Instance.Play(AudioManager.SoundType.Fail);
            }
        }
        else if (GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials == 2)   //checke für 2 Abgaben
        {
            if (deliveryorder[0] == recipe[0] && deliveryorder[1] == recipe[1])
            {
                GameObject.Find("checklight1").GetComponent<Light>().color = Color.green;
                GameObject.Find("checklight2").GetComponent<Light>().color = Color.green;
                GameObject.Find("checklight3").GetComponent<Light>().color = Color.green;
                GameObject.Find("checklight1").GetComponent<Light>().intensity = 300;
                GameObject.Find("checklight2").GetComponent<Light>().intensity = 300;
                GameObject.Find("checklight3").GetComponent<Light>().intensity = 300;
                // sende fertiges Fenster uebers Band
                 moveit();
                //Nach richtiger Abgabe -> neues Rezept in RecipeGen
                GameObject.Find("RecipeGen").GetComponent<RecipeGen>().RoundRecipe();
                //Nach richtiger Abgabe -> gib einen Punkt
                //scoreManager.addScore();
                scoreManager.addScore(useDoubleScore);
            }
            else
            {
                GameObject.Find("checklight1").GetComponent<Light>().color = Color.red;
                GameObject.Find("checklight2").GetComponent<Light>().color = Color.red;
                GameObject.Find("checklight3").GetComponent<Light>().color = Color.red;
                GameObject.Find("checklight1").GetComponent<Light>().intensity = 300;
                GameObject.Find("checklight2").GetComponent<Light>().intensity = 300;
                GameObject.Find("checklight3").GetComponent<Light>().intensity = 300;
                AudioManager.Instance.Play(AudioManager.SoundType.Fail);
            }
        }
        else if (GameObject.Find("RecipeGen").GetComponent<RecipeGen>().numberOfMaterials == 3)   //checke für 3 Abgaben
        {
            if (deliveryorder[0] == recipe[0] && deliveryorder[1] == recipe[1] && deliveryorder[2] == recipe[2])
            {
                GameObject.Find("checklight1").GetComponent<Light>().color = Color.green;
                GameObject.Find("checklight2").GetComponent<Light>().color = Color.green;
                GameObject.Find("checklight3").GetComponent<Light>().color = Color.green;
                GameObject.Find("checklight1").GetComponent<Light>().intensity = 300;
                GameObject.Find("checklight2").GetComponent<Light>().intensity = 300;
                GameObject.Find("checklight3").GetComponent<Light>().intensity = 300;
                // sende fertiges Fenster uebers Band
                moveit();
                //Nach richtiger Abgabe -> neues Rezept in RecipeGen
                GameObject.Find("RecipeGen").GetComponent<RecipeGen>().RoundRecipe();
                //Nach richtiger Abgabe -> gib einen Punkt
                scoreManager.addScore(useDoubleScore);
            }
            else
            {
                GameObject.Find("checklight1").GetComponent<Light>().color = Color.red;
                GameObject.Find("checklight2").GetComponent<Light>().color = Color.red;
                GameObject.Find("checklight3").GetComponent<Light>().color = Color.red;
                GameObject.Find("checklight1").GetComponent<Light>().intensity = 300;
                GameObject.Find("checklight2").GetComponent<Light>().intensity = 300;
                GameObject.Find("checklight3").GetComponent<Light>().intensity = 300;
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
