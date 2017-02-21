// Custom Action by DumbGameDev

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Set Straight Pointer Custom Appearance.")]

	public class  StraightPointerCustomAppearance : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_StraightPointerRenderer))]    

		public FsmOwnerDefault gameObject;

		[TitleAttribute("Custom Tracer")]
		public FsmGameObject tracer;

		[TitleAttribute("Custom Cursor")]
		public FsmGameObject cursor;

		public FsmBool everyFrame;

	


		VRTK.VRTK_StraightPointerRenderer theScript;

		public override void Reset()
		{

			gameObject = null;
			cursor = null;
			tracer = null;
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

			theScript.customCursor = cursor.Value;
			theScript.customTracer = tracer.Value;

		}

	}
}
