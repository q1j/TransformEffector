﻿namespace TransformEffector
{
	class PositionRecoil : TransformCache, IHandleRecoil
	{
		public float Weight   = 0.3f;
		public float Friction = 0.3f;

		private Vec3RecoilTool tool_;

		void Start()
		{
			tool_ = new Vec3RecoilTool(TR.localPosition);
		}

		public void UpdateToRecoil()
		{
			if (IsDesable()) return;
			TR.localPosition = tool_.Recoil(TR.localPosition, Weight, Friction);
		}

		public bool IsDesable()
		{
			return (!enabled || 0f == Weight || 0f == Friction);
		}
	}
}
