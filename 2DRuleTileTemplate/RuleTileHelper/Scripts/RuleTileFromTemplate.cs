using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu]
public class RuleTileFromTemplate : RuleTile<RuleTileFromTemplate.Neighbor> {
    public bool HideInherited;
    private List<Tilemap> tmList;
    private List<TilingRule> ruleholder;
    public RuleTile TemplateRules;
    public Texture2D SpriteSheet;
    [HideInInspector]
    public Texture2D Thumbnail;
    public List<Sprite> SortedSprites;

    public void ButtonClicked()
    {
        //Gets All Tilemaps in Scene, so we can update them when the tiles change.
        tmList = new List<Tilemap>();
        tmList.AddRange(FindObjectsOfType<Tilemap>());

        //Assigns The rules from the template to this rule tile
        ruleholder = new List<TilingRule>();
        if (TemplateRules != null && SpriteSheet != null)
        {

            foreach (TilingRule item in TemplateRules.m_TilingRules)
            {
                TilingRule temporaryitem = item.Clone();
                ruleholder.Add(temporaryitem);
            }
            if(ruleholder.Count != 47)

            {
                Debug.LogError("There is an incorrect amount of rules in the Template RuleTile. \n Expected Rules : 47 | Given Rules : " + ruleholder.Count);
            }
            m_TilingRules.Clear();
            m_TilingRules = ruleholder;

            ChangeSprites();
            }
    }

    private void ChangeSprites()
    {

        //This assigns each sprite from the spritesheet to the rule tile
        for (int i = 0; i < m_TilingRules.Count; i++)
        {
            m_TilingRules[i].m_Sprites[0] = SortedSprites[i];
        }
        //Assigns the rule tiles Default sprite to the Sprite in the "DEFAULT" slot in the spritesheet
        //If all goes well you shouldn't see the "Default" sprite, it is just the sprite that is used when none of the tile's rules apply.
        //(which shouldn't happen if you are following instructions)
        m_DefaultSprite = m_TilingRules[m_TilingRules.Count - 2].m_Sprites[0];
        ChangePreviewIcon();
        RefreshAll();
    }

    public void ChangePreviewIcon()
    {
        //Only works with spritesheets that follow the 49 sprite pattern. They should work with any tile size but you need to be using the Template Sprite Sheet's format.
        //Assigns the sprite in the "Preview" slot of the sprite sheet to a public variable so that the editor script can use it.
        if (SpriteSheet != null)
        {
            if (SortedSprites.Count != 49)
            {
                Debug.LogError("The number of sprites from the Sprite Sheet doesn't match the number of sprites from the Sprite Sheet Template.\nMake sure the sprites are cut properly in the Texture2D import settings.");
                return;
            }
            Rect _rect = SortedSprites[SortedSprites.Count - 1].rect;
            RectInt _rectInt = new RectInt(Mathf.FloorToInt(_rect.x), Mathf.FloorToInt(_rect.y), Mathf.FloorToInt(_rect.width), Mathf.FloorToInt(_rect.height));
            Texture2D previewTexture = new Texture2D(_rectInt.width, _rectInt.height, SpriteSheet.format, false);
            Graphics.CopyTexture(SpriteSheet, 0, 0, _rectInt.x, _rectInt.y, _rectInt.width, _rectInt.height, previewTexture, 0, 0, 0, 0);
            Thumbnail = previewTexture;
        }



    }

    public void RefreshAll()
    {
        foreach (Tilemap tm in tmList)
        {
            tm.RefreshAllTiles();
        }
        tmList.Clear();
    }


    //I don't know what these do and I don't care to find out, but if I remove them, it throws so many errors.
    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public const int Null = 3;
        public const int NotNull = 4;
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor) {
            case Neighbor.Null: return tile == null;
            case Neighbor.NotNull: return tile != null;
        }
        return base.RuleMatch(neighbor, tile);
    }

}
