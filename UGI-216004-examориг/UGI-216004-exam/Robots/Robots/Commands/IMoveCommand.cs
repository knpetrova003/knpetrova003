﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    public interface IMoveCommand
    {
        Point Destination { get; }
    }
}
