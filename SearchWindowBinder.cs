using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SearchWindowBinder
{
    private static CreateMenu menu;

    [MenuItem("Assets/Show bar")]
    public static void EnableSearchBar()
    {
        menu = ScriptableObject.CreateInstance<CreateMenu>();
        SearchWindow.Open(new SearchWindowContext(CreateMenuEditorHooks.CenterOnMainWin()), menu);
    }
}