using UnityEngine;
using System.Collections;

/// <summary>
/// A simple script that picks a random sprite from the array of tree sprites so that each tree is slightly different
/// </summary>
public class FoliageCreator : MonoBehaviour {

    public Sprite[] treeSprites = new Sprite[5];

	// Use this for initialization
	void Start () {
        SpriteRenderer renderer = this.GetComponent<SpriteRenderer>();
        int randomSprite = (int)(Random.Range(0, treeSprites.Length));
        renderer.sprite = treeSprites[randomSprite];
	}
}
