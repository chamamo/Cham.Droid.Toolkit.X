using System;
using Cham.Droid.Toolkit;
using Cirrious.MvvmCross.Binding;
using System.Reflection;

namespace Cham.Droid.ToolkitX.Binding
{
	public class ChamEditTextHeaderBinding : Cirrious.MvvmCross.Binding.Bindings.Target.MvxPropertyInfoTargetBinding<ChamEditText>
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

