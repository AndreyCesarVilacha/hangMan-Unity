using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timeField;
    public Text wordToFindField;
    private float time;
    private string[] wordsLocal = { "MATT", "JOANNE", "ROBERT", "MARRY JANE" };
    private string chosenWord;
    private string hiddenWord;

    // Start is called before the first frame update
    void Start()
    {
        //Taking a random word from 'wordsLocal'
        chosenWord = wordsLocal[Random.Range(0, wordsLocal.Length)];
        //Passing the rando word to 'wordToFindField'
        for(int i = 0; i < chosenWord.Length; i++)
        {
            char letter = chosenWord[i];
            if (char.IsWhiteSpace(letter))
            {
                hiddenWord += " ";
            }
            else
            {
                hiddenWord += "_";
            }
            
        }
        wordToFindField.text = hiddenWord;
    }

    // Update is called once per frame
    void Update()
    {
        //Passing time using delta, use the interval between frames to calculate time
        time += Time.deltaTime;
        //Convert the time to String and pass to timeField, which is responsible
        //to show the user the time in the game
        timeField.text = time.ToString();
    }
}
