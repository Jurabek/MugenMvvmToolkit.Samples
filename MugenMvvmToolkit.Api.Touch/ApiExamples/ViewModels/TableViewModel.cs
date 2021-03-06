using System;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using ApiExamples.Models;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels
{
    public class TableViewModel : CloseableViewModel
    {
        #region Fields

        private readonly IMessagePresenter _messagePresenter;
        private string _filterText;
        private GridViewModel<TableItemModel> _gridViewModel;

        #endregion

        #region Constructors

        public TableViewModel(IMessagePresenter messagePresenter)
        {
            Should.NotBeNull(messagePresenter, "messagePresenter");
            _messagePresenter = messagePresenter;
            AddCommand = new RelayCommand(Add);
            ItemClickCommand = new RelayCommand<TableItemModel>(ItemClick);
            RemoveCommand = new RelayCommand<TableItemModel>(Remove, CanRemove, this);
            InvertSelectionCommand = new RelayCommand(InvertSelection);
        }

        #endregion

        #region Commands

        public ICommand ItemClickCommand { get; private set; }

        public ICommand AddCommand { get; private set; }

        public ICommand RemoveCommand { get; private set; }

        public ICommand InvertSelectionCommand { get; private set; }

        public string FilterText
        {
            get { return _filterText; }
            set
            {
                if (Equals(value, _filterText))
                    return;
                _filterText = value;
                OnPropertyChanged();
                if (GridViewModel != null)
                    GridViewModel.UpdateFilter();
            }
        }

        private void Add(object o)
        {
            int id = GridViewModel.ItemsSource.Max(model => model.Id) + 1;
            var newItem = new TableItemModel { Id = id, Name = "Inserted item " + id };
            if (GridViewModel.SelectedItem == null)
                GridViewModel.ItemsSource.Add(newItem);
            else
                GridViewModel.ItemsSource.Insert(GridViewModel.ItemsSource.IndexOf(GridViewModel.SelectedItem), newItem);
            GridViewModel.SelectedItem = newItem;
        }

        private void ItemClick(TableItemModel obj)
        {
            _messagePresenter.ShowAsync(obj.Name, "Clicked");
        }

        private async void Remove(TableItemModel item)
        {
            if (item == null)
                item = GridViewModel.SelectedItem;
            if (await _messagePresenter.ShowAsync("Delete item " + item.Name + " ?", "Delete", MessageButton.YesNo) !=
                MessageResult.Yes)
                return;
            GridViewModel.ItemsSource.Remove(item);
        }

        private bool CanRemove(TableItemModel item)
        {
            return item != null || GridViewModel.SelectedItem != null;
        }

        private void InvertSelection(object o)
        {
            foreach (var model in GridViewModel.OriginalItemsSource)
            {
                model.IsSelected = !model.IsSelected;
            }
        }

        #endregion

        #region Properties

        public GridViewModel<TableItemModel> GridViewModel
        {
            get { return _gridViewModel; }
            private set
            {
                _gridViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Overrides of ViewModelBase

        protected override void OnInitialized()
        {
            GridViewModel = GetViewModel<GridViewModel<TableItemModel>>();
            GridViewModel.Filter = Filter;
            for (int i = 0; i < 100; i++)
            {
                GridViewModel.ItemsSource.Add(new TableItemModel
                {
                    Id = i,
                    Name = "Item " + i.ToString(CultureInfo.InvariantCulture)
                });
            }
        }

        private bool Filter(TableItemModel item)
        {
            if (string.IsNullOrEmpty(FilterText))
                return true;
            return item.Name.SafeContains(FilterText, StringComparison.CurrentCultureIgnoreCase);
        }

        #endregion
    }
}