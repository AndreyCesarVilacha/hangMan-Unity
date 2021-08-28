using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text timeField;
    private float time;
    private string[] wordsLocal = { "MATT", "JOANNE", "ROBERT", "MARRY JANE" };

    // Start is called before the first frame update
    void Start()
    {
        
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
