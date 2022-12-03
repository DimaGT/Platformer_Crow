using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffEmitter : MonoBehaviour
{
    [SerializeField] private Buff buff;
}
[System.Serializable]
public class Buff
{
    public BuffType type;
    public float additiveBonus;
    public float multipleBonus;
}

public enum BuffType : byte
{
    Damage, Force, Armor
}


