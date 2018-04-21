using UnityEngine;
namespace TransformEffector
{
	public class RotationEffect : TransformCache, ITransformEffect
	{
		private Quaternion rotDiff_;
		private Quaternion inverseOrgRot_;

		void Start()
		{
		}

		public void Prepare()
		{
			inverseOrgRot_ = Quaternion.Inverse(TR.rotation);
		}

		public void UpdatePropertys()
		{
			rotDiff_ = inverseOrgRot_ * TR.rotation;
		}

		public void Operate(EffectTarget target)
		{
			if (0f == target.RotationWeight) return;

			Quaternion targetRot = rotDiff_ * target.OrgRot;
			target.TR.rotation = Quaternion.SlerpUnclamped(target.TR.rotation, targetRot, target.RotationWeight);
		}

		public void InitTarget(EffectTarget target)
		{
			target.OrgRot = target.TR.rotation;
		}
	}
}