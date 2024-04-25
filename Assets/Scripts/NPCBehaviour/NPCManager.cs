using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    [Header("Components")]
    public TextMeshProUGUI NameSpace;
    public RawImage WhoIsTalkingPic;

    [Header("NPC Names")]
    public string NameHolder = "NameHolder";

    public string[] Names = new string[] { };
    [Header("NPC Pics")]
    public Texture2D[] texures = new Texture2D[] { };
    public Texture2D textureHolder;


    [Header("Mission Settings")]
    public int MissionSeleceted;


    private void Start()
    {
        
    }

    private void Update()
    {
        
        NameSpace.text = NameHolder;
        WhoIsTalkingPic.texture = textureHolder;

    }
}
