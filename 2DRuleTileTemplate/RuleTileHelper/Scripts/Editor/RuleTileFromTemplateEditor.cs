using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(RuleTileFromTemplate))]
public class RuleTileFromTemplateEditor : Editor
{
    private Texture2D _thumbnailTexture;

    public static EditorWindow[] GetAllOpenEditorWindows()
    {
        return Resources.FindObjectsOfTypeAll<EditorWindow>();
    }

    override public void OnInspectorGUI()
    {
        //clever little piece of code that hides the inherited ruletile inspector properties
        SerializedObject so = new SerializedObject(target);
        SerializedProperty prop = so.GetIterator();
        bool enterChildren = true;
        bool draw = false;
        while (prop.NextVisible(enterChildren))
        {
            if (draw)
            {
                EditorGUILayout.PropertyField(prop);
            }
            if (prop.name.Equals("HideInherited"))
            {
                draw = true;
            }
            enterChildren = false;
        }
        so.ApplyModifiedProperties();



        RuleTileFromTemplate myScript = (RuleTileFromTemplate)target;
        if (GUILayout.Button("Use Sprite Sheet with Template Rules"))
        {
            myScript.ButtonClicked();
            //This forces the preview icon to update
            EditorUtility.SetDirty(myScript);
            Repaint();

            //Reopens Tile Palette Window, because afaik there is no other way to refresh from here due to the methods needed being private
            foreach (EditorWindow w in GetAllOpenEditorWindows())
            {
                if (w.titleContent.ToString() == "Tile Palette")
                {
                    w.Close();
                    EditorWindow.GetWindow(w.GetType(),false, "Tile Palette",false);
                }
            }
        }
    }


    //This changes the icon to the Sprite in the "PREVIEW" slot of the sprite sheet.
    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        RuleTileFromTemplate myScript = (RuleTileFromTemplate)target;
        myScript.ChangePreviewIcon();
        if (myScript.Thumbnail != null)
        {
            _thumbnailTexture = new Texture2D(myScript.Thumbnail.width, myScript.Thumbnail.height, myScript.Thumbnail.format, false);
            if (myScript.Thumbnail.mipmapCount > 1)
            {
                //You should never see this hopefully
                Debug.LogWarning("Rendered Default Icon because Thumbnail mip count was more than 1");
                return base.RenderStaticPreview(assetPath, subAssets, width, height);
            }
            Graphics.CopyTexture(myScript.Thumbnail, _thumbnailTexture);
        }

        if (_thumbnailTexture != null)
        {
            return _thumbnailTexture;
        }
        return base.RenderStaticPreview(assetPath, subAssets, width, height);
    }
}
