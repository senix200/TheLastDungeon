using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public GameObject acidEffectPrefab;
    
    public int Health { get; set; }


    public override void Init()
    {
        base.Init();
        Health = base.health;
        distanceF = 10.0f;
    }

    public override void Update()
    {
        base.Update();
        if (distanceP < distanceF)
        {
            anim.SetTrigger("Hit");
            isHit = true;
            anim.SetBool("InCombat", true); 
        }
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

    public void Attack()
    {
        
        Instantiate(acidEffectPrefab, transform.position, UnityEngine.Quaternion.identity);
    }
}
