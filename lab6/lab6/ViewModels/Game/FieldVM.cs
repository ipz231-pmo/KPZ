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

class FieldVM : VMBase
{
    public const int BOARD_SIZE = 10;
    public const int MINE_CHANCE = 80;

    private static readonly Random _rng = new Random();

    private int totalMines, flaggedMines, revealedMines;
    private bool isGameOver;

    public List<List<CellVM>> Field { get; private set; }
    public RelayCommand RevealCmd { get; set; }
    public RelayCommand FlagCmd { get; set; }


    public FieldVM()
    {
        RevealCmd = new RelayCommand(reveal, canReveal);
        FlagCmd = new RelayCommand(flag, canFlag);

        // Генеруємо розташування мін
        bool[,] mines = new bool[BOARD_SIZE, BOARD_SIZE];
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                bool mine = _rng.Next(100) < MINE_CHANCE;
                mines[i, j] = mine;
                if (mine) TotalMines++;
            }
        }

        // Ініціалізуємо поле
        Field = new List<List<CellVM>>();
        for (int y = 0; y < BOARD_SIZE; y++)
        {
            var row = new List<CellVM>();
            for (int x = 0; x < BOARD_SIZE; x++)
            {
                int neighbours = CountNeighbours(mines, x, y);
                row.Add(new CellVM(x, y, mines[y, x], neighbours));
            }
            Field.Add(row);
        }
    }

    private int CountNeighbours(bool[,] mines, int x, int y)
    {
        int count = 0;
        for (int dy = -1; dy <= 1; dy++)
            for (int dx = -1; dx <= 1; dx++)
                if (!(dx == 0 && dy == 0))
                {
                    int nx = x + dx, ny = y + dy;
                    if (nx >= 0 && nx < BOARD_SIZE && ny >= 0 && ny < BOARD_SIZE)
                        if (mines[ny, nx]) count++;
                }
        return count;
    }

    private bool check(int x, int y) =>
        x >= 0 && x < BOARD_SIZE && y >= 0 && y < BOARD_SIZE;

    private void reveal(object? param)
    {
        if (param is not CellVM cell) return;
        if (cell.IsRevealed || cell.IsFlagged || IsGameOver) return;

        // Розкриваємо стартову клітину
        cell.IsRevealed = true;
        RevealedMines++;

        // Якщо вона має 0 сусідів — запускаємо flood-fill
        if (cell.NeighbourMines == 0)
            FloodFill(cell.X, cell.Y);

        // Якщо це міна — кінець гри
        if (cell.IsMine)
        {
            System.Windows.MessageBox.Show("You lose, try again!");
            EndGame(false);
            return;
        }

        // Перемога при відкритті всіх безмінних клітин
        if (BOARD_SIZE * BOARD_SIZE - TotalMines == RevealedMines)
        {
            System.Windows.MessageBox.Show("You won, congratulations!");
            EndGame(true);
        }
    }

    private void FloodFill(int startX, int startY)
    {
        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((startX, startY));

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            foreach (var (dx, dy) in new[] { (-1, -1), (0, -1), (1, -1),
                                                  (-1,  0),          (1,  0),
                                                  (-1,  1), (0,  1), (1,  1) })
            {
                int nx = x + dx, ny = y + dy;
                if (nx < 0 || nx >= BOARD_SIZE || ny < 0 || ny >= BOARD_SIZE)
                    continue;

                var neighbour = Field[ny][nx];
                if (!neighbour.IsRevealed && !neighbour.IsFlagged)
                {
                    neighbour.IsRevealed = true;
                    RevealedMines++;
                    if (neighbour.NeighbourMines == 0 && !neighbour.IsMine)
                        queue.Enqueue((nx, ny));
                }
            }
        }
    }

    private bool canReveal(object? param)
    {
        if (param is not CellVM cell) return false;
        return !IsGameOver && !cell.IsRevealed && !cell.IsFlagged;
    }
    private void flag(object? param)
    {
        if (param is not CellVM cell) return;
        bool wasFlagged = cell.IsFlagged;
        cell.IsFlagged = !wasFlagged;
        FlaggedMines += wasFlagged ? -1 : 1;
    }
    private bool canFlag(object? param)
    {
        return param is CellVM cell && !IsGameOver && !cell.IsRevealed;
    }
    private void EndGame(bool isWin)
    {
        IsGameOver = true;
        EndHndl?.Invoke(this, new GameEndEventArgs(isWin));
    }
    public bool IsGameOver { get => isGameOver; set { isGameOver = value; NotifyOnPropertyChanged(); } }
    public int FlaggedMines { get => flaggedMines; set{ flaggedMines = value; NotifyOnPropertyChanged(); } }
    public int TotalMines { get => totalMines; private set { totalMines = value; NotifyOnPropertyChanged(); } }
    public int RevealedMines { get => revealedMines; private set { revealedMines = value; NotifyOnPropertyChanged(); } }
    public event EventHandler? EndHndl;
}
