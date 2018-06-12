using UnityEngine;
using System.Collections.Generic;

namespace TransformEffector
{
	public class TransformEffector : MonoBehaviour
	{
		public bool IsEnable;
		public Transform targetTransform;
		public EffectTarget[] Targets;
		protected List<IHandleRecoil>   recoiles_;
		protected List<ITransformEffect> effects_;

		void Start()
		{
			recoiles_ = new List<IHandleRecoil>();
			effects_  = new List<ITransformEffect>();
			GetEnableComponents();
			SetTragetTransform();
			InitEffectTragets();
		}

		void LateUpdate()
		{
			if (IsEnable)
			{
				RecoilUpdate();
				EffectUpdate();
			}
		}

		protected void GetEnableComponents()
		{
			ScaleRecoil    r1 = GetComponent<ScaleRecoil>();
			RotationRecoil r2 = GetComponent<RotationRecoil>();
			PositionRecoil r3 = GetComponent<PositionRecoil>();

			if (r1) recoiles_.Add(r1);
			if (r2) recoiles_.Add(r2);
			if (r3) recoiles_.Add(r3);

			ScaleEffect    e1 = GetComponent<ScaleEffect>();
			RotationEffect e2 = GetComponent<RotationEffect>();
			PositionEffect e3 = GetComponent<PositionEffect>();

			if (e1) effects_.Add(e1);
			if (e2) effects_.Add(e2);
			if (e3) effects_.Add(e3);
		}

		protected void SetTragetTransform()
		{
			if (!targetTransform) return;

			foreach (TransformCache r in recoiles_)
				r.SetTragetTransform(targetTransform);
			foreach (TransformCache e in effects_)
				e.SetTragetTransform(targetTransform);
		}

		protected void InitEffectTragets()
		{
			foreach (ITransformEffect e in effects_)
			{
				e.Prepare();
				foreach (EffectTarget t in Targets)
					if (t.TR) e.InitTarget(t);
			}
		}


		protected void RecoilUpdate()
		{
			foreach (IHandleRecoil r in recoiles_)
				r.UpdateToRecoil();
		}

		protected void EffectUpdate()
		{
			foreach (ITransformEffect e in effects_)
				e.UpdatePropertys();

			foreach (EffectTarget t in Targets)
				if (t.TR)
					foreach (ITransformEffect e in effects_)
						e.Operate(t);
		}
	}
}
