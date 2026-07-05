using UnityEngine;

public class OnF : MonoBehaviour
{
    [SerializeField]
    Material m_base;

    [SerializeField]
    Material m_alarm;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            print("F durchdrungen");
            print(GameObject.Find("door_right").GetComponent<Animator>().GetBool("forky_entering"));
            print(GameObject.Find("door_right").GetComponent<Animator>().GetBool("forky_entering"));

            //checke door_right
            if(GameObject.Find("door_right").GetComponent<Animator>().GetBool("forky_entering") == false)
            {
                GameObject.Find("door_right").GetComponent<Animator>().SetBool("forky_entering", true);
            }
            else if(GameObject.Find("door_right").GetComponent<Animator>().GetBool("forky_entering") == true)
            {
                GameObject.Find("door_right").GetComponent<Animator>().SetBool("forky_entering", false);
                GameObject.Find("door_right/Signal_Final").GetComponent<MeshRenderer>().sharedMaterial = m_base;
                GameObject.Find("alarm1").GetComponent<Light>().intensity = 0;
                AudioManager.Instance.Play(AudioManager.SoundType.doorCloseLeft);
            }

            //checke door_left
            if(GameObject.Find("door_left").GetComponent<Animator>().GetBool("forky_entering") == false)
            {
                GameObject.Find("door_left").GetComponent<Animator>().SetBool("forky_entering", true);
                GameObject.Find("door_left/Signal_Final").GetComponent<MeshRenderer>().sharedMaterial = m_alarm;
                GameObject.Find("alarm2").GetComponent<Light>().intensity = 100;
                AudioManager.Instance.Play(AudioManager.SoundType.doorOpenRight);
                AudioManager.Instance.Play(AudioManager.SoundType.ForkliftSwoosh);
            }
            else if(GameObject.Find("door_left").GetComponent<Animator>().GetBool("forky_entering") == true)
            {
                GameObject.Find("door_left").GetComponent<Animator>().SetBool("forky_entering", false);
            }
        }
    }
}
