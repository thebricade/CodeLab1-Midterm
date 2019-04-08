using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SadVote : MonoBehaviour
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
        Debug.Log("Sad");
        string filePath = Application.dataPath + "/playerRating.txt";
        File.AppendAllText(filePath, "x");;
    }
}
