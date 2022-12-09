using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(ItemBase))]
public class ItemBaseEditor : Editor
{
    private ItemBase itemBase;
    private void Awake() {
        itemBase = (ItemBase)target;
    }
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("New Item"))
            itemBase.CreateItem();
        if (GUILayout.Button("Remove"))
            itemBase.RemoveItem();
        if (GUILayout.Button("<="))
            itemBase.PrevItem();
        if (GUILayout.Button("=>"))
            itemBase.NextItem();
        base.OnInspectorGUI();
    }
}
