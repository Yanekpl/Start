using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace TurtleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // управление черепахой, окно должно быть активным
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            // указываем, что чертить линию передвижения не надо
            Turtle.PenUp();
            //вводим переменную "еда" и красим ее в красный цвет, добавляем переменные местоположения
            GraphicsWindow.BrushColor = "Red";
            var eat = Shapes.AddEllipse(10, 10);
            int x = 100;
            int y = 100;
            Shapes.Move(eat, x, y);
            Random escape_my_eat = new Random();
            // бесконечный цикл
            while (true)
            {
                Turtle.Move(10);
                if (Turtle.X >= x && Turtle.X <= x+10 && Turtle.Y >= y && Turtle.Y <= y + 10)
                {
                    x = escape_my_eat.Next(0, GraphicsWindow.Width);
                    y = escape_my_eat.Next(0, GraphicsWindow.Height);
                    Shapes.Move(eat, x, y);
                    Turtle.Speed++;
                }
            }
        }
        // вводим фуекцию которая отследиваен нажания на стрелки клавиатуры
        private static void GraphicsWindow_KeyDown()
        {
            if (GraphicsWindow.LastKey == "Up")
            {
                Turtle.Angle = 0;
            }
            else if (GraphicsWindow.LastKey == "Down")
            {
                Turtle.Angle = 180;
            }
            else if (GraphicsWindow.LastKey == "Right")
            {
                Turtle.Angle = 90;
            }
            else if (GraphicsWindow.LastKey == "Left")
            {
                Turtle.Angle = 270;
            }
        }
    }
}
