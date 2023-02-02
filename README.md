# Unity2D Rule Tile Helper

This is a neat little tool that helps you make new rule tiles easily by just changing out a sprite sheet.

It comes with templates to build from, and examples on how to use the tool.\
You can use this tool, it's contents and examples, however you'd like.\
If you have any questions, suggestions, or feedback, please let me know!

# Instructions
0. This tool requires the Unity 2D Packages to function. You can install them from the Package Manager at 'Window > Package Manager'.\
If you don't see the 2D packages try changing the tab at the top of from 'Packages: In Project' to 'Packages: Unity Registry' to search for it.


1. Extract the 'RuleTileHelper' folder into your unity project's Assets folder.\
Make sure to move all of the .meta files along with the assets so that none of the references break.


2. To use your own sprites for the rule tile, make sure your sprites are in the same layout in their image file as the template sprite sheet.\
The size of the sprites do not matter as long as they follow the format of the template sprite sheet.\
I included 16x16,32x32 and 64x64 templates, but you should be able to scale them to whatever size as long as they are in the same layout.\
You should have the sprite mode set to multiple and slice the texture into 49 sprites using the Sprite Editor in the Import Settings.\
>IMPORTANT Do not change the names of any of the sprites in the Sprite Editor, as this tool uses the default assigned names of each sprite to properly apply them to the rule tile.


3. You can create a new rule tile by right clicking in your project window and going to 'Create > Rule Tile From Template'\
This should have 2 blank fields and a button in the inspector when selected.


4. You should select the TemplateRules.asset to use for the "Template Rules" Field.\
You should select a correctly formatted sprite sheet to place into the "Sprite Sheet" field.\
A correctly formatted sprite sheet should have 49 sprites layed out as they are in the template sprite sheet.


5. Once The fields have the correct items selected, click the "Use Sprite Sheet with Template Rules" button.\
If all went correctly, you should notice the Rule Tile change its icon to the sprite in the "preview" sprite slot of the sprite sheet.\
You can open the Tile Palette Window in 'Window > 2D > Tile Palette'. You can now click and drag this rule tile into a tile palette for use.


6. You need a tilemap to paint tiles on to, you can create one in the heirarchy window by right clicking and '2D Object > Tilemap > Rectangular'.


7. You can now use the Tile Palette window to paint the rule tiles and see them update according to their neighbor tiles in the scene.
