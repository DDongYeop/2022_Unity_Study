using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    None = 0,
    Health = 1,
    Ammo = 2
}

[CreateAssetMenu(menuName ="SO/Resource")]
public class ResourceDataSO : ScriptableObject
{
    public float rate; //아이템이 드랍될 확률
    public GameManager itemPrefab;

    public ResourceType resourcetype;
    public int minAmount = 1, maxAmount = 5;
    public AudioClip useSound;
    public Color popupTextColor;
    public int GetAmount()
    {
        return Random.Range(minAmount, maxAmount + 1); //int니까 마지막엔 +1을 해줘야함
    }
}
