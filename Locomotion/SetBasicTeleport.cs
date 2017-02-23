// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Set basic teleport settings for VRTK.")]

	public class  SetBasicTeleport : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_BasicTeleport))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("The fade blink speed can be changed on the basic teleport script to provide a customised teleport experience. Setting the speed to 0 will mean no fade blink effect is present.")]
		public FsmFloat blinkTransitionSpeed;
		[Tooltip("A range between 0 and 32 that determines how long the blink transition will stay blacked out depending on the distance being teleported. A value of 0 will not delay the teleport blink effect over any distance, a value of 32 will delay the teleport blink fade in even when the distance teleported is very close to the original position. This can be used to simulate time taking longer to pass the further a user teleports. A value of 16 provides a decent basis to simulate this to the user.")]
		[HasFloatSliderAttribute(0, 32f)]
		public FsmFloat distanceBlinkDelay;
		[Tooltip("If this is checked then the teleported location will be the position of the headset within the play area. If it is unchecked then the teleported location will always be the centre of the play area even if the headset position is not in the centre of the play area.")]
		public FsmBool headsetPositionCompensation;
		[Tooltip("The max distance the teleport destination can be outside the nav mesh to be considered valid. If a value of `0` is given then the nav mesh restrictions will be ignored.")]
		public FsmFloat navMeshLimitDistance;

		public FsmBool everyFrame;

		VRTK.VRTK_BasicTeleport theScript;

		public override void Reset()
		{

			gameObject = null;
			blinkTransitionSpeed = null;
			distanceBlinkDelay = null;
			headsetPositionCompensation = false;
			navMeshLimitDistance = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_BasicTeleport>();

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

			theScript.blinkTransitionSpeed = blinkTransitionSpeed.Value;
			theScript.distanceBlinkDelay = distanceBlinkDelay.Value;
			theScript.headsetPositionCompensation = headsetPositionCompensation.Value;
			theScript.navMeshLimitDistance = navMeshLimitDistance.Value;

		}

	}
}






