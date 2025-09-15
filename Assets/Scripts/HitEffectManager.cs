using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitSurfaceType
{
    Dirt = 0,
    Blood = 1,
}

[System.Serializable]
public class HitEffectMapper
{
    public HitSurfaceType surfaceType;
    public GameObject hitEffectPrefab;
}
public class HitEffectManager : MonoBehaviour
{
    public HitEffectMapper[] effectMap;
}
