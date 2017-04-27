// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTKController")]
	[Tooltip(".")]

	public class  GetPointerUseObject : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.Examples.WhirlygigPlaymaker))]    
		public FsmOwnerDefault gameObject;

		[Tooltip(".")]
		public FsmGameObject touched;

		public FsmBool everyFrame;

		VRTK.Examples.WhirlygigPlaymaker theScript;

		public override void Reset()
		{

			touched = null;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.Examples.WhirlygigPlaymaker>();

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



		}

	}
}