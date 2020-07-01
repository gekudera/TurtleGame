using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace GameTurtle
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
            GraphicsWindow.BrushColor = "Yellow";
            Turtle.PenUp();
            var eat = Shapes.AddRectangle(10, 10);
            int x1 = 200;
            int y1 = 200;
            int counter = 0;
            GraphicsWindow.BrushColor = "Red";
            GraphicsWindow.DrawText(10, 10, "Очки: " + counter);
            //Создание объекта для генерации чисел
            Random rnd = new Random();

            Shapes.Move(eat, x1, y1);
            while (true)
            {
                Turtle.Move(5);
                if ((Turtle.X <= x1 + 10) && (Turtle.X >= x1) && (Turtle.Y <= y1 + 10) && (Turtle.Y >= y1))
                {
                    GraphicsWindow.BrushColor = "White";
                    GraphicsWindow.DrawText(10, 10, "Очки: " + counter);
                    counter++;
                    GraphicsWindow.BrushColor = "Red";
                    GraphicsWindow.DrawText(10, 10, "Очки: " + counter);
                    x1 = rnd.Next(10, GraphicsWindow.Width);
                    y1 = rnd.Next(10, GraphicsWindow.Height);
                    Shapes.Move(eat, x1, y1);
                    Turtle.Speed = Turtle.Speed + 0.3;
                }
                if (Turtle.X > GraphicsWindow.Width)
                {
                    Turtle.X = 0;
                }
                else if (Turtle.X < 0)
                {
                    Turtle.X = GraphicsWindow.Width;
                }

                if (Turtle.Y < 0)
                {
                    Turtle.Y = GraphicsWindow.Height;
                }
                else if (Turtle.Y > GraphicsWindow.Height)
                {
                    Turtle.Y = 0;
                }

            }
            
        }

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
            else if (GraphicsWindow.LastKey == "Left")
            {
                Turtle.Angle = 270;
            }
            else if (GraphicsWindow.LastKey == "Right")
            {
                Turtle.Angle = 90;
            }
        }


    }
}
