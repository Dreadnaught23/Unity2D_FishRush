using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject playerGO;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    [SerializeField] private float moveSpeed;
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (playerGO.gameObject != null)
        {

            Vector2 distance = (playerGO.transform.position - transform.position).normalized;
            transform.Translate(distance * moveSpeed * Time.deltaTime);

            if (distance.x > 0)
            {
                spriteRenderer.flipX = true;
                boxCollider2D.offset = new Vector2(-boxCollider2D.offset.x, -boxCollider2D.offset.y);
                
            }
            else if (distance.x < 0)
            {
                spriteRenderer.flipX = false;
                boxCollider2D.offset = new Vector2(boxCollider2D.offset.x, boxCollider2D.offset.y);
            }
        }
        
    }

    
}
