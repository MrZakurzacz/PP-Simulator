using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;
public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size)
    {
        FNext = MapMovement.WallNext;
        FNextDiagonal = MapMovement.WallNextDiagonal;
        //na bazie tego i mapmovement zrobić to samo z smalltorusmap i bigbouncemap :> 
    }

}