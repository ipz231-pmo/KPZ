using lab6.Core;
using lab6.Models;
using lab6.ViewModels.Game;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace lab6.ViewModels;

class GameVM : VMBase
{
    public FieldVM Field { get; set; }

    private string leftMines, flaggedMines, revealedMines;

    public EventHandler? EndHndl { get; set; }
    public RelayCommand ReturnCmd { get; set; }

    public GameVM()
    {
        Field = new();

        leftMines = $"Left: {Field.TotalMines}";
        flaggedMines = $"Flagged: {Field.FlaggedMines}";
        revealedMines = $"Revealed Cells: {Field.RevealedMines}";

        ReturnCmd = new RelayCommand((arg) => { EndHndl?.Invoke(null, null); });

        Field.PropertyChanged += OnFieldPropertyChanged;
    }

    private void OnFieldPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if(e.PropertyName == nameof(Field.FlaggedMines))
        {
            LeftMines = $"Left: {Math.Max(Field.TotalMines - Field.FlaggedMines, 0)}";
            FlaggedMines = $"Flagged: {Field.FlaggedMines}";
        }
        if(e.PropertyName == nameof(Field.RevealedMines))
        {
            RevealedMines = $"Revealed Cells: {Field.RevealedMines}";
            if (FieldVM.BOARD_SIZE * FieldVM.BOARD_SIZE - Field.TotalMines == Field.RevealedMines)
            {
                MessageBox.Show("You won, congratulations!");
                EndHndl?.Invoke(null, null);
                return;
            }
        }
        if (e.PropertyName == nameof(Field.IsGameOver))
        {
            MessageBox.Show("You lose, Try again!");
            EndHndl?.Invoke(null, null);
            return;
        }
    }

    public string LeftMines { get => leftMines; set { leftMines = value; NotifyOnPropertyChanged(); } }
    public string FlaggedMines { get => flaggedMines; set { flaggedMines = value; NotifyOnPropertyChanged(); } }
    public string RevealedMines { get => revealedMines; set { revealedMines = value; NotifyOnPropertyChanged(); } }
}
