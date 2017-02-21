// Custom Action by DumbGameDev

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Set Straight Pointer Appearance.")]

	public class  SetStraightPointerAppearanceSettings : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_StraightPointerRenderer))]    

		public FsmOwnerDefault gameObject;

		[TitleAttribute("Max Length")]
		public FsmFloat maxLength;

		[TitleAttribute("Scale Factor")]
		public FsmFloat scFactor;

		[TitleAttribute("Cursor Match Target Rotation")]
		public FsmBool cuMatch;

		[TitleAttribute("Cursor Distance Rescale")]
		public FsmBool cuDistance;

		[TitleAttribute("Cursor Scale Multiplier")]
		public FsmFloat scMultiplier;

		public FsmBool everyFrame;


		VRTK.VRTK_StraightPointerRenderer theScript;

		public override void Reset()
		{

			gameObject = null;
			maxLength = null;
			scFactor = null;
			cuMatch = false;
			scMultiplier = null;
			cuDistance = false;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_StraightPointerRenderer>();

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

			theScript.maximumLength = maxLength.Value;
			theScript.scaleFactor = scFactor.Value;
			theScript.cursorMatchTargetRotation = cuMatch.Value;
			theScript.cursorScaleMultiplier = scMultiplier.Value;
			theScript.cursorDistanceRescale = cuDistance.Value;

		}

	}
}
	