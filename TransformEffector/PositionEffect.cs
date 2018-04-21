using UnityEngine;
namespace TransformEffector
{
	public class PositionEffect : TransformCache, ITransformEffect
	{
		private Vector3 orgLocPos_;
		private Vector3 locPosDiff_;

		void Start()
		{
		}

		public void Prepare()
		{
			orgLocPos_  = TR.localPosition;
			locPosDiff_ = orgLocPos_;
		}

		public void UpdatePropertys()
		{
			locPosDiff_ = TR.localPosition - orgLocPos_;
		}

		public void Operate(EffectTarget target)
		{
			Vector3 v = locPosDiff_ * target.PositionWeight;
			target.TR.localPosition = target.OrgLocPos +
				target.TR.InverseTransformDirection(TR.TransformDirection(v));
		}

		public void InitTarget(EffectTarget target)
		{
			target.OrgLocPos = target.TR.localPosition;
		}
	}
}
