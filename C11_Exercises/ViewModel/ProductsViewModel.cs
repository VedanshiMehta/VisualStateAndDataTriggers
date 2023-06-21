using C11_Exercises.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C11_Exercises.ViewModel
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        private const int NUMBER_OF_ITEMS_PER_PAGE = 4;
        private GetProductsModel _model;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }
        public int Page { get; set; }
        public int TotalPages = 1;
        private bool _isRunning;
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                _isRunning = value;
                OnPropertyChanged();
            }
        }
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ICommand LoadMoreDataCommand { get; set; }

        public ProductsViewModel()
        {
            _model = new GetProductsModel();
            Products = new ObservableCollection<Product>();
            LoadMoreDataCommand = new Command(() => { _ = GetProductListAsync(); });
            _ = GetProductListAsync();
        }
        public async Task GetProductListAsync()
        {
            if (IsRunning) return;
            if (Page >= TotalPages)
            {
                IsRunning = false;
                return;
            }
            IsRunning = true;
            _model.Page = ++Page;
            _model.Size = NUMBER_OF_ITEMS_PER_PAGE;
            var result = await _model.GetProductDetailsAsync();
            TotalPages = CalculateTotalPageCount(_model.TotalProducts);
            foreach (var item in _model.ProductDetails)
            {
                Products.Add(item);
            }
            IsRunning = false;
        }
        private int CalculateTotalPageCount(long itemCount)
        {
            if (TotalPages == 1)
            {
                int totalItems = Convert.ToInt32(itemCount);
                int pageCount = totalItems % NUMBER_OF_ITEMS_PER_PAGE;
                if (pageCount == 0)
                {
                    return totalItems / NUMBER_OF_ITEMS_PER_PAGE;
                }
                else
                {
                    return totalItems / NUMBER_OF_ITEMS_PER_PAGE + 1;
                }
            }
            return TotalPages;
        }
    }
}
