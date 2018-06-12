using UnityEngine;
namespace TransformEffector
{
	public class RotationRecoil : TransformCache, IHandleRecoil
	{
		public float Weight = 0.03f;
		private Quaternion originalRot_;

		void Start()
		{
			if (IsDesable()) return;
			originalRot_ = TR.localRotation;
		}

		public void UpdateToRecoil()
		{
			if (IsDesable()) return;
			TR.localRotation = Quaternion.SlerpUnclamped(TR.localRotation, originalRot_, Weight);
		}

		public bool IsDesable()
		{
			return (!enabled || 0 == Weight);
		}
	}
}
