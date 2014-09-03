using Android.Views;
using Cirrious.CrossCore.WeakSubscription;
using System;
using System.Windows.Input;
using Cirrious.MvvmCross.Binding.Droid.Target;
using Cirrious.MvvmCross.Binding;

namespace Cham.Droid.ToolkitX
{
	public class ChamSpinnerActionButtonClickBinding : MvxAndroidTargetBinding
	{
		private ICommand _command;
		private IDisposable _canExecuteSubscription;
		private readonly EventHandler<EventArgs> _canExecuteEventHandler;

		public override MvxBindingMode DefaultMode
		{
			get
			{
				return MvxBindingMode.OneWay;
			}
		}

		public override Type TargetType
		{
			get
			{
				return typeof(ICommand);
			}
		}

		protected ChamSpinner View
		{
			get
			{
				return (ChamSpinner)base.Target;
			}
		}

		//
		// Constructors
		//
		public ChamSpinnerActionButtonClickBinding (ChamSpinner view) : base (view)
		{
			this._canExecuteEventHandler = new EventHandler<EventArgs> (this.OnCanExecuteChanged);
			view.ActionButtonClick += new EventHandler (this.ViewOnClick);
		}

		//
		// Methods
		//
		protected override void Dispose (bool isDisposing)
		{
			if (isDisposing)
			{
				var view = this.View;
				if (view != null)
				{
					view.ActionButtonClick -= new EventHandler (this.ViewOnClick);
				}
				if (this._canExecuteSubscription != null)
				{
					this._canExecuteSubscription.Dispose ();
					this._canExecuteSubscription = null;
				}
			}
			base.Dispose (isDisposing);
		}

		private void OnCanExecuteChanged (object sender, EventArgs e)
		{
			this.RefreshEnabledState ();
		}

		private void RefreshEnabledState ()
		{
			var view = this.View;
			if (view == null)
			{
				return;
			}
			bool enabled = false;
			if (this._command != null)
			{
				enabled = this._command.CanExecute (null);
			}
			view.Enabled = enabled;
		}

		protected override void SetValueImpl (object target, object value)
		{
			if (this._canExecuteSubscription != null)
			{
				this._canExecuteSubscription.Dispose ();
				this._canExecuteSubscription = null;
			}
			this._command = (value as ICommand);
			if (this._command != null)
			{
				this._canExecuteSubscription = this._command.WeakSubscribe (this._canExecuteEventHandler);
			}
			this.RefreshEnabledState ();
		}

		private void ViewOnClick (object sender, EventArgs args)
		{
			if (this._command == null)
			{
				return;
			}
			if (!this._command.CanExecute (null))
			{
				return;
			}
			this._command.Execute (null);
		}
	}
}

