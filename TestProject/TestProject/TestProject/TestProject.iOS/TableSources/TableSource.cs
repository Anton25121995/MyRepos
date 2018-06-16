using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;
using TestProject.Core.Interfaces;
using TestProject.Core.Models;
using TestProject.Core.ViewModels;
using TestProject.iOS.Cells;
using UIKit;

namespace TestProject.iOS.TableSources
{
    public class TableSource : MvxStandardTableViewSource
    {
        private NSString _cellKey = TableViewCell.Key;

        #region Cell
        public TableSource(UITableView tableView) : base(tableView)
        {

        }
        
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (TableViewCell)tableView.DequeueReusableCell(_cellKey);
            cell.BindingContext.DataContext = GetItemAt(indexPath);

            return cell;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var listItem = (ItemViewModel)item;
            return (TableViewCell)TableView.DequeueReusableCell(_cellKey, indexPath);
        }
        #endregion

        #region Header and footer
        public override UIView GetViewForFooter(UITableView tableView, nint section)
        {
            var view = new UIView();
            return view;
        }

        public override nfloat GetHeightForFooter(UITableView tableView, nint section)
        {
            return UIScreen.MainScreen.Bounds.Height*0.3f;
        }
        #endregion
    }
}