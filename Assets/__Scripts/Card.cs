using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {

    [Header("Set Dynamically")]
    public string suit;
    public int rank;
    public Color color = Color.black;
    public string colS = "Black";
    public List<GameObject> decoGOs = new List<GameObject>();
    public List<GameObject> pipGOs = new List<GameObject>();
    public GameObject back;
    public CardDefinition def;
    public SpriteRenderer[] spriteRenderers;

    public bool faceUp
    {
        get
        {
            return (!back.activeSelf);
        }
        set
        {
            back.SetActive(!value);
        }
    }

    public void PopulateSpriteRenderes()
    {
        if (spriteRenderers == null || spriteRenderers.Length == 0)
        {
            spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        }
    }

    public void SetSortingLayerName(string tSLN)
    {
        PopulateSpriteRenderes();
        foreach (SpriteRenderer tSR in spriteRenderers)
        {
            tSR.sortingLayerName = tSLN;
        }
    }
    void Start () {
        SetSortOrder(0);
	}

    public void SetSortOrder(int v)
    {
        PopulateSpriteRenderes();
        foreach (SpriteRenderer tSR in spriteRenderers)
        {
            if (tSR.gameObject == this.gameObject)
            {
                tSR.sortingOrder = v;
                continue;
            }
            switch (tSR.gameObject.name)
            {
                case "back":
                    tSR.sortingOrder = v + 2;
                    break;
                case "face":
                default:
                    tSR.sortingOrder = v + 1;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    virtual public void OnMouseUpAsButton()
    {
        print(name);
    }
}


[System.Serializable]
public class Decorator
{
    public string type;
    public Vector3 loc;
    public bool flip = false;
    public float scale = 1f;
}
[System.Serializable]
public class CardDefinition
{
    public string face;
    public int rank;
    public List<Decorator> pips = new List<Decorator>();
}
