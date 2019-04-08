using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System.IO;
using System;
using System.Reflection;


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

        /*string[] inputLines = File.ReadAllLines(filePath); 
        for (int y = 0; y < inputLines.Length; y++)
        {
            string line = inputLines[y];
            for (int x = 0; x < line.Length; x++)
            {
                //create empty GameObject
                GameObject tile = null;
                switch (line[x])
                {
                    case 'x': 
                        //make a sad face
                        tile = Instantiate(Resources.Load("Prefabs/Sad")) as GameObject;
                        break;
                    case 'o': 
                        //make a happy face
                        tile = Instantiate(Resources.Load("Prefabs/Happy")) as GameObject;
                        break;
                    default:
                        tile = null;
                        break;        
                }
                //position the tile 
                if (tile != null)
                {
                    tile.transform.position = new Vector3(x - line.Length/2f, inputLines.Length/2f-y); 
                }
            }
        }*/ 

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
