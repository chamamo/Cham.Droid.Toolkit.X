using System;
using Cham.Droid.Toolkit;
using Cirrious.MvvmCross.Binding;
using System.Reflection;
using Cirrious.MvvmCross.Binding.Bindings.Target;

namespace Cham.Droid.ToolkitX.Binding
{
	public class ChamEditTextHeaderBinding : ChamEditTextHeaderBinding<ChamEditText>
	{
		public ChamEditTextHeaderBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
		}
	}

	public class ChamEditTextHeaderBinding<T> : MvxPropertyInfoTargetBinding<T>
		where T : ChamEditText
	{
        public ChamEditTextHeaderBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
		{
		}

		public override MvxBindingMode DefaultMode
		{
			get { return MvxBindingMode.OneWay; }
		}
	}
}

