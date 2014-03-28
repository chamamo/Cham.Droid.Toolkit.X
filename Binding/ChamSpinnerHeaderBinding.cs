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
using Cirrious.MvvmCross.Binding;

namespace Cham.Droid.ToolkitX.Binding
{
    public class ChamSpinnerHeaderBinding : Cirrious.MvvmCross.Binding.Bindings.Target.MvxPropertyInfoTargetBinding<ChamSpinner>
    {
        public ChamSpinnerHeaderBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
        {
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWay; }
        }
    }
}