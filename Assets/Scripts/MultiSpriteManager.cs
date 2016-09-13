using UnityEngine;
using System.Collections;

/// <summary>
/// A simple class that handles holding multiple sprites for an object.
/// Right now only implemented on the 'car' enemy.
/// </summary>
public class MultiSpriteManager : MonoBehaviour {

    public Sprite[] skins = new Sprite[16];
    public SpriteRenderer sr;

    public void setSprite(int index)
    {
        sr.sprite = skins[index];
    }
}
