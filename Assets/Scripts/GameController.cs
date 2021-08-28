using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameController : MonoBehaviour
{
    public Text timeField;
    public GameObject[] hangMan;
    public GameObject winText;
    public GameObject loseText;
    public Text wordToFindField;
    private float time;
    private string[] wordsLocal = { "MATT", "JOANNE", "ROBERT", "MARRY JANE" };

    private string[] words = File.ReadAllLines(@"Assets/Words.txt");
    private string chosenWord;
    private string hiddenWord;
    private int fails;
    private bool gameEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        //Taking a random word from 'wordsLocal'
        chosenWord = wordsLocal[Random.Range(0, wordsLocal.Length)];
        //Slicing the word
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
        //Passing the rando word to 'wordToFindField'
        wordToFindField.text = hiddenWord;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameEnd == false)
        {
            //Passing time using delta, use the interval between frames to calculate time
            time += Time.deltaTime;
            //Convert the time to String and pass to timeField, which is responsible
            //to show the user the time in the game
            timeField.text = time.ToString();
        }
    }

    //It's call every time a GUI event it is trigger, basic whenever a letter it is clicked
    //Override
    private void OnGUI()
    {
        Event e = Event.current;
        if(e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1)
        {
            //Getting the letter key pressed
            string pressedLetter = e.keyCode.ToString();
            if (chosenWord.Contains(pressedLetter))
            {
                int i = chosenWord.IndexOf(pressedLetter);
                while(i != -1)
                {
                    //Set new hidden word to everything before the i, change the i to the letter pressed,
                    //and everything after the i
                    hiddenWord = hiddenWord.Substring(0, i) + pressedLetter + hiddenWord.Substring(i+1);
                    Debug.Log(hiddenWord);

                    chosenWord = chosenWord.Substring(0, i) + "_" + chosenWord.Substring(i + 1);
                    Debug.Log(chosenWord);

                    i = chosenWord.IndexOf(pressedLetter);
                }

                wordToFindField.text = hiddenWord;

            }
            //Add a hang man body part
            else
            {
                hangMan[fails].SetActive(true);
                fails++;
            }
            if(fails == hangMan.Length)
            {
                loseText.SetActive(true);
                gameEnd = true;
            }
            if (!hiddenWord.Contains("_"))
            {
                winText.SetActive(true);
                gameEnd = true;
            }
        }
    }
}
