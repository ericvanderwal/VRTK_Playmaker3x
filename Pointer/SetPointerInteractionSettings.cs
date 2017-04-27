// Custom Action by DumbGameDev

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Pointer")]
	[Tooltip("Set Pointer Interaction Settings.")]

	public class  SetPointerInteractionSettings : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_Pointer))]    

		public FsmOwnerDefault gameObject;

		[TitleAttribute("Interact with Object")]
		public FsmBool grabTip;

		[TitleAttribute("Grab to Pointer Tip")]
		public FsmBool interObj;

		public FsmBool everyFrame;

		VRTK.VRTK_Pointer theScript;

		public override void Reset()
		{

			gameObject = null;
			grabTip = null;
			interObj = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_Pointer>();

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

			theScript.interactWithObjects = interObj.Value;
			theScript.grabToPointerTip = grabTip.Value;

		}

	}
}

