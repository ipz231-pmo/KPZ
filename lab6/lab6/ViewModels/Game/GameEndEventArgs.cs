using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.ViewModels.Game
{
    public class GameEndEventArgs : EventArgs
    {
        public bool IsWin { get; }
        public GameEndEventArgs(bool isWin) => IsWin = isWin;
    }
}
