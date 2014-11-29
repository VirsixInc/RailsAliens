using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//hitpoints - the number of damage points an enemy can take before it is destroy
	public int m_hitpoints;




	//we need to keep track of enemy states - attacking, moving, defending, dying, spawning - but this may be specific to each enemy type


	

	public virtual void OnDeath ()
	{
		//play death animation
		//disable game object when animation is finished
	}

	//when a player shoots and hits an enemy - this function is called
	public virtual void DoDamage (int damage)
	{
		//subtract damage from hitpoints
		m_hitpoints -= damage;
		//check if hitpoints less than or equal zero
		if (m_hitpoints <= 0)
			OnDeath ();
		//play Enemy squib/bleed FX
		//play enemy recoil animation
	}

}
