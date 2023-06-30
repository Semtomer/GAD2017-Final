using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Image[] faces;
    public int level;
    public Animator animator;

    public static FMOD.Studio.EventInstance Typewriter;

    public GameObject continueButton;
    public GameObject backButton;

    private List<string> sentences;
    string sentence;
    int liveIndex = 0;
    
    void Start()
    {
        sentences = new List<string>();

        Typewriter = FMODUnity.RuntimeManager.CreateInstance("event:/Typewriter");

        backButton.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        liveIndex = 0;
        VisibilityOfButtons(liveIndex);
        animator.SetBool("isOpen", true);
        Cursor.visible = true;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Add(sentence);
        }

        sentence = sentences[liveIndex];

        StartCoroutine(TypeSentence(sentence));
    }
    void VisibilityOfButtons(int liveIndex)
    {
        if (liveIndex != sentences.Count - 1)
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }

        if (liveIndex != 0)
        {
            backButton.SetActive(true);
        }
        else
        {
            backButton.SetActive(false);
        }
    }
    public void DisplayNextSentence()
    {
        liveIndex += 1;

        VisibilityOfButtons(liveIndex);

        sentence = sentences[liveIndex];
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void DisplayPreviousSentence()
    {
        liveIndex -= 1;

        VisibilityOfButtons(liveIndex);

        sentence = sentences[liveIndex];

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        if (sentence.Substring(0, 3) == "BIG" || sentence.Substring(0, 3) == "WEA")
        {
            faces[0].gameObject.SetActive(true);
            faces[1].gameObject.SetActive(false);
            faces[2].gameObject.SetActive(false);
        }
        else if (sentence.Substring(0, 3) == "SOL" || sentence.Substring(0, 3) == "-SO")
        {
            faces[0].gameObject.SetActive(false);
            faces[1].gameObject.SetActive(true);
            faces[2].gameObject.SetActive(false);
        }
        else if (sentence.Substring(0, 3) == "TAN" || sentence.Substring(0, 3) == "HEL")
        {
            faces[0].gameObject.SetActive(false);
            faces[1].gameObject.SetActive(false);
            faces[2].gameObject.SetActive(true);
        }

        Typewriter.start();

        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        Typewriter.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public static bool loadagree;
    public void EndDialogue()
    {
        if(level == 1)
        {
            if(tankboss.enemyhealth <= 0)
            {
                SceneManager.LoadScene(10);
            }
        }
        else if(level == 2)
        {
            if(VenomSnack.enemyhealth <= 0)
            {
                SceneManager.LoadScene(8);
            }
        }
        loadagree = true;
        level1gamecontroller.conversationwork = false;
        StopAllCoroutines();
        Typewriter.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        animator.SetBool("isOpen", false);

        Cursor.visible = false;
    }
}
