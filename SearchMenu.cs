using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public  class CreateMenu : ScriptableObject, ISearchWindowProvider
{
    private Texture2D icon;

    
    private void OnEnable()
    {
        icon = new Texture2D(1, 1);
        icon.SetPixel(0, 0, new Color(0, 0, 0, 0));
        icon.Apply();
    }

    public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
    {
        var tree = new List<SearchTreeEntry>
        {
            new SearchTreeGroupEntry(new GUIContent("Create"), 0),
        };
        tree.Add(new SearchTreeGroupEntry(new GUIContent("Code"))
        {
            level = 1,
        });
        tree.Add(new SearchTreeGroupEntry(new GUIContent("Scripts"))
        {
            level = 2,
            //userData = 
        });
        tree.Add(new SearchTreeEntry(new GUIContent("C# Script",icon))
        {
            level = 3,
            //userData = 
        });
        tree.Add(new SearchTreeEntry(new GUIContent("Assembly Definition",icon))
        {
            level = 3,
            //userData = 
        });
        tree.Add(new SearchTreeGroupEntry(new GUIContent("Shaders"))
        {
            level = 2,
            //userData = 
        });
        tree.Add(new SearchTreeEntry(new GUIContent("Surface Shader",icon))
        {
            level = 3,
            //userData = 
        });
        tree.Add(new SearchTreeEntry(new GUIContent("Unlit Shader",icon))
        {
            level = 3,
            //userData = 
        });
        tree.Add(new SearchTreeEntry(new GUIContent("Compute Shader",icon))
        {
            level = 3,
            //userData = 
        });
        tree.Add(new SearchTreeGroupEntry(new GUIContent("Audio"))
        {
            level = 1,
        });
        return tree;
    }

    public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
    {
        return false;
    }
}