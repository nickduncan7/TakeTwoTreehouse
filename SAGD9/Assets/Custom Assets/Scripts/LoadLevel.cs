using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using System.Collections;
using Debug = UnityEngine.Debug;

public class LoadLevel : MonoBehaviour
{

    public GameObject GrassPrefab;
    public GameObject ConcretePrefab;
    public Transform PlayerObject;

    private float scale;

    public string LevelToLoad = "TestLevel";
	// Use this for initialization
	void Start ()
	{
        Debug.Log(GrassPrefab.transform.localScale.x);
	    scale = (GrassPrefab.transform.localScale.x*8f)/100f;
	    LoadLevelMethod(LevelToLoad);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LoadLevelMethod(string FileName)
    {
        // Get the lines from the level file        
        List<string> lines = GetTextFromFile(FileName);

        int yIdx = 0;
        int xIdx = 0;

        // Split by lines
        lines.ForEach(y =>
        {
            yIdx++;
            // Get the strings in-between the vertical bars
            var xCoordinates = y.Split('|').ToList();

            xCoordinates.ForEach(x =>
            {
                xIdx++;
                bool isSpawnPoint = false;

                // Get rid of any excess whitespace in the string
                x.Trim();


                // Check if the block is our "spawnpoint"
                if (x.Contains("*"))
                {
                    isSpawnPoint = true;
                    x = x.Replace("*", "");
                }

                // Check if the block is empty
                if (!x.Contains("-"))
                {
                    var Position = new KeyValuePair<int, int>(xIdx, yIdx);

                    if (x == ".")
                    {
                        CreateGrassObject(Position, isSpawnPoint);
                    }
                    else if (x == "X")
                    {
                        CreateConcreteObject(Position);
                    }
                }
            });
            xIdx = 0;
        });
    }

    private void CreateConcreteObject(KeyValuePair<int, int> position)
    {
        Instantiate(ConcretePrefab, new Vector3(scale * position.Key, scale * position.Value, 30), new Quaternion());
    }

    private void CreateGrassObject(KeyValuePair<int, int> position, bool isSpawnPoint)
    {
        Instantiate(GrassPrefab, new Vector3(scale * position.Key, scale * position.Value, 30), new Quaternion());
        if (isSpawnPoint)
            PlayerObject.position = new Vector3(scale * position.Key, scale * position.Value, 10);
    }

    private List<string> GetTextFromFile(string fileName)
    {
        var blob = System.IO.File.ReadAllText(@"Assets\Custom Assets\Levels\" + fileName + ".txt");
        var ret = blob.Split('\n').ToList();
        ret.Reverse();

        return ret;
    }


}

internal class BlockController
{
}
