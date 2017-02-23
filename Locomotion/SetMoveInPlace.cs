// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Set move in place settings settings for VRTK.")]

	public class  SetMoveInPlace : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_MoveInPlace))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("If this is checked then the left controller touchpad will be enabled to move the play area.")]
		public FsmBool leftController;
		[Tooltip("If this is checked then the right controller touchpad will be enabled to move the play area.")]
		public FsmBool rightController;
		[Tooltip("Lower to decrease speed, raise to increase.")]
		public FsmFloat speedScale;
		[Tooltip("The max speed the user can move in game units. (If 0 or less, max speed is uncapped)")]
		public FsmFloat maxSpeed;
		[Tooltip("The speed in which the play area slows down to a complete stop when the user is no longer pressing the engage button. This deceleration effect can ease any motion sickness that may be suffered.")]
		public FsmFloat deceleration;
		[Tooltip("The speed in which the play area slows down to a complete stop when the user is falling.")]
		public FsmFloat fallingDeceleration;
		[Tooltip("The degree threshold that all tracked objects (controllers, headset) must be within to change direction when using the Smart Decoupling Direction Method.")]
		public FsmFloat smartDecoupleThreshold;
		[Tooltip("The maximum amount of movement required to register in the virtual world.  Decreasing this will increase acceleration, and vice versa.")]
		public FsmFloat sensitivity;
		[Tooltip("Select which button to hold to engage Move In Place.")]
		[ObjectType(typeof(VRTK.VRTK_ControllerEvents.ButtonAlias))]
		public FsmEnum engageButton; 
		[Tooltip("Select which trackables are used to determine movement.")]
		[ObjectType(typeof(VRTK.VRTK_MoveInPlace.ControlOptions))]
		public FsmEnum controlOptions;
		[Tooltip("How the user's movement direction will be determined.  The Gaze method tends to lead to the least motion sickness.  Smart decoupling is still a Work In Progress.")]
		[ObjectType(typeof(VRTK.VRTK_MoveInPlace.DirectionalMethod))]
		public FsmEnum directionMethod;




		public FsmBool everyFrame;

		VRTK.VRTK_MoveInPlace theScript;

		public override void Reset()
		{

			leftController = true;
			rightController = true;
			speedScale = null;
			maxSpeed = null;
			deceleration = null;
			fallingDeceleration = null;
			smartDecoupleThreshold = null;
			gameObject = null;
			engageButton = null;
			controlOptions = null;
			directionMethod = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_MoveInPlace>();

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

			theScript.leftController = leftController.Value;
			theScript.rightController = rightController.Value;
			theScript.speedScale = speedScale.Value;
			theScript.maxSpeed = maxSpeed.Value;
			theScript.deceleration = deceleration.Value;
			theScript.fallingDeceleration = fallingDeceleration.Value;
			theScript.smartDecoupleThreshold = smartDecoupleThreshold.Value;
			theScript.engageButton = (VRTK.VRTK_ControllerEvents.ButtonAlias)engageButton.Value;
			theScript.controlOptions = (VRTK.VRTK_MoveInPlace.ControlOptions)controlOptions.Value;
			theScript.directionMethod = (VRTK.VRTK_MoveInPlace.DirectionalMethod)directionMethod.Value;
		}

	}
}






