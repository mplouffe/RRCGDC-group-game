using UnityEngine;
using System.Collections;

public class FoliageCreator : MonoBehaviour {

    public Sprite[] treeSprites = new Sprite[5];

	// Use this for initialization
	void Start () {
        SpriteRenderer renderer = this.GetComponent<SpriteRenderer>();
        int randomSprite = (int)(Random.Range(0, treeSprites.Length));
        renderer.sprite = treeSprites[randomSprite];
	}
}
