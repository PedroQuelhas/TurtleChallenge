using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Settings.GameSettingsFiles
{
    internal interface ISettingsParser
    {
        GameSettings Parse();
    }
}
