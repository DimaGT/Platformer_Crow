using System.Collections;
using System.Collections.Generic;
using UnityEditor;


[CustomEditor(typeof(ItemBase))]
public class ItemBaseEditor : Editor
{
    private ItemBase itemBase;
    private void Awake() {
        itemBase = (itemBase)target;
    }
    public override void OnInspectorGUI()
    {
        if ()
        base.OnInspectorGUI();
    }
}
