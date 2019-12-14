using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialHandler : MonoBehaviour {

    public bool DEBUGON;

    public GameObject introCanvas;
    public GameObject player01;
    public GameObject player02;
    public Image fader;
    public Text narrationText;

    public bool isPlayingTutorial;

    public Dialogue dialogue;
    public string[] endScript = { "My boy...", 
        "I hope you can hear me.", 
        "I'm not giving up on you. We both have too much growing up to do.", 
        "You and me, always. We got through the last few years, we'll get through this too.",
        "I don't know how, but I'll save you." };

	// Use this for initialization
	void Start () {

        if (DEBUGON == true)
        {
            return;
        }
        else if (DEBUGON == false)
        {
            StartCoroutine(playIntro());
        }

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator playIntro()
    {
        isPlayingTutorial = true;
        introCanvas.SetActive(true);

        yield return new WaitForSeconds(3);
        StartCoroutine(typeNarration("I remember when you were so tiny I could hold you in one hand."));
        yield return new WaitForSeconds(8);
        narrationText.text = "";
        StartCoroutine(typeNarration("I remember telling you how I would always keep you safe."));
        yield return new WaitForSeconds(8);
        narrationText.text = "";
        StartCoroutine(typeNarration("It's been just you and me for so long now, I can't think of me without you."));
        yield return new WaitForSeconds(10);
        narrationText.text = "";
        StartCoroutine(typeNarration("Can you hear me now?"));
        yield return new WaitForSeconds(8);
        narrationText.text = "";
        yield return new WaitForSeconds(2);
        fader.CrossFadeAlpha(0f, 4f, false);
        yield return new WaitForSeconds(8);
        player02.SetActive(false);
        player01.SetActive(true);
        yield return new WaitForSeconds(3);
        GameObject proxyGameObject = new GameObject();
        proxyGameObject.AddComponent<NPC>();
        proxyGameObject.GetComponent<NPC>().dialogue = endScript;

        dialogue.Speak(proxyGameObject);

        yield return null;


    }

    public IEnumerator typeNarration (string script)
    {
        foreach (char c in script)
        {
            narrationText.text += c;
            yield return new WaitForSeconds(0.015f);
        }
    }

    public IEnumerator endTutorial()
    {
        fader.CrossFadeAlpha(1f, 6f, false);
        isPlayingTutorial = false;
        yield return new WaitForSeconds(7);
        introCanvas.SetActive(false);
    }


}
