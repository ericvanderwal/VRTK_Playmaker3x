// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Locomotion")]
	[Tooltip("Set body physics body collisions settings for VRTK.")]

	public class  SetBodyPhysicsBodyCollisionSettings : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_BodyPhysics))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("If checked then the body collider and rigidbody will be used to check for rigidbody collisions.")]
		public FsmBool enableBodyCollisions;
		[Tooltip("If this is checked then any items that are grabbed with the controller will not collide with the body collider. This is very useful if the user is required to grab and wield objects because if the collider was active they would bounce off the collider.")]
		public FsmBool ignoreGrabbedCollisions;
		[Tooltip("The collider which is created for the user is set at a height from the user's headset position. If the collider is required to be lower to allow for room between the play area collider and the headset then this offset value will shorten the height of the generated collider.")]
		public FsmFloat headsetYOffset;
		[Tooltip("The amount of movement of the headset between the headset's current position and the current standing position to determine if the user is walking in play space and to ignore the body physics collisions if the movement delta is above this threshold.")]
		public FsmFloat movementThreshold;
		[Tooltip("The maximum number of samples to collect of headset position before determining if the current standing position within the play space has changed.")]
		public FsmInt standingHistorySamples;
		[Tooltip("The `y` distance between the headset and the object being leaned over, if object being leaned over is taller than this threshold then the current standing position won't be updated.")]
		public FsmFloat leanYThreshold;

		public FsmBool everyFrame;

		VRTK.VRTK_BodyPhysics theScript;

		public override void Reset()
		{
			enableBodyCollisions = false;
			ignoreGrabbedCollisions = false;
			headsetYOffset = null;
			movementThreshold = null;
			standingHistorySamples = null;
			leanYThreshold = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_BodyPhysics>();

			if (!everyFrame.Value)
			{
				MakeItSo();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}


		void MakeItSo()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			theScript.enableBodyCollisions = enableBodyCollisions.Value;
			theScript.ignoreGrabbedCollisions = ignoreGrabbedCollisions.Value;
			theScript.enableBodyCollisions = enableBodyCollisions.Value;
			theScript.ignoreGrabbedCollisions = ignoreGrabbedCollisions.Value;
			theScript.headsetYOffset = headsetYOffset.Value;
			theScript.movementThreshold = movementThreshold.Value;
			theScript.standingHistorySamples = standingHistorySamples.Value;
			theScript.leanYThreshold = leanYThreshold.Value;
					}

	}
}
	