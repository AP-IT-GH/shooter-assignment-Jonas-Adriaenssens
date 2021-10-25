using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    Text txt;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = 0; 
        txt = gameObject.GetComponent<Text>();
        txt.text = score.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = score.ToString();    
    }
}
 