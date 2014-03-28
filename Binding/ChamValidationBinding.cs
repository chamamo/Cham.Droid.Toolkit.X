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
using Cirrious.MvvmCross.Binding.Bindings.Target;
using Cham.Droid.Toolkit;

namespace Cham.Droid.ToolkitX.Binding
{
    public abstract class ChamValidationBinding<T> : MvxPropertyInfoTargetBinding<T>, IChamValidationBinding where T : class
    {
        #region Constructor

        protected ChamValidationBinding(object target, PropertyInfo targetPropertyInfo) : base(target, targetPropertyInfo)
        {
        }

        #endregion

        #region Proprerties

        public IChamValidation ChamValidation
        {
            get { return View as IChamValidation; }
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }

        #endregion
    }
}