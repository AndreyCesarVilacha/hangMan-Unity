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
    private string choseWord;
    private string hiddenWord;

    // Start is called before the first frame update
    void Start()
    {
        //Taking a random word from 'wordsLocal'
        choseWord = wordsLocal[Random.Range(0, wordsLocal.Length)];
        //Passing the rando word to 'wordToFindField'
        wordToFindField.text = choseWord;
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
