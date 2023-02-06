# Unity2D Rule Tile Helper

This is a neat little tool that helps you make new rule tiles easily by just changing out a sprite sheet.

It comes with templates to build from, and examples on how to use the tool.\
The rule tile uses 47 sprites to cover every possibility of directly neighboring tiles.\
This tool however uses 49 sprites total, instead of 47 to add a default sprite and a preview sprite for the asset window.\
You can use this tool, it's contents and examples, however you'd like.\
If you have any questions, suggestions, or feedback, please let me know!
<img src="https://user-images.githubusercontent.com/122301912/216240864-86a7e50c-9bcc-41f2-a11f-da1cda4dca6c.png" width="500">

# Fixed Issue Where Builds Would Fail
Moved all UnityEdior and System.Linq namespace uses, from the RuleTileFromTemplate.cs script to the RuleTileFromTemplateEditor.cs script. The UnityEditor namespace can't be used in scripts that need to be bundled for build.

# TO UPDATE
Delete the old RuleTileFromTemplate.cs and RuleTileFromTemplateEditor.cs files and replace them with the updated versions. If you see errors, you have to click the 'Use Sprite Sheet with Template rules' button again on every 'Rule Tile From Template' asset to re-sort the sprites.

# Instructions
**0.** This tool requires the Unity 2D Packages to function. You can install them from the Package Manager at 'Window > Package Manager'.\
If you don't see the 2D packages try changing the tab at the top of from 'Packages: In Project' to 'Packages: Unity Registry' to search for it.\
<img src="https://user-images.githubusercontent.com/122301912/216240948-e2b0740b-b45f-4689-8b83-e02c1e62ad7c.png" width="500">


**1.** Extract the 'RuleTileHelper' folder into your unity project's Assets folder.\
Make sure to move all of the .meta files along with the assets so that none of the references break.


**2.** To use your own sprites for the rule tile, make sure your sprites are in the same layout in their image file as the template sprite sheet.\
The size of the sprites do not matter as long as they follow the format of the template sprite sheet.\
I included 16x16, 32x32 and 64x64 templates, but you should be able to scale them to whatever size as long as they are in the same layout.\
In the Texture2D import settings for your sprite sheet, set the sprite mode to multiple and slice the texture by cell size into 49 sprites.\
Don't forget to set the pixels per unit to the desired amount.

![16x16SpriteSheetTemplate](https://user-images.githubusercontent.com/122301912/216241731-125881c9-6ad4-4496-9648-bb1140568ee5.png)
![16x16SpriteSheetExample](https://user-images.githubusercontent.com/122301912/216242646-f8b794fa-452f-41dc-8ae7-fa02c7ce5ccb.png)

>IMPORTANT Do not change the names of any of the sliced sprites in the Sprite Editor, as this tool uses the default assigned names of each sprite to properly apply them to the rule tile.

**3.** You can create a new rule tile by right clicking in your project window and going to 'Create > Rule Tile From Template'\
This should have 2 blank fields and a button in the inspector when selected.

<img src="https://user-images.githubusercontent.com/122301912/216242182-8f00f7b4-3336-40a0-989f-5f2f43dde346.png" width="500">


**4.** You should select the TemplateRules.asset to use for the "Template Rules" Field.\
You should select a correctly formatted sprite sheet to place into the "Sprite Sheet" field.\
A correctly formatted sprite sheet should have 49 sprites layed out as they are in the template sprite sheet.

<img src="https://user-images.githubusercontent.com/122301912/216242428-a505ea4f-b076-40d2-a056-aedbe0d9e881.png" width="250">


**5.** Once The fields have the correct items selected, click the "Use Sprite Sheet with Template Rules" button.\
If all went correctly, you should notice the Rule Tile change its icon to the sprite in the "preview" sprite slot of the sprite sheet.\
You can open the Tile Palette Window in 'Window > 2D > Tile Palette' and then click and drag this rule tile into a tile palette for use.


**6.** You need a tilemap to paint tiles on to, you can create one in the heirarchy window by right clicking and '2D Object > Tilemap > Rectangular'.


**7.** You can now use the Tile Palette window to paint the rule tiles and see them update according to their neighbor tiles in the scene.


# Things to know
>When clicking the "Use Sprite Sheet with Template Rules" button, if you have the Tile Palette window open, it will un-dock the window and reopen itself to refresh.\
>I could not find a better way refresh the tiles in that window.

>This *should* work with any 49 sprite sheet layout if you make your own rule tile to use in the "Template Rules" field and set the rules to work with that sprite layout.\
>The main caveat to this, is that the sprites must all be in the same order from the Texture2D's list of cut sprites as well as the new "Template Rules" rule tile.\
>Also, the new rule tile's Default Sprite (only used if an error occurs) and the Preview Sprite may not be correctly set in the project window.

>I might update this to add functionality if requested, so don't be afraid to suggest things.
