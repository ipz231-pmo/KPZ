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

    private int totalMines, flaggedMines, revealedMines;
    private bool isGameOver;

    public List<List<CellVM>> Field { get; set; }
    public RelayCommand RevealCmd { get; set; }
    public RelayCommand FlagCmd { get; set; }


    public FieldVM()
    {
        RevealCmd = new RelayCommand(reveal, canReveal);
        FlagCmd = new RelayCommand(flag, canFlag);

        bool[,] mines = new bool[BOARD_SIZE, BOARD_SIZE];
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                int chance = new Random().Next(1001);
                bool mine = chance < MINE_CHANCE;
                mines[i, j] = mine;
                TotalMines += mine ? 1 : 0;
            }
        }

        int CalcNeighbourMines(int x, int y)
        {
            int count = 0;
            if (check(x - 1, y + 1)) count += mines[y + 1, x - 1] ? 1 : 0;
            if (check(x - 0, y + 1)) count += mines[y + 1, x - 0] ? 1 : 0;
            if (check(x + 1, y + 1)) count += mines[y + 1, x + 1] ? 1 : 0;

            if (check(x - 1, y + 0)) count += mines[y + 0, x - 1] ? 1 : 0;
            if (check(x + 1, y + 0)) count += mines[y + 0, x + 1] ? 1 : 0;

            if (check(x - 1, y - 1)) count += mines[y - 1, x - 1] ? 1 : 0;
            if (check(x - 0, y - 1)) count += mines[y - 1, x - 0] ? 1 : 0;
            if (check(x + 1, y - 1)) count += mines[y - 1, x + 1] ? 1 : 0;
            return count;
        }

        Field = [];
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            List<CellVM> row = [];
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                var cellVM = new CellVM(i, j, mines[i, j], CalcNeighbourMines(j, i));
                row.Add(cellVM);
            }
            Field.Add(row);
        }

    }

    private void PrintMines(bool[,] mines)
    {
        char
            borderChar = '+',
            mineChar = '#';

        Console.WriteLine();
        for (int i = 0; i < BOARD_SIZE + 2; i++)
        {
            Console.Write(borderChar);
        }
        Console.WriteLine();
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            Console.Write(borderChar);
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                Console.Write(mines[i, j] ? mineChar : " ");
            }
            Console.Write(borderChar);
            Console.WriteLine();
        }
        for (int i = 0; i < BOARD_SIZE + 2; i++)
        {
            Console.Write(borderChar);
        }
        Console.WriteLine();
    }
    private void PrintNeighbours()
    {
        char
            borderChar = '+',
            mineChar = '#';

        Console.WriteLine();
        Console.Write(' ');
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            Console.Write(i);
        }
        Console.WriteLine();
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            Console.Write(borderChar);
            for (int j = 0; j < BOARD_SIZE; j++)
            {
                string pr = Field[i][j].IsMine ? mineChar.ToString() : Field[i][j].NeighbourMines.ToString();
                Console.Write(pr);
            }
            Console.Write(borderChar);
            Console.WriteLine();
        }
        Console.Write(' ');
        for (int i = 0; i < BOARD_SIZE; i++)
        {
            Console.Write(i);
        }
        Console.WriteLine();
    }

    private bool check(int x, int y) =>
        x >= 0 && x < BOARD_SIZE && y >= 0 && y < BOARD_SIZE;

    private void reveal(object? param)
    {
        var cell = param as CellVM;
        RevealedMines++;
        cell.IsRevealed = true;
        if (cell.IsMine) IsGameOver = true;

        /* Buggy, Buggy
        if (cell.NeighbourMines == 0) 
        {
            for (int i = cell.Y - 1; i <= cell.Y + 1; i++)
            {
                for (int j = cell.X - 1; j <= cell.X + 1; j++)
                {
                    if (!check(j, i)) continue;
                    //var neighbour = Field[i][j];
                    if (canReveal(Field[i][j])) reveal(Field[i][j]);
                }
            }
        }
        */
    }
    private bool canReveal(object? param)
    {
        var cell = param as CellVM;
        return !IsGameOver && !cell.IsRevealed && !cell.IsFlagged;
    }
    private void flag(object? param)
    {
        var cell = param as CellVM;
        bool wasFlagged = cell.IsFlagged;
        cell.IsFlagged = !cell.IsFlagged;
        FlaggedMines += wasFlagged ? -1 : 1;
    }
    private bool canFlag(object? param)
    {
        var cell = param as CellVM;
        return !IsGameOver && cell.IsRevealed == false;
    }

    public bool IsGameOver { get => isGameOver; set { isGameOver = value; NotifyOnPropertyChanged(); } }
    public int FlaggedMines { get => flaggedMines; set{ flaggedMines = value; NotifyOnPropertyChanged(); } }
    public int TotalMines { get => totalMines; private set { totalMines = value; NotifyOnPropertyChanged(); } }
    public int RevealedMines { get => revealedMines; private set { revealedMines = value; NotifyOnPropertyChanged(); } }
}
