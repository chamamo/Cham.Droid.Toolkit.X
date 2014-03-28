using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using Cham.Droid.Toolkit;
using Cham.Droid.ToolkitX.Binding;
using Cirrious.CrossCore.Converters;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;

namespace Cham.Droid.ToolkitX
{
	public abstract class ChamAndroidSetup : MvxAndroidSetup
	{
	    protected ChamAndroidSetup (Context applicationContext)
            : base (applicationContext)
		{
		}

		protected override System.Collections.Generic.IDictionary<string, string> ViewNamespaceAbbreviations
		{
		    get
		    {
		        var abbreviations = base.ViewNamespaceAbbreviations;
		        abbreviations["cham"] = "Cham.Droid.Toolkit";
		        abbreviations["chamx"] = "Cham.Droid.ToolkitX";
		        return abbreviations;
		    }
		}

		protected override System.Collections.Generic.IList<System.Reflection.Assembly> AndroidViewAssemblies
		{
			get
			{
				var assemblies = base.AndroidViewAssemblies;
				assemblies.Add (typeof(ChamEditText).Assembly);
				assemblies.Add (typeof(ChamSpinner).Assembly);
				return assemblies;
			}
		}

	    protected override List<Assembly> ValueConverterAssemblies
	    {
	        get
	        {
	            var assemblies = base.ValueConverterAssemblies;
	            assemblies.Add(GetType().Assembly);
	            return assemblies;
	        }
	    }

	    protected override void FillTargetFactories (Cirrious.MvvmCross.Binding.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
		{
			base.FillTargetFactories (registry);
			registry.RegisterFactory (new MvxSimplePropertyInfoTargetBindingFactory (typeof(ChamEditTextHeaderBinding), typeof(ChamEditText), "Header"));
			registry.RegisterFactory (new MvxSimplePropertyInfoTargetBindingFactory (typeof(ChamEditTextTextBinding), typeof(ChamEditText), "Text"));

			registry.RegisterFactory (new MvxSimplePropertyInfoTargetBindingFactory (typeof(ChamTextViewHeaderBinding), typeof(ChamTextView), "Header"));
			registry.RegisterFactory (new MvxSimplePropertyInfoTargetBindingFactory (typeof(ChamTextViewTextBinding), typeof(ChamTextView), "Text"));

			registry.RegisterFactory (new MvxSimplePropertyInfoTargetBindingFactory (typeof(ChamDatePickerHeaderBinding), typeof(ChamDatePicker), "Header"));
			registry.RegisterFactory (new MvxSimplePropertyInfoTargetBindingFactory (typeof(ChamDatePickerBinding), typeof(ChamDatePicker), "Value"));

			registry.RegisterFactory (new MvxSimplePropertyInfoTargetBindingFactory (typeof(ChamImageViewBinding), typeof(ChamImageView), "Image"));

			registry.RegisterFactory (new MvxSimplePropertyInfoTargetBindingFactory (typeof(ChamSpinnerHeaderBinding), typeof(ChamSpinner), "Header"));
			registry.RegisterCustomBindingFactory<ChamSpinner> ("SelectedItem", spinner => new ChamSpinnerSelectedItemBinding (spinner));

            registry.RegisterFactory(new MvxSimplePropertyInfoTargetBindingFactory(typeof(ChamAutoCompleteTextViewHeaderBinding), typeof(ChamAutoCompleteTextView), "Header"));
            registry.RegisterPropertyInfoBindingFactory((typeof(ChamAutoCompleteTextViewPartialTextTargetBinding)),
                                                    typeof(ChamAutoCompleteTextView), "PartialText");

            registry.RegisterFactory(new MvxSimplePropertyInfoTargetBindingFactory(typeof(ChamAutoCompleteTextViewTextBinding), typeof(ChamAutoCompleteTextView), "Text"));

            registry.RegisterPropertyInfoBindingFactory(
                                                    typeof(ChamAutoCompleteTextViewSelectedObjectTargetBinding),
                                                    typeof(ChamAutoCompleteTextView),
                                                    "SelectedObject");
            
		}
	}
}