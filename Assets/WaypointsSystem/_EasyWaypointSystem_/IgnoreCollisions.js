#pragma strict

var ignoreCollisionWith: Collider[];

function Start () 
{
 if(ignoreCollisionWith.Length >0 && collider)
  for( var i = 0; i< ignoreCollisionWith.Length; i++)
     Physics.IgnoreCollision(collider, ignoreCollisionWith[i]);

}

