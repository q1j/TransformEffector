using UnityEngine;
using System.Collections.Generic;

namespace TransformEffector
{
	public class TransformEffector : MonoBehaviour
	{
		public EffectTarget[] Targets;

		private List<IHandleRecoil>    recoiles_;
		private List<ITransformEffect> effects_;

		void Start()
		{
			recoiles_ = new List<IHandleRecoil>();
			effects_  = new List<ITransformEffect>();
			GetEnableComponents();
			InitEffectTragets();
		}

		void LateUpdate()
		{
			RecoilUpdate();
			EffectUpdate();
		}

		private void InitEffectTragets()
		{
			foreach (ITransformEffect e in effects_)
			{
				e.Prepare();
				foreach (EffectTarget t in Targets)
				{
					if (!t.TR) continue;
					e.InitTarget(t);
				}
			}
		}

		private void GetEnableComponents()
		{
			ScaleRecoil    r1 = GetEnableComponent<ScaleRecoil>();
			RotationRecoil r2 = GetEnableComponent<RotationRecoil>();
			PositionRecoil r3 = GetEnableComponent<PositionRecoil>();

			if (r1) recoiles_.Add(r1);
			if (r2) recoiles_.Add(r2);
			if (r3) recoiles_.Add(r3);
		
			ScaleEffect    e1 = GetEnableComponent<ScaleEffect>();
			RotationEffect e2 = GetEnableComponent<RotationEffect>();
			PositionEffect e3 = GetEnableComponent<PositionEffect>();

			if (e1) effects_.Add(e1);
			if (e2) effects_.Add(e2);
			if (e3) effects_.Add(e3);
		}

		private T GetEnableComponent<T>()
		{
			T[] components = gameObject.GetComponents<T>();
			foreach (T c in components)
			{
				TransformCache tc = c as TransformCache;
				if (tc && tc.enabled) return c;
			}
			return default(T);
		}

		private void RecoilUpdate()
		{
			foreach (IHandleRecoil r in recoiles_)
			{ r.UpdateToRecoil(); }
		}

		private void EffectUpdate()
		{
			foreach (ITransformEffect e in effects_)
			{ e.UpdatePropertys(); }

			foreach (EffectTarget t in Targets)
			{
				if (!t.TR) continue;
				foreach (ITransformEffect e in effects_)
				{ e.Operate(t); }
			}
		}
	}
}
