using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    //public Text nameText;

    public Text dialogueText;

    public Animator animator;
    private int currentSentence;
    private Dialogue dialogue;


    // Start is called before the first frame update
    void Start()
    {
        currentSentence = 0;
    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("isOpen", true);
        //nameText.text = dialogue.name;
        this.dialogue = dialogue;
        dialogueText.text = dialogue.sentences[currentSentence];
        // DisplayNextSentence();
    }

       public void DisplayNextSentence()
        {
        currentSentence++;
            if (currentSentence >= dialogue.sentences.Length)
            {
                EndDialogue();
                return;

            }
            dialogueText.text = dialogue.sentences[currentSentence];
    }

    public void DisplayPreviousSentence()
    {
       if (currentSentence == 0) {
            return;
       }
        currentSentence--;
        dialogueText.text = dialogue.sentences[currentSentence];
    }

    void EndDialogue()
        {
        animator.SetBool("isOpen", false);
        Debug.Log("end of monologue");
        }
      

    public void ExitDialogue()
    {
        animator.SetBool("isOpen", false);
        return;
    }


}
