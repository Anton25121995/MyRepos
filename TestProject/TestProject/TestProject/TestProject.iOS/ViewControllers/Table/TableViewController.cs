using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using System;
using TestProject.Core.ViewModels;
using TestProject.iOS.Cells;
using TestProject.iOS.TableSources;
using TestProject.iOS.ViewControllers.Base;
using UIKit;

namespace TestProject.iOS.ViewControllers.Table
{
    [MvxModalPresentation(Animated = true)]
    public partial class TableViewController : BaseViewController<TableViewModel>
    {
        private UIRefreshControl refreshControl;

        public TableViewController() : base("TableViewController", null)
        {

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            refreshControl = new UIRefreshControl();

            tableView.RowHeight = 60;
            tableView.SeparatorColor = UIColor.Blue;
            tableView.RefreshControl = refreshControl;

            tableView.RegisterClassForCellReuse(typeof(TableViewCell), TableViewCell.Key);
            tableView.RegisterNibForCellReuse(TableViewCell.Nib, TableViewCell.Key);

            var source = new TableSource(tableView);
            tableView.Source = source;
            
            refreshControl.ValueChanged += RefreshTable;

            var set = this.CreateBindingSet<TableViewController, TableViewModel>();
            set.Bind(source).For(v => v.ItemsSource).To(vm => vm.Items);
            set.Bind(addButton).To(vm => vm.CreateNewItemCommand);
            set.Bind(source).For(v => v.SelectionChangedCommand).To(vm => vm.ItemSelectedCommand);
            set.Apply();
        }

        private void RefreshTable(object sender, EventArgs e)
        {
            ViewModel.RefreshTableCommand.Execute();
            refreshControl.EndRefreshing();
        }
    }
}