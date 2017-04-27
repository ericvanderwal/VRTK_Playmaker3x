// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Interaction")]
	[Tooltip("Get Game Object entered the SnapZone.")]
	
	public class  ObjectEnteredSnapDropZone : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_SnapDropZone))]    
		public FsmOwnerDefault gameObject;
		
		[TitleAttribute("Entered Game Object")]
		public FsmGameObject snapZoneObject;
		
		private	VRTK.UnityEventHelper.VRTK_SnapDropZone_UnityEvents snapEvents;
		
		public override void Reset()
		{
			
			gameObject = null;
			snapZoneObject = null;
		}
		
		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			
			snapEvents = go.GetComponent<VRTK.UnityEventHelper.VRTK_SnapDropZone_UnityEvents>();
			if (snapEvents == null)
			{
				snapEvents = go.AddComponent<VRTK.UnityEventHelper.VRTK_SnapDropZone_UnityEvents>();
			}
			
			//snapEvents.OnValueChanged.AddListener(HandleChange);
			snapEvents.OnObjectEnteredSnapDropZone.AddListener(ObjectSnapped);
			
		}
		
		private void ObjectSnapped(object sender, SnapDropZoneEventArgs e)
		{
			snapZoneObject.Value = e.snappedObject;
			
		}
		
	}
	
}
