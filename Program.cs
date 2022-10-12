using Raylib_cs;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using static HelloWorld.Program;
using Color = Raylib_cs.Color;
using Rectangle = Raylib_cs.Rectangle;

namespace HelloWorld
{
    static class Program
    {
        public struct Ball
        {
            public float x, y;
            public float speedX, speedY;
            public float radius;
            public void Draw()
            {
                Raylib.DrawCircle((int)x, (int)y, radius, Color.WHITE);
            }
        }
        public static bool is1v1 = false;
        public static Rectangle sq1 = new Rectangle(200, 500, 32, 128);
        public static Ball ball;
        public static void Main()
        {
            
            Raylib.InitWindow(1920, 1080, "PONG");
            Raylib.ToggleFullscreen();

            
            Rectangle sq2 = new Rectangle(1680, 500, 32, 128);


            ball.x = Raylib.GetScreenWidth() / 2.0f;
            ball.y = Raylib.GetScreenHeight() / 2.0f;
            ball.radius = 10;
            ball.speedX = 0;
            ball.speedY = 0;
          

            while (!Raylib.WindowShouldClose())
            {
               

                ball.x += ball.speedX * Raylib.GetFrameTime();
                ball.y += ball.speedY * Raylib.GetFrameTime();

                if (ball.y < 0)
                {
                    ball.y = 0;
                    ball.speedY *= -1;
                }

                if (ball.y > Raylib.GetScreenHeight())
                {
                    ball.y = Raylib.GetScreenHeight();
                    ball.speedY *= -1;
                }

                if (Raylib.CheckCollisionCircleRec(new Vector2(ball.x, ball.y), ball.radius, sq1))
                {

                    ball.speedX *= -1.2f;

                }
                if (Raylib.CheckCollisionCircleRec(new Vector2(ball.x, ball.y), ball.radius, sq2))
                {

                    ball.speedX *= -1.2f;

                }

                string winnertext;

                if (ball.x < 0)
                {
                    winnertext = "right player win game \n PRESS SPACE TO CONTINUE";
                    Raylib.DrawText(winnertext, 900, Raylib.GetScreenHeight() / 2 - 30, 60, Color.YELLOW);
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        ball.x = Raylib.GetScreenWidth() / 2;
                        ball.y = Raylib.GetScreenHeight() / 2;

                        ball.speedX = 300;
                        ball.speedY = 300;
                        winnertext = "";
                    }
                }

                if (ball.x > Raylib.GetScreenWidth())
                {
                    winnertext = "left player win game \n PRESS SPACE TO CONTINUE";
                    Raylib.DrawText(winnertext, 300, Raylib.GetScreenHeight() / 2 - 30, 60, Color.YELLOW);
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                    {
                        ball.x = Raylib.GetScreenWidth() / 2;
                        ball.y = Raylib.GetScreenHeight() / 2;

                        ball.speedX = 300;
                        ball.speedY = 300;
                        winnertext = "";
                    }
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_F))
                {
                    ball.speedX = 300;
                    ball.speedY = 300;
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                ball.Draw();
                Raylib.DrawRectangleRec(sq1, Color.WHITE);
                Raylib.DrawRectangleRec(sq2, Color.WHITE);

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_H))
                {
                    is1v1 = true;

                    ball.speedX = 300;
                    ball.speedY = 300;

                }
                if (Raylib.IsKeyUp(KeyboardKey.KEY_F) && is1v1 == false)
                {
                    sq1.y = ball.y + 10;
                }

                if (is1v1 == true)
                {
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                    {
                        sq1.y += -0.8f;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                    {
                        sq1.y += 0.8f;
                    }

                    if (sq1.y >= 940f)
                    {
                        Console.WriteLine("y pos 4 sq1 >= 940");
                        if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                        {
                            sq1.y -= 20;
                        }

                    }
                    if (sq1.y <= 5)
                    {
                        Console.WriteLine("y pos 4 sq1 <= 0");
                        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                        {
                            sq1.y += 20;
                        }

                    }
                }
                
                Raylib.DrawText("PONG! By Raef", 750, 50, 60, Color.WHITE);
                Raylib.DrawText("PONG: Press F to vs an AI, or Press H to play in a 1v1 game", 500, 1050, 30, Color.WHITE);

                //if out of bound
                if (sq2.y >= 940f)
                {
                    Console.WriteLine("y pos 4 sq2 >= 940");
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                    {
                        sq2.y -= 20;
                    }

                }
                if (sq2.y <= 5)
                {
                    Console.WriteLine("y pos 4 sq2 <= 0");
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                    {
                        sq2.y += 20;
                    }

                }
                //if inbound
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    sq2.y += -0.8f;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    sq2.y += 0.8f;
                }

            Raylib.EndDrawing();
            }
        }

    }
}

    
