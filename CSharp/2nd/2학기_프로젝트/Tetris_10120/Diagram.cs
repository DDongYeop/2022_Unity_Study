﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_10120
{
    internal class Diagram
    {
        internal int X
        {
            get;
            private set;
        }
        internal int Y
        {
            get;
            private set;
        }

        internal int Turn //몇 번째 회전인지 나타냄.
        {
            get;
            private set;
        }

        internal int BlockNum // 몇 번째 도형(블록)인지 나타냄.
        {
            get;
            private set;
        }

        internal Diagram()
        {
            Reset();
        }

        internal void Reset()
        {
            Random random = new Random();
            X = GameRule.SX;  // 4 
            Y = GameRule.SY;  // 0
            Turn = random.Next() % 4; // 어떤 도형의 네 가지 회전 상태 중 하나를 랜덤하게 받아옴
            BlockNum = random.Next() %7;   
        }
        internal void MoveLeft()
        {
            X--;
        }

        internal void MoveRight()
        {
            X++;
        }

        internal void MoveDown()
        {
            Y++;
        }

        internal void MoveTurn()
        {
            Turn = (Turn+1)%4; //0,1,2,3 순으로 회전
        }
    }
}
