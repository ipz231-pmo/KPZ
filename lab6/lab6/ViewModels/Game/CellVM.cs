using lab6.Core;
using lab6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace lab6.ViewModels.Game;

class CellVM : VMBase
{
    private int x, y, neighbourMines;
    private bool isMine, isRevealed = false, isFlagged = false;
    private BitmapImage image;



    public CellVM(int x, int y, bool isMine, int neighbourMines)
    {
        this.x = x;
        this.y = y;
        this.neighbourMines = neighbourMines;
        this.isMine = isMine;

        PropertyChanged += OnPropertyChanged;

        Image = App.Current.Resources["CellPlain"] as BitmapImage;
    }

    private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(IsFlagged)) OnFlagged();
        if (e.PropertyName == nameof(IsRevealed)) OnRevealed();
    }

    public int X { get => x; set { x = value; NotifyOnPropertyChanged(); } }
    public int Y { get => y; set { y = value; NotifyOnPropertyChanged(); } }
    public bool IsMine { get => isMine; set { isMine = value; NotifyOnPropertyChanged(); } }
    public bool IsRevealed { get => isRevealed; set { isRevealed = value; NotifyOnPropertyChanged(); } }
    public bool IsFlagged { get => isFlagged; set { isFlagged = value; NotifyOnPropertyChanged(); } }
    public int NeighbourMines { get => neighbourMines; set { neighbourMines = value; NotifyOnPropertyChanged(); } }
    public BitmapImage Image { get => image; set { image = value; NotifyOnPropertyChanged(); } }

    private void OnFlagged()
    {
        string src = "Cell";
        src += isFlagged ? "Flagged" : "Plain";
        Image = App.Current.Resources[src] as BitmapImage;
    }
    private void OnRevealed()
    {
        string src = "Cell";
        src += isMine ? "Mine" : NeighbourMines;
        Image = App.Current.Resources[src] as BitmapImage;
    }
}
