using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HappyVote : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Happy");
        string filePath = Application.dataPath + "/playerRating.txt";
        //File.WriteAllText(filePath,"x");
        File.AppendAllText(filePath, "o");
    }
}
