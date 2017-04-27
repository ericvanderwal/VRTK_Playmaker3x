// Custom Action by DumbGameDev

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Pointer")]
	[Tooltip("Set Pointer Destination Marker Settings.")]

	public class  SetPointerDestinationMarkerSettings : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_Pointer))]    

		public FsmOwnerDefault gameObject;

		[TitleAttribute("Enable Teleport")]
		public FsmBool enTeleport;

		public FsmBool everyFrame;

		VRTK.VRTK_Pointer theScript;

		public override void Reset()
		{

			gameObject = null;
			enTeleport = true;
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

			theScript.enableTeleport = enTeleport.Value;
		}

	}
}