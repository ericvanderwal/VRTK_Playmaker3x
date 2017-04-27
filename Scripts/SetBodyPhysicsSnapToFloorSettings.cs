// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Locomotion")]
	[Tooltip("Enable Snap to Floor Settings for Body Physics for VRTK.")]

	public class  SetBodyPhysicsSnapToFloorSettings : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_BodyPhysics))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("The layers to ignore when raycasting to find floors.")]
		[UIHint(UIHint.Layer)]
		public FsmInt layersToIgnore;
		[ObjectType(typeof(VRTK.VRTK_BodyPhysics.FallingRestrictors))]
		[Tooltip("A check to see if the drop to nearest floor should take place. If the selected restrictor is still over the current floor then the drop to nearest floor will not occur. Works well for being able to lean over ledges and look down. Only works for falling down not teleporting up.")]
		public FsmEnum fallRestriction;
		[Tooltip("When the `y` distance between the floor and the headset exceeds this distance and `Enable Body Collisions` is true then the rigidbody gravity will be used instead of teleport to drop to nearest floor.")]
		public FsmFloat gravityFallYThreshold;
		[Tooltip("The `y` distance between the floor and the headset that must change before a fade transition is initiated. If the new user location is at a higher distance than the threshold then the headset blink transition will activate on teleport. If the new user location is within the threshold then no blink transition will happen, which is useful for walking up slopes, meshes and terrains to prevent constant blinking.")]
		public FsmFloat blinkYThreshold;
		[Tooltip("The amount the `y` position needs to change by between the current floor `y` position and the previous floor `y` position before a change in floor height is considered to have occurred. A higher value here will mean that a `Drop To Floor` will be less likely to happen if the `y` of the floor beneath the user hasn't changed as much as the given threshold.")]
		public FsmFloat floorHeightTolerance;

		public FsmBool everyFrame;

		VRTK.VRTK_BodyPhysics theScript;

		public override void Reset()
		{
			layersToIgnore = null;
			fallRestriction = null;
			gravityFallYThreshold = null;
			blinkYThreshold = null;
			floorHeightTolerance = null;
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

			theScript.layersToIgnore = (LayerMask)layersToIgnore.Value;
			theScript.fallRestriction = (VRTK.VRTK_BodyPhysics.FallingRestrictors)fallRestriction.Value;
			theScript.gravityFallYThreshold = gravityFallYThreshold.Value;
			theScript.blinkYThreshold = blinkYThreshold.Value;
			theScript.floorHeightTolerance = floorHeightTolerance.Value;
		}

	}
}
