 //Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Interaction")]
	[Tooltip("Set snap drop zone properties for VRTK.")]

	public class  SetSnapDropZone : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_SnapDropZone))]    
		public FsmOwnerDefault gameObject;
		
		
		public FsmGameObject highlightObjectPrefab;
		
		[ObjectType(typeof(VRTK_SnapDropZone.SnapTypes))]
		public FsmEnum snapType;
		
		public FsmFloat snapDuration;
		
		public FsmBool applyScaling;
		
		public FsmColor highlightColor;
		
		public FsmBool highlightAlwaysActive;
		
		[UIHint(UIHint.Script)]
		public FsmObject validObjectListPolicy;

		public FsmBool everyFrame;

		VRTK.VRTK_SnapDropZone theScript;

		public override void Reset()
		{

			highlightObjectPrefab = null;
			highlightColor = Color.white;
			snapDuration = null;
			highlightAlwaysActive = false;
			validObjectListPolicy = null;
			applyScaling = false;
			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_SnapDropZone>();

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

			theScript.highlightObjectPrefab = highlightObjectPrefab.Value;
			theScript.snapType = (VRTK_SnapDropZone.SnapTypes)snapType.Value;
			theScript.snapDuration = snapDuration.Value;
			theScript.applyScalingOnSnap = applyScaling.Value;
			theScript.highlightColor = highlightColor.Value;
			theScript.highlightAlwaysActive = highlightAlwaysActive.Value;
			//theScript.validObjectListPolicy = (VRTK.VRTK_PolicyList)validObjectListPolicy.Value;
		}

	}
}