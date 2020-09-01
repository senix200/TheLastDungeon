using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }
    

    public override void Init()
    {
        base.Init();
        Health = base.health;
        distanceF = 2.0f;
    }
    public override void Update()
    {
        base.Update();
        if (distanceP < distanceF)
        {
            isHit = true;
            anim.SetBool("InCombat", true);
        }
        else if (distanceP > distanceF)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
        FaceToPlayer();
    }


    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }
        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            isHit = false;
            GameObject diamond = Instantiate(diamondPrefab, transform.position, UnityEngine.Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
    public void FaceToPlayer()
    {
        if (direction.x > 0 && anim.GetBool("InCombat") == true || direction.x < 0 && anim.GetBool("InCombat") == false)
        {
            //sprite.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (direction.x < 0 && anim.GetBool("InCombat") == true || direction.x > 0 && anim.GetBool("InCombat") == false)
        {
            //sprite.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
