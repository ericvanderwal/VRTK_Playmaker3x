// Eric Vander Wal
// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Helper")]
	[Tooltip("Gets info on the last collision for use with VRTK haptic strength.")]
	public class GetCollisionForceVRTK : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
     	 [Tooltip("Get the GameObject hit.")]
		public FsmGameObject gameObjectHit;

		[UIHint(UIHint.Variable)]
     	 [Tooltip("Get the relative velocity of the collision.")]
		public FsmVector3 relativeVelocity;

		[UIHint(UIHint.Variable)]
     	[Tooltip("Get the relative speed of the collision. Useful for controlling reactions. E.g., selecting an appropriate sound fx.")]
		public FsmFloat relativeSpeed;
		
		[ActionSection("Haptic Inputs")]
		
		[Tooltip("Set max collision force possible for haptics. Suggested value is 4000.")]
		public FsmFloat maxCollisionForce;
		
		[Tooltip("Set impact magnifier for haptic to change haptic outputs.")]
		public FsmFloat impactMagnifier;
		
		[ActionSection("Haptic Outputs")]
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Suggested haptic force based on collision data above.")]
		public FsmFloat hapticForce;
			
		public override void Reset()
		{
			gameObjectHit = null;
			relativeVelocity = null;
			relativeSpeed = null;
			maxCollisionForce = 4000f;
			impactMagnifier = 120f;
			hapticForce = null;
		}

		void StoreCollisionInfo()
		{
			if (Fsm.CollisionInfo == null)
			{
			    return;
			}
			
			gameObjectHit.Value = Fsm.CollisionInfo.gameObject;
			relativeSpeed.Value = Fsm.CollisionInfo.relativeVelocity.magnitude;
			
			// calculations
			var collisionForce = relativeSpeed.Value * impactMagnifier.Value;
			hapticForce.Value = collisionForce / maxCollisionForce.Value;

		}

		public override void OnEnter()
		{
			StoreCollisionInfo();
			
			Finish();
		}
	}
}