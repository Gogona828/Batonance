using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TemplateSoundDataAsset", menuName = "ScriptableObject/CreateSoundDataAsset")]
public class SoundDataAsset : ScriptableObject
{
    public AudioClip soundFile;
    public TextAsset notesData;
    public int measure;
}
