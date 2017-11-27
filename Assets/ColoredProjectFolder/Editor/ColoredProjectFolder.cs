using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class ColoredProjectFolder
{
    static Texture2D iconEditorFolder;
    static Texture2D iconPluginsFolder;
    static Texture2D iconResourcesFolder;
    static Texture2D iconPrefabsFolder;
    static Texture2D iconScriptsFolder;

    static ColoredProjectFolder ()
    {
        EditorApplication.projectWindowItemOnGUI += OnProjectWindowItemOnGUI;
        iconEditorFolder = (Texture2D)AssetDatabase.LoadAssetAtPath ("Assets/ColoredProjectFolder/Editor/icon_editor.png", typeof(Texture2D));
        iconPluginsFolder = (Texture2D)AssetDatabase.LoadAssetAtPath ("Assets/ColoredProjectFolder/Editor/icon_plugins.png", typeof(Texture2D));
        iconResourcesFolder = (Texture2D)AssetDatabase.LoadAssetAtPath ("Assets/ColoredProjectFolder/Editor/icon_resources.png", typeof(Texture2D));
        iconPrefabsFolder = (Texture2D)AssetDatabase.LoadAssetAtPath ("Assets/ColoredProjectFolder/Editor/icon_prefabs.png", typeof(Texture2D));
        iconScriptsFolder = (Texture2D)AssetDatabase.LoadAssetAtPath ("Assets/ColoredProjectFolder/Editor/icon_scripts.png", typeof(Texture2D));
    }

    private static void OnProjectWindowItemOnGUI (string guid, Rect selectionRect)
    {
        string path = AssetDatabase.GUIDToAssetPath (guid);
        if (!AssetDatabase.IsValidFolder (path)) {
            return;
        }

        selectionRect.width = selectionRect.height + 2;

        var folderName = Path.GetFileNameWithoutExtension (path);
        if (folderName == "Editor") {
            GUI.DrawTexture (selectionRect, iconEditorFolder);    
        } else if (folderName == "Plugins") {
            GUI.DrawTexture (selectionRect, iconPluginsFolder);
        } else if (folderName == "Resources") {
            GUI.DrawTexture (selectionRect, iconResourcesFolder);
        } else if (folderName == "Prefabs") {
            GUI.DrawTexture (selectionRect, iconPrefabsFolder);
        } else if (folderName == "Scripts") {
            GUI.DrawTexture (selectionRect, iconScriptsFolder);
        }


    }
    

}