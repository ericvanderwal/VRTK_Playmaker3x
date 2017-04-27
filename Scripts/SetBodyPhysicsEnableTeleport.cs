// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Locomotion")]
	[Tooltip("Enable teleport settings for Body Physics for VRTK.")]

	public class  SetBodyPhysicsEnableTeleport : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_BodyPhysics))]    
		public FsmOwnerDefault gameObject;

		public FsmBool enableTeleport;

		public FsmBool everyFrame;

		VRTK.VRTK_BodyPhysics theScript;

		public override void Reset()
		{
			enableTeleport = true;
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

			theScript.enableTeleport = enableTeleport.Value;

		}

	}
}
