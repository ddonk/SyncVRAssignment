using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Difficulty")]
public class DifficultySO : ScriptableObject
{
    public bool IsInfinite;
    public bool HasMultipleAnimals;
    public bool HasAnimalVariants;
    public float MoveSpeed;
    public float TimeRevealed;
}
