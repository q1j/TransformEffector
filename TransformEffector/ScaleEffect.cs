using UnityEngine;
namespace TransformEffector
{
	public class ScaleEffect : TransformCache, ITransformEffect
	{
		public bool KeepLength = false;

		private Vector3 orgHandleRatio_;
		private Vector3 effectScaleRatio_;

		public void Prepare()
		{
			orgHandleRatio_ = V3Ratio(TR.localScale);
			UpdatePropertys();
		}

		public void UpdatePropertys()
		{
			if (IsDesable()) return;
			effectScaleRatio_ = Vector3.Scale(orgHandleRatio_, TR.localScale);
		}

		public void InitTarget(EffectTarget target)
		{
			target.KeepScaleLength = target.TR.localScale.x + target.TR.localScale.y + target.TR.localScale.z;
			target.OrgLocScale     = target.TR.localScale;
			target.DiffHandleRot   = target.TR.rotation * Quaternion.Inverse(TR.rotation);

			Vector3 s = GetEffectedScale(target);
			s.x = target.OrgLocScale.x / s.x;
			s.y = target.OrgLocScale.y / s.y;
			s.z = target.OrgLocScale.z / s.z;
			target.CorrectScaleRatio = s;
		}

		private Vector3 GetEffectedScale(EffectTarget target)
		{
			Vector3 s = Vector3.Scale(effectScaleRatio_, target.OrgLocScale);
			return V3Abs(target.DiffHandleRot * s);
		}

		public void Operate(EffectTarget target)
		{
			if (IsDesable() || 0f == target.ScaleWeight) return;

			Vector3 s = GetEffectedScale(target);
			s = Vector3.Scale(s,target.CorrectScaleRatio);
			s = Vector3.Lerp(target.OrgLocScale, s, target.ScaleWeight);

			if (KeepLength) s *= target.KeepScaleLength / (s.x + s.y + s.z);
			target.TR.localScale = s;
		}

		public bool IsDesable()
		{
			return !enabled;
		}

		private Vector3 V3Ratio(Vector3 v)
		{
			Vector3 r;
			r.x = 1f / v.x;
			r.y = 1f / v.y;
			r.z = 1f / v.z;
			return r;
		}

		private Vector3 V3Abs(Vector3 v)
		{
			Vector3 r;
			r.x = Mathf.Abs(v.x);
			r.y = Mathf.Abs(v.y);
			r.z = Mathf.Abs(v.z);
			return r;
		}
	}
}
