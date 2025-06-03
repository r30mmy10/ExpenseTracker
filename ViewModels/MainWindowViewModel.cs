using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.Models;

namespace ExpenseTracker.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        // Коллекция расходов
        public ObservableCollection<Expense> Expenses { get; }

        // Новая дата — DateTimeOffset? чтобы совпадало с DatePicker.SelectedDate
        private DateTimeOffset? _newDate = DateTimeOffset.Now;
        public DateTimeOffset? NewDate
        {
            get => _newDate;
            set => SetProperty(ref _newDate, value);
        }

        private string _newCategory = string.Empty;
        public string NewCategory
        {
            get => _newCategory;
            set => SetProperty(ref _newCategory, value);
        }

        private decimal _newAmount;
        public decimal NewAmount
        {
            get => _newAmount;
            set => SetProperty(ref _newAmount, value);
        }

        private string _newComment = string.Empty;
        public string NewComment
        {
            get => _newComment;
            set => SetProperty(ref _newComment, value);
        }

        // Команда “Добавить”
        public IRelayCommand AddExpenseCommand { get; }

        public MainWindowViewModel()
        {
            // Инициализируем коллекцию демонстрационными строками
            Expenses = new ObservableCollection<Expense>
            {
                new Expense
                {
                    Date = DateTimeOffset.Now,
                    Category = "Продукты",
                    Amount = 1200,
                    Comment = "Магазин"
                },
                new Expense
                {
                    Date = DateTimeOffset.Now,
                    Category = "Транспорт",
                    Amount = 300,
                    Comment = "Метро"
                }
            };

            AddExpenseCommand = new RelayCommand(AddExpense);
        }

        private void AddExpense()
        {
            // Не добавляем, если нет даты, либо пустая категория, либо сумма ≤ 0
            if (NewDate == null
                || string.IsNullOrWhiteSpace(NewCategory)
                || NewAmount <= 0)
            {
                return;
            }

            var expense = new Expense
            {
                Date     = NewDate.Value, 
                Category = NewCategory,
                Amount   = NewAmount,
                Comment  = NewComment
            };

            Expenses.Add(expense);

            // Сбрасываем поля ввода
            NewDate     = DateTimeOffset.Now;
            NewCategory = string.Empty;
            NewAmount   = 0;
            NewComment  = string.Empty;
        }
    }
}
