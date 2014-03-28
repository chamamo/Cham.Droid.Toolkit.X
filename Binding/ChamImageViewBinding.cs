using System;
using Cham.Droid.Toolkit;
using Cirrious.MvvmCross.Binding;
using Cirrious.MvvmCross.Binding.ExtensionMethods;
using System.Reflection;

namespace Cham.Droid.ToolkitX.Binding
{
	public class ChamImageViewBinding : Cirrious.MvvmCross.Binding.Bindings.Target.MvxPropertyInfoTargetBinding<ChamImageView>
    {
        #region Constructor
        public ChamImageViewBinding (object target, PropertyInfo targetPropertyInfo) : base (target, targetPropertyInfo)
		{
		}

        #endregion

        #region Properties

        public override Type TargetType
		{
			get { return typeof(byte[]); }
		}

		public override MvxBindingMode DefaultMode
		{
			get { return MvxBindingMode.TwoWay; }
		}

		public override void SubscribeToEvents ()
		{
			View.ImageChanged += ChamImageViewImageChanged;
		}

        #endregion

        #region Methods

        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (isDisposing)
            {
                if (View != null)
                {
                    View.ImageChanged -= ChamImageViewImageChanged;
                }
            }
        }

        #endregion

        #region Events

        private void ChamImageViewImageChanged(object sender, EventArgs e)
        {
            FireValueChanged(View.Image);
        }

        #endregion
	}
}

