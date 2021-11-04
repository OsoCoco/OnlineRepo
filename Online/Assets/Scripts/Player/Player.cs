using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
public class Player : NetworkBehaviour
{

    [SyncVar(hook = nameof(HandleTextUpdate))]
    string text;

    [SyncVar(hook = nameof(HandleColorUpdate))]
    [SerializeField] Color displayColor;

    //[SyncVar]
    [SerializeField] Renderer render;

    
    public TMP_Text playerName;

    [Server]
    public void UpdateName(string newName)
    {
        text = newName;
    }


    [Server]
    public void ChangeColor()
    {
        var mesh = GetComponent<MeshRenderer>();

        if(mesh)
        {
            var mat = new Material(mesh.sharedMaterial) { color = new Color(Random.Range(0, 1), Random.Range(0, 1), Random.Range(0, 1)) };
            mesh.sharedMaterial = mat;
        }
      
    }


    [Server]
   
    void HandleTextUpdate(string oldName, string newName)
    {
        playerName.text = newName;
    }
    [Server]
    void HandleColorUpdate(Color old,Color newColor)
    {
        render.material.SetColor("_Color", newColor);
    }
}
