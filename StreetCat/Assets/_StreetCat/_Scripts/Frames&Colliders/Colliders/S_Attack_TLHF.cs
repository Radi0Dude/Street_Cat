using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Attack_TLHF : MonoBehaviour, S_IHitBoxResponder_TLHF
{
    public int damage;
    public S_HitBox_TF hitbox;
    

    public void attack()
    {
        
    }

   

	void S_IHitBoxResponder_TLHF.collisionWith(Collider collider)
	{
		 S_HurtBox_TLHF hurtbox = collider.GetComponent<S_HurtBox_TLHF>();
        hurtbox?.getHitBy(damage);
	}
}
