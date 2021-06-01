using System.Collections;
using UnityEngine;

// Main controller script to choreograph the intro animation and sounds
public class MenuAnimationScript : MonoBehaviour
{
    [SerializeField] private GameObject sidePanel;

    [SerializeField] private GameObject birds;

    [SerializeField] private GameObject dustObj;

    void Start()
    {
        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        AudioManager.instance.Play("Countryside");
        AudioManager.instance.Play("Woosh");
        yield return new WaitForSeconds(.4f);

        Instantiate(dustObj);
        AudioManager.instance.Play("Thud");

        birds.SetActive(true);

        yield return new WaitForSeconds(.2f);

        AudioManager.instance.Play("Birds");


        AudioManager.instance.Play("Woosh");

        yield return new WaitForSeconds(.4f);

        AudioManager.instance.Play("Creak");

        yield return new WaitForSeconds(.9f);

        sidePanel.SetActive(true);

        AudioManager.instance.Play("Rise");

        yield return new WaitForSeconds(1.2f);

        AudioManager.instance.Stop("Countryside");

        if(!AudioManager.instance.IsPlaying("MenuMusic"))
            AudioManager.instance.Play("MenuMusic");
    }
}
