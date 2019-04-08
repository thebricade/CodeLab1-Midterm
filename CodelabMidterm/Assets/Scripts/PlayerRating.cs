using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System.IO;
using System; 


public class PlayerRating : MonoBehaviour
{
    //public InputField playerComment; 
    private string sadVote;
    private string happyVote;
    public GameObject sadFace;
    public GameObject happyFace; 

    //private const string File_PlayerRating = "/playerRating.txt";

    // Start is called before the first frame update
    void Start()
    {
        //playerComment.text = "Enter Text Here...";
        //create the file if it doesn't exist 
        string filePath = Application.dataPath + "/playerRating.txt";
        if (!File.Exists(filePath))
        {
            string output = "test"; 
            
            File.WriteAllText(filePath,output);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
