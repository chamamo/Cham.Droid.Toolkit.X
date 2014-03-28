using System;
using Cham.Droid.Toolkit;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.ExtensionMethods;
using System.Reflection;

namespace Cham.Droid.ToolkitX.Binding
{
    public class ChamDatePickerBinding : ChamValidationBinding<ChamDatePicker>
    {
        #region Constructor

        public ChamDatePickerBinding (object target, PropertyInfo targetPropertyInfo) : base (target, targetPropertyInfo)
		{
		}

        #endregion

        #region Properties

		public override Type TargetType
		{
			get { return typeof(DateTime?); }
		}

        #endregion

        #region methods

        public override void SubscribeToEvents ()
		{
			View.ValueChanged += DatePickerOnValueChanged;
		}

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (isDisposing)
            {
                if (View != null)
                {
                    View.ValueChanged -= DatePickerOnValueChanged;
                }
            }
        }

        #endregion

        #region Events

        private void DatePickerOnValueChanged (object sender, EventArgs args)
		{
			FireValueChanged (View.Value);
		}

        #endregion
	}
}

