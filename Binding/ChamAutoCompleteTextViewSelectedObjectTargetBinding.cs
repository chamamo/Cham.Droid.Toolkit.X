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
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Bindings.Target;
using Cirrious.MvvmCross.Binding.Droid.Views;

namespace Cham.Droid.ToolkitX.Binding
{
	public class ChamAutoCompleteTextViewSelectedObjectTargetBinding: ChamAutoCompleteTextViewSelectedObjectTargetBinding<ChamAutoCompleteTextView>
	{
		public ChamAutoCompleteTextViewSelectedObjectTargetBinding(object target, PropertyInfo targetPropertyInfo)
			: base(target, targetPropertyInfo)
		{
		}
	}

	public class ChamAutoCompleteTextViewSelectedObjectTargetBinding<T>: MvxPropertyInfoTargetBinding<T>
		where T : ChamAutoCompleteTextView
    {
        private bool _subscribed;

        public ChamAutoCompleteTextViewSelectedObjectTargetBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
        {
            var autoComplete = View;
            if (autoComplete == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - autoComplete is null in ChamAutoCompleteTextViewSelectedObjectTargetBinding");
            }
        }

        private void AutoCompleteOnSelectedObjectChanged(object sender, EventArgs eventArgs)
        {
            FireValueChanged(View.SelectedObject);
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWayToSource; }
        }

        public override void SubscribeToEvents()
        {
            var autoComplete = View;
            if (autoComplete == null)
                return;
            _subscribed = true;
            autoComplete.SelectedObjectChanged += AutoCompleteOnSelectedObjectChanged;
        }

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (isDisposing)
            {
                var autoComplete = View;
                if (autoComplete != null && _subscribed)
                {
                    autoComplete.SelectedObjectChanged -= AutoCompleteOnSelectedObjectChanged;
                    _subscribed = false;
                }
            }
        }
    }
}