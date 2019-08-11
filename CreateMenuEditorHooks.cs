using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// https://gamedev.stackexchange.com/questions/142715/how-to-place-an-instance-of-editor-window-in-screen-center
/// </summary>
public static class CreateMenuEditorHooks
{
    public static System.Type[] GetAllDerivedTypes(this System.AppDomain aAppDomain, System.Type aType)
    {
        var result = new List<System.Type>();
        var assemblies = aAppDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.IsSubclassOf(aType))
                    result.Add(type);
            }
        }

        return result.ToArray();
    }

    public static Rect GetEditorMainWindowPos()
    {
        var containerWinType = System.AppDomain.CurrentDomain.GetAllDerivedTypes(typeof(ScriptableObject))
            .Where(t => t.Name == "ContainerWindow").FirstOrDefault();
        if (containerWinType == null)
            throw new System.MissingMemberException(
                "Can't find internal type ContainerWindow. Maybe something has changed inside Unity");
        var showModeField = containerWinType.GetField("m_ShowMode",
            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var positionProperty = containerWinType.GetProperty("position",
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        if (showModeField == null || positionProperty == null)
            throw new System.MissingFieldException(
                "Can't find internal fields 'm_ShowMode' or 'position'. Maybe something has changed inside Unity");
        var windows = Resources.FindObjectsOfTypeAll(containerWinType);
        foreach (var win in windows)
        {
            var showmode = (int) showModeField.GetValue(win);
            if (showmode == 4) // main window
            {
                var pos = (Rect) positionProperty.GetValue(win, null);
                return pos;
            }
        }

        throw new System.NotSupportedException(
            "Can't find internal main window. Maybe something has changed inside Unity");
    }

    public static Vector2 CenterOnMainWin()
    {
        var main = GetEditorMainWindowPos();
        return new Vector2(main.x+main.width/2f,main.y+main.height/2f);
    }
}