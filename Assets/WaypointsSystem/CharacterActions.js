//----------------------------------------------------------------------------------------------
// Simple example script to handle character animation
// Please update it or create new according to requirements of your project
//----------------------------------------------------------------------------------------------


#pragma strict


var waypointMover: WaypointMover;

var idleAnimation: AnimationClip;
var moveAnimation: AnimationClip;
var jumpAnimation: AnimationClip;
var jumpForce: Vector3;

private var inSpecialAction: boolean = false;

//----------------------------------------------------------------------------------
function Update () 
{
  if(!inSpecialAction)
     if (waypointMover.isMoving()) Move(); else Idle();
   else
     if (!animation.isPlaying) inSpecialAction = false;
}

//----------------------------------------------------------------------------------
function Idle () 
{
 if (!animation.isPlaying || animation.IsPlaying(moveAnimation.name)) animation.Play(idleAnimation.name);
}



function Move () 
{
 if (animation.isPlaying) animation.Play(moveAnimation.name);
}



function Jump() 
{
 inSpecialAction = true;
 animation.Play(jumpAnimation.name);
 rigidbody.AddRelativeForce(jumpForce, ForceMode.Impulse);
}
//----------------------------------------------------------------------------------