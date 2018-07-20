﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


// not done:
// this is a placeholder!
// i need to actually get questions from list

// this was originally meant to just contain the script to change the "Question" and "Answer" text,
// but i kind of accidentally put everything else in here too.
// todo: split that up for convenience????

public class SagumeLieText : MonoBehaviour
{

    // texts 

    // setting correct answer to 0 before it's decided
    public int sagumeCorrectAnswer = 0;

    // use SerializeField to reference GameObjects that will be used in the script
    // these are under the "ScriptController" object

    [SerializeField]
    private Animator DoremyAnimator;
    [SerializeField]
    private Animator SagumeAnimator;
    [SerializeField]
    private Animator BackgroundAnimator;

    [SerializeField]
    private TMP_Text QuestionText;
    [SerializeField]
    private TMP_Text AnswerText1;
    [SerializeField]
    private TMP_Text AnswerText2;

    [SerializeField]
    private GameObject QuestionBox;

    void Start()
    {
        // find the GameObjects we're going to be putting the text in
        // TODO: is there a 'better' way to do this?
     
        // placeholder question text
        // TODO: get question from the question list & randomize 

        QuestionText.SetText("This is a test question! It exists to show that I can change the text from the code. " +
        "Isn't that neat? I'm going to make it really long so that I can see what happens if the question is way too long.");

        // TEMPORARY
        // select which slot the correct answer will be in
        // this is just to show it can be randomized
        // if there's a better way, i'd love to know!

        sagumeCorrectAnswer = Random.Range(1, 3);

        // placeholder answers

        if (sagumeCorrectAnswer == 1)
            {
             AnswerText1.SetText("Correct Answer!");
             AnswerText2.SetText("Incorrect Answer!");
            }

        else if (sagumeCorrectAnswer == 2)
            {
              AnswerText1.SetText("Incorrect Answer!");
              AnswerText2.SetText("Correct Answer!");
            }

    }


    // that set up the question & answer text.
    // now, we check to see if the questions are answered.

    // TODO: see if there's a better way to do this?
    // it works but i feel there must be a more efficient way
    // both for checking if the button pressed is the correct one
    // and setting the animations for all the sprites to go off

    // this script is referenced in the "OnClick" of AnswerButton1 and AnswerButton2
    // it runs the relevant code below to check for answer correctness


    // if button 1 is clicked

    void AnswerCheckButton1()
    {
        QuestionBox.SetActive(false);

        if (sagumeCorrectAnswer == 1)
        {
            SagumeAnimator.SetBool("Success", true);
            DoremyAnimator.SetBool("Success", true);
            BackgroundAnimator.SetBool("Success", true);
            MicrogameController.instance.setVictory(victory: true, final: true);
        }
        else
        {
            SagumeAnimator.SetBool("Failure", true);
            DoremyAnimator.SetBool("Failure", true);
            BackgroundAnimator.SetBool("Failure", true);
            MicrogameController.instance.setVictory(victory: false, final: true);
        }
    }

    // if button 2 is clicked

    void AnswerCheckButton2()
    {
        QuestionBox.SetActive(false);

        if (sagumeCorrectAnswer == 2)
        {
            SagumeAnimator.SetBool("Success", true);
            DoremyAnimator.SetBool("Success", true);
            BackgroundAnimator.SetBool("Success", true);
            MicrogameController.instance.setVictory(victory: true, final: true);
        }
        else
        {
            SagumeAnimator.SetBool("Failure", true);
            DoremyAnimator.SetBool("Failure",true);
            BackgroundAnimator.SetBool("Failure", true);
            MicrogameController.instance.setVictory(victory: false, final: true);
        }

    }

}