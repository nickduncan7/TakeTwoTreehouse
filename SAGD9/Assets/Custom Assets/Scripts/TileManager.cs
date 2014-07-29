using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour
{

    public Sprite Grass;
    public Sprite CutGrass;
    public Sprite PassableConcrete;
    public Sprite WallConcrete;
    public Sprite WallWood;
    public Sprite Asphalt;

    private Sprite SelectedSprite;


    public void UpdateSprite(SpriteEnum spriteType)
    {
        switch (spriteType)
        {
            case SpriteEnum.Asphalt:
                SelectedSprite = Asphalt;
                break;
            case SpriteEnum.CutGrass:
                SelectedSprite = CutGrass;

                break;
            case SpriteEnum.Grass:
                SelectedSprite = Grass;

                break;
            case SpriteEnum.PassableConcrete:
                SelectedSprite = PassableConcrete;

                break;
            case SpriteEnum.WallConcrete:
                SelectedSprite = WallConcrete;

                break;
            case SpriteEnum.WallWood:
                SelectedSprite = WallWood;

                break;

        }
        var srenderer = this.GetComponent<SpriteRenderer>();
        srenderer.sprite = SelectedSprite;
    }
}

public enum SpriteEnum
{
    Grass = 0, CutGrass = 1, PassableConcrete = 2, WallConcrete = 3, WallWood = 4, Asphalt = 5
}