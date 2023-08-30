//Autor: Klaus Wiegmann
using UnityEngine;

[CreateAssetMenu(fileName = "New Balancing Data", menuName = "Custom/Balancing Data")]
public class BalancingData : ScriptableObject
//Diese Klasse dient dazu, verschiedene Balancing Werte, die festgelegt werden müssen, zentral einzutragen, sodass sie leicht zu ändern sind.
{
    public float SkillScaleFactor;
    public float exampleVal1;
    public int exampleVal2;
    //public (TYPE) NeuerWert;
}
