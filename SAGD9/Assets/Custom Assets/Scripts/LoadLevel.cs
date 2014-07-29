using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using System.Collections;
using Debug = UnityEngine.Debug;

public class LoadLevel : MonoBehaviour
{

    public GameObject GrassPrefab;
    public GameObject WallPrefab;
    public GameObject PassableTerrainPrefab;

    public Transform PlayerObject;

    private float scale;

	// Use this for initialization
	void Start ()
	{
        Debug.Log(GrassPrefab.transform.localScale.x);
	    scale = (GrassPrefab.transform.localScale.x*16f)/100f;
        LoadLevelMethod();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void LoadLevelMethod()
    {
        // Get the lines from the level file        

        var lines = new List<string>();
        lines.Add( "|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|");
        lines.Add("|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|");
        lines.Add("|U|U|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|U|U|");
        lines.Add("|U|U|X|.|.|.|.|.|.|.|.|L|L|L|.|.|.|.|.|.|.|.|X|U|U|");
        lines.Add("|U|U|X|.|.|.|O|O|.|.|.|L|*L|L|.|.|.|.|.|.|.|.|X|U|U|");
        lines.Add("|U|U|X|.|.|.|.|.|.|.|.|L|L|L|.|.|.|.|.|.|.|.|X|U|U|");
        lines.Add("|U|U|X|L|L|L|L|L|L|L|L|L|L|L|L|L|L|L|L|L|L|L|X|U|U|");
        lines.Add("|U|U|X|L|L|L|L|L|L|L|L|L|L|L|L|L|L|L|L|L|L|L|X|U|U|");
        lines.Add("|U|U|X|.|.|.|.|.|.|.|.|L|L|L|.|.|.|.|.|.|.|.|X|U|U|");
        lines.Add("|U|U|X|.|.|.|.|.|.|.|.|L|L|L|.|.|.|O|O|.|.|.|X|U|U|");
        lines.Add("|U|U|X|.|.|.|.|.|.|.|.|L|L|L|.|.|.|.|.|.|.|.|X|U|U|");
        lines.Add("|U|U|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|X|U|U|");
        lines.Add( "|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|");
        lines.Add( "|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|U|");

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
                var Position = new KeyValuePair<int, int>(xIdx, yIdx);

                // Get rid of any excess whitespace in the string
                x.Trim();


                // Check if the block is our "spawnpoint"
                if (x.Contains("*"))
                {
                    PlayerObject.position = new Vector3(scale * Position.Key, scale * Position.Value, 10);
                    x = x.Replace("*", "");
                }

                // Check if the block is empty
                if (!x.Contains("-"))
                {
                    

                    if (x == ".")
                    {
                        CreateGrassObject(Position);
                    }
                    else if (x == "X")
                    {
                        CreateWallObject(Position, SpriteEnum.WallConcrete);
                    }
                    else if (x == "_")
                    {
                        CreatePassableObject(Position, SpriteEnum.CutGrass);
                    }
                    else if (x == "U")
                    {
                        CreateWallObject(Position, SpriteEnum.Asphalt);
                    }
                    else if (x == "O")
                    {
                        CreateWallObject(Position, SpriteEnum.WallWood);
                    }
                    else if (x == "L")
                    {
                        CreatePassableObject(Position, SpriteEnum.PassableConcrete);
                    }
                }
            });
            xIdx = 0;
        });
    }

    private void CreateWallObject(KeyValuePair<int, int> position, SpriteEnum type)
    {
        var newPrefab = Instantiate(WallPrefab, new Vector3(scale * position.Key, scale * position.Value, 30), new Quaternion()) as GameObject;
        newPrefab.GetComponent<TileManager>().UpdateSprite(type);
    }

    private void CreatePassableObject(KeyValuePair<int, int> position, SpriteEnum type)
    {
        var newPrefab = Instantiate(PassableTerrainPrefab, new Vector3(scale * position.Key, scale * position.Value, 30), new Quaternion()) as GameObject;
        newPrefab.GetComponent<TileManager>().UpdateSprite(type);
    }

    private void CreateGrassObject(KeyValuePair<int, int> position)
    {
        MowerTrackerHelper.GetMowerDataScript().TotalGrass++;
        Instantiate(GrassPrefab, new Vector3(scale * position.Key, scale * position.Value, 30), new Quaternion());
          
    }

}
