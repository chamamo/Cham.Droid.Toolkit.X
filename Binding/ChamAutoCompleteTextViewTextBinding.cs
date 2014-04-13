using System;
using Cham.Droid.Toolkit;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.ExtensionMethods;
using System.Reflection;
using Cirrious.MvvmCross.Binding.Bindings.Target;

namespace Cham.Droid.ToolkitX.Binding
{
	public class ChamAutoCompleteTextViewTextBinding : ChamAutoCompleteTextViewTextBinding<ChamAutoCompleteTextView>
	{
		public ChamAutoCompleteTextViewTextBinding (object target, PropertyInfo targetPropertyInfo) : base (target, targetPropertyInfo)
		{
		}
	}

	public class ChamAutoCompleteTextViewTextBinding<T> : MvxPropertyInfoTargetBinding<T>, IChamValidationBinding
		where T : ChamAutoCompleteTextView
	{
		public ChamAutoCompleteTextViewTextBinding (object target, PropertyInfo targetPropertyInfo) : base (target, targetPropertyInfo)
		{
		}

		public IChamValidation ChamValidation { get { return View as IChamValidation; } }

		public override Type TargetType
		{
			get { return typeof(string); }
		}

		public override MvxBindingMode DefaultMode
		{
			get { return MvxBindingMode.TwoWay; }
		}

		public override void SubscribeToEvents ()
		{
			View.AfterTextChanged += EditTextAfterTextChanged;
		}

		private void EditTextAfterTextChanged (object sender, EventArgs e)
		{
			FireValueChanged (View.Text);
		}

		protected override void Dispose (bool isDisposing)
		{
			base.Dispose (isDisposing);
			if (isDisposing)
			{
				if (View != null)
				{
					View.AfterTextChanged -= EditTextAfterTextChanged;
				}
			}
		}
	}
}

