using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    public int diamonds;
    private Rigidbody2D rigid;
    [SerializeField]
    private float jumpForce = 5.0f;
    private bool resetJump = false;
    [SerializeField]
    private float speed = 5.0f;
    private bool grounded = false;
    private PlayerAnimation anim;
    private SpriteRenderer sprite;
    private SpriteRenderer swordArcSprite;
    private bool isCoroutineExecuting = false;
    public bool isGameOver = false;
    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimation>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        Health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            return;
        }
        if (!isGameOver)
        {
            Movement();
        }
        

        if (CrossPlatformInputManager.GetButtonDown("B_Button") && IsGrounded() == true)
        {
            anim.Attack();
        }
        if (isGameOver == true)
        {
            Health--;
            UIManager.Instance.UpdateLives(Health);
            anim.Death();
            StartCoroutine(ExecuteAfterTime(2));


        }
    }

    void Movement()
    {
        float move = CrossPlatformInputManager.GetAxis("Horizontal"); //Input.GetAxis("Horizontal");

        grounded = IsGrounded();
        if (move > 0)
        {
            sprite.flipX = false;
            swordArcSprite.flipX = false;
            swordArcSprite.flipY = false;

            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = 1.01f;
            swordArcSprite.transform.localPosition = newPos;
        }
        else if (move < 0)
        {
            sprite.flipX = true;
            swordArcSprite.flipX = true;
            swordArcSprite.flipY = true;

            Vector3 newPos = swordArcSprite.transform.localPosition;
            newPos.x = -1.01f;
            swordArcSprite.transform.localPosition = newPos;

        }

        if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("A_Button") && IsGrounded() == true)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
            anim.Jump(true);
        }
        rigid.velocity = new Vector2(move * speed, rigid.velocity.y);

        anim.Move(move);
    }

    bool IsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, 1 << 8);
        if (hitInfo.collider != null)
        {
            if (resetJump == false)
                anim.Jump(false);
                return true;            
        }
        return false;
    }
    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }
    public void Damage()
    {
        if (Health < 1)
        {
            return;
        }
        Health--;
        UIManager.Instance.UpdateLives(Health);

        if (Health < 1)
        {
            anim.Death();
            isGameOver = true;
            
        }
    }

    public void AddGems(int amount)
    {
        diamonds += amount;
        UIManager.Instance.UpdateGemCount(diamonds);
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Application.LoadLevel("Game");
        isCoroutineExecuting = false;
    }


}
