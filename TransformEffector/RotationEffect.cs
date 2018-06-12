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
			if (IsDesable()) return;
			rotDiff_ = TR.rotation * inverseOrgRot_;
		}

		public void Operate(EffectTarget target)
		{
			if (IsDesable() || 0f == target.RotationWeight) return;

			Quaternion targetRot = rotDiff_ * target.OrgRot;
			target.TR.rotation = Quaternion.SlerpUnclamped(target.TR.rotation, targetRot, target.RotationWeight);
		}

		public void InitTarget(EffectTarget target)
		{
			target.OrgRot = target.TR.rotation;
		}

		public bool IsDesable()
		{
			return !enabled;
		}
	}
}