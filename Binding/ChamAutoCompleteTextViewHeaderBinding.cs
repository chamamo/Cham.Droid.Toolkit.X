using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cham.Droid.Toolkit;
using Cirrious.MvvmCross.Binding;

namespace Cham.Droid.ToolkitX.Binding
{
	public class ChamAutoCompleteTextViewHeaderBinding : ChamAutoCompleteTextViewHeaderBinding<ChamAutoCompleteTextView>
	{
		public ChamAutoCompleteTextViewHeaderBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
		}
	}

	public class ChamAutoCompleteTextViewHeaderBinding<T> : Cirrious.MvvmCross.Binding.Bindings.Target.MvxPropertyInfoTargetBinding<T>
		where T : ChamAutoCompleteTextView
    {
        public ChamAutoCompleteTextViewHeaderBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
        {
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWay; }
        }
    }
}