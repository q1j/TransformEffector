using UnityEngine;
namespace TransformEffector
{
	public class RotationRecoil : TransformCache, IHandleRecoil
	{
		public float weight = 0.03f;
		private Quaternion originalRot_;

		void Start()
		{
			originalRot_ = TR.localRotation;
		}

		public void UpdateToRecoil()
		{
			if (0f == weight) return;
			TR.localRotation = Quaternion.SlerpUnclamped(TR.localRotation, originalRot_, weight);
		}
	}
}
