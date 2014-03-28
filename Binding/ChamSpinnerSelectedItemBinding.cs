using System;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.Droid.Target;
using Android.Widget;
using Cirrious.CrossCore.Platform;
using System.Collections;
using System.Reflection;
using Cham.Droid.Toolkit;

namespace Cham.Droid.ToolkitX.Binding
{
    public class ChamSpinnerSelectedItemBinding : MvxAndroidTargetBinding, IChamValidationBinding
    {
        #region Fields

        private object _currentValue;
		private bool _subscribed;
        
        #endregion

        #region Constructor

        public ChamSpinnerSelectedItemBinding (ChamSpinner spinner) : base (spinner)
		{
		}

        #endregion

        #region Properties

        public override MvxBindingMode DefaultMode
		{
			get
			{
				return MvxBindingMode.TwoWay;
			}
		}

		protected ChamSpinner Spinner
		{
			get
			{
				return (ChamSpinner)base.Target;
			}
		}

        public IChamValidation ChamValidation
        {
            get { return Spinner; }
        }

		public override Type TargetType
		{
			get
			{
				return typeof(object);
			}
		}

        #endregion

        #region Methods

        protected override void SetValueImpl (object target, object value)
		{
			var spinner = (ChamSpinner)target;

			if (value == null)
			{
				MvxBindingTrace.Warning ("Null values not permitted in spinner SelectedItem binding currently");
				return;
			}

			if (!value.Equals (_currentValue))
			{
				var index = spinner.Adapter.GetPosition (value);
				if (index < 0)
				{
					MvxBindingTrace.Trace (MvxTraceLevel.Warning, "Value not found for spinner {0}", value.ToString ());
					return;
				}
				_currentValue = value;
				spinner.Spinner.SetSelection (index);
			}
		}

		public override void SubscribeToEvents ()
		{
			var spinner = Spinner;
			if (spinner == null)
				return;

			spinner.ItemSelected += SpinnerItemSelected;
			_subscribed = true;
		}

		protected override void Dispose (bool isDisposing)
		{
			if (isDisposing)
			{
				var spinner = Spinner;
				if (spinner != null && _subscribed)
				{
					spinner.ItemSelected -= SpinnerItemSelected;
					_subscribed = false;
				}
			}
			base.Dispose (isDisposing);
        }

        #endregion

        #region Events

        private void SpinnerItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var spinner = Spinner;
            if (spinner == null)
                return;

            var newValue = spinner.Adapter.GetRawItem(e.Position);

            bool changed;
            if (newValue == null)
            {
                changed = (_currentValue != null);
            }
            else
            {
                changed = !(newValue.Equals(_currentValue));
            }

            if (!changed)
            {
                return;
            }

            _currentValue = newValue;
            FireValueChanged(newValue);
        }

        #endregion
    }
}

