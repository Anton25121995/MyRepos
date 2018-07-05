using HelloMvxForms.Core.ViewModels;
using MvvmCross.Forms.Views;
using MvvmCross.Forms.Views.Attributes;

namespace HelloMvxForms.Core.Views
{
    [MvxNavigationPagePresentation]
	public partial class MvxMainView : MvxContentPage<MvxMainViewModel>
	{
		public MvxMainView()
		{
			InitializeComponent();
		}
	}
}