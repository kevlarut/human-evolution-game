using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteWithSortedOrder : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    var spriteRenderer = GetComponent<SpriteRenderer>();
	    var halfOfHeightInGameUnits = spriteRenderer.sprite.bounds.size.y / 2;
        var bottomEdge = transform.position.y - halfOfHeightInGameUnits;
	    var sortingOrder = Mathf.RoundToInt(bottomEdge*100f)*-1;

	    spriteRenderer.sortingOrder = sortingOrder;
        foreach (var childSpriteRenderer in GetComponentsInChildren<SpriteRenderer>())
        {
            childSpriteRenderer.sortingOrder = sortingOrder + 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
