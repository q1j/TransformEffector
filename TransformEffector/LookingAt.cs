using UnityEngine;

namespace TransformEffector
{
	public class LookingAt : EffectorHandle
	{
		public Transform Target;
		public bool IsRotDelay = true;
		public float MoveSeed = 0.2f;
		private float lookWeight_ = 0f;
		private Vector3 beforMvVec_;
		private Vector3 targetMvVec_;

		void Start()
		{
			beforMvVec_ = Vector3.zero;
		}

		void Update()
		{
			if (Target) LookAt();
		}

		public void SwitchTarget(Transform nextTarget)
		{
			Target = nextTarget;
			lookWeight_ = WeightMin;
		}

		protected void LookAt()
		{
			targetMvVec_ = Target.position - TR.position;
			Quaternion bfLocalRot = TR.localRotation;

			if (beforMvVec_ != targetMvVec_)
			{
				beforMvVec_ = targetMvVec_;
				if (IsRotDelay) lookWeight_ = WeightMin;
			}

			if (WeightMax > lookWeight_)
			{
				lookWeight_ += MoveSeed * Time.deltaTime;
				if (WeightMax < lookWeight_) lookWeight_ = WeightMax;
			}

			if (WeightMax == lookWeight_ && bfLocalRot == TR.localRotation)
				return;

			TR.rotation = Quaternion.LookRotation(targetMvVec_);
			TR.localRotation = LimitedRotation(Quaternion.SlerpUnclamped(bfLocalRot, TR.localRotation, lookWeight_));
		}
	}
}
