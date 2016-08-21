using UnityEngine;
using System.Collections;

public class MultiSpriteManager : MonoBehaviour {

    public Sprite[] skins = new Sprite[16];
    public SpriteRenderer sr;

    public void setSprite(int index)
    {
        sr.sprite = skins[index];
    }
}
