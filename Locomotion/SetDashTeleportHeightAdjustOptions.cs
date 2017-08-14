// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using VRTK;

#if VRTK_VERSION_3_2_0_OR_NEWER

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK Locomotion")]
	[Tooltip("Set basic teleport settings for VRTK.")]

	public class  SetDashTeleportHeightAdjustOptions : FsmStateAction

	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_DashTeleport))]    
		public FsmOwnerDefault gameObject;

		[Tooltip("The fixed time it takes to dash to a new position.")]
		public FsmFloat normalLerpTime = 0.1f; // 100ms for every dash above minDistanceForNormalLerp
		[Tooltip("The minimum speed for dashing in meters per second.")]
		public FsmFloat minSpeedMps = 50.0f; // clamped to minimum speed 50m/s to avoid sickness
		[Tooltip("The Offset of the CapsuleCast above the camera.")]
		public FsmFloat capsuleTopOffset = 0.2f;
		[Tooltip("The Offset of the CapsuleCast below the camera.")]
		public FsmFloat capsuleBottomOffset = 0.5f;
		[Tooltip("The radius of the CapsuleCast.")]
		public FsmFloat capsuleRadius = 0.5f;
		[Tooltip("The layers to ignore.")]
		[UIHint(UIHint.Layer)]
		public FsmInt layersToIgnore;

		public FsmBool everyFrame;

		VRTK.VRTK_DashTeleport theScript;

		public override void Reset()
		{

			gameObject = null;
			layersToIgnore = null;
			normalLerpTime = null;
			minSpeedMps = null;
			capsuleTopOffset = null;
			capsuleBottomOffset = null;
			capsuleRadius = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);

			theScript = go.GetComponent<VRTK.VRTK_DashTeleport>();

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

			theScript.customRaycast.layersToIgnore = (LayerMask)layersToIgnore.Value;
			theScript.normalLerpTime = normalLerpTime.Value;
			theScript.minSpeedMps =	minSpeedMps.Value;
			theScript.capsuleTopOffset = capsuleTopOffset.Value;
			theScript.capsuleBottomOffset =	capsuleBottomOffset.Value;
			theScript.capsuleRadius = capsuleRadius.Value;

		}

	}
}

#else

namespace HutongGames.PlayMaker.Actions
{
[ActionCategory("VRTK Locomotion")]
[Tooltip("Set basic teleport settings for VRTK.")]

public class  SetDashTeleportHeightAdjustOptions : FsmStateAction

{
[RequiredField]
[CheckForComponent(typeof(VRTK.VRTK_DashTeleport))]    
public FsmOwnerDefault gameObject;

[Tooltip("The fixed time it takes to dash to a new position.")]
public FsmFloat normalLerpTime = 0.1f; // 100ms for every dash above minDistanceForNormalLerp
[Tooltip("The minimum speed for dashing in meters per second.")]
public FsmFloat minSpeedMps = 50.0f; // clamped to minimum speed 50m/s to avoid sickness
[Tooltip("The Offset of the CapsuleCast above the camera.")]
public FsmFloat capsuleTopOffset = 0.2f;
[Tooltip("The Offset of the CapsuleCast below the camera.")]
public FsmFloat capsuleBottomOffset = 0.5f;
[Tooltip("The radius of the CapsuleCast.")]
public FsmFloat capsuleRadius = 0.5f;
[Tooltip("The layers to ignore.")]
[UIHint(UIHint.Layer)]
public FsmInt layersToIgnore;

public FsmBool everyFrame;

VRTK.VRTK_DashTeleport theScript;

public override void Reset()
{

gameObject = null;
layersToIgnore = null;
normalLerpTime = null;
minSpeedMps = null;
capsuleTopOffset = null;
capsuleBottomOffset = null;
capsuleRadius = null;
everyFrame = false;
}

public override void OnEnter()
{
var go = Fsm.GetOwnerDefaultTarget(gameObject);

theScript = go.GetComponent<VRTK.VRTK_DashTeleport>();

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

theScript.layersToIgnore = (LayerMask)layersToIgnore.Value;
theScript.normalLerpTime = normalLerpTime.Value;
theScript.minSpeedMps =	minSpeedMps.Value;
theScript.capsuleTopOffset = capsuleTopOffset.Value;
theScript.capsuleBottomOffset =	capsuleBottomOffset.Value;
theScript.capsuleRadius = capsuleRadius.Value;

}

}
}

#endif