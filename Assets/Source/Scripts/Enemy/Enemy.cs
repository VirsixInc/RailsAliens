using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	
	//There are two types of directly harmful enemies - melee and ranged
	//both of their attacks are trigger DoDamage only when a certain Animation State is reached

	//hitpoints - the number of damage points an enemy can take before it is destroy
	public int hitpoints;

	//enemyEvents - list of the events that the enemy does which are all based in animation
	public Animation animationSequence;
	
	//we need to keep track of enemy states - attacking, moving, defending, dying, spawning - but this may be specific to each enemy type
	
	public virtual void Attack()
	{
		//must be specific to enemy
	}

	public virtual void OnDeath ()
	{
		//play death animation
		//disable game object when animation is finished
		gameObject.SetActive (false); 
	}

	//when a player shoots and hits an enemy - this function is called
	public virtual void DoDamage (int damage)
	{
		//subtract damage from hitpoints
		hitpoints -= damage;
		//check if hitpoints less than or equal zero
		if (hitpoints <= 0)
			OnDeath ();
		//play Enemy squib/bleed FX
		//play enemy recoil animation

	}

}
