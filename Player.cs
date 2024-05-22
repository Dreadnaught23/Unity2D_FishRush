using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private HealthSystem playerHealthSystem;
    private PointSystem playerPointSystem;
    [SerializeField] private HealthBarUI playerHealthBar;
    [SerializeField] private SkorUI playerSkor;
    private BoxCollider2D boxCollider2D;

    PlayerInput playerInput;

    Vector3 moveDirection;
    private float moveSpeed = 5f;

    private float immuneDuration;
    private bool isImmune;

    private void Awake()
    {
        playerHealthSystem = new HealthSystem(50);
        playerHealthBar.Setup(playerHealthSystem);
        playerPointSystem = new PointSystem();
        playerSkor.Setup(playerPointSystem);

        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        playerInput = GetComponent<PlayerInput>();

        playerInput.onActionTriggered += PlayerInput_onActionTriggered;

        isImmune = false;
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext context)
    {
        if(context.action.name == "Movement")
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }

    private void Update()
    {
        if (isImmune)
        {
            immuneDuration -= Time.deltaTime;
            if (immuneDuration <= 0f) isImmune = false;

        }

        if(moveDirection.x > 0 )
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if(moveDirection.x < 0)
        {
            transform.eulerAngles = new Vector3();
        }
        

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        BoxCollider();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "fruit")
        {
            playerPointSystem.AddPoin(10);
            Destroy(collision.gameObject);
        }
    }

    private void BoxCollider()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center,boxCollider2D.size,0f,transform.position);
        if(raycastHit2D.collider.TryGetComponent(out Enemy enemy))
        {
            if(!isImmune)
            {
                playerHealthSystem.DamageAmount(10);
                isImmune = true;
                immuneDuration = .5f;
            }
        }
        
    }

    public Transform GetPlayerTF()
    {
        return this.transform;
    }
    
}
