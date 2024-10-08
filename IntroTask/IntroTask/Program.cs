using IntroTask.Classes;
using IntroTask.Classes.Ecs;
using IntroTask.ecslite;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Scene scene = new Scene();

        float [] cornersX = { 0,0,100,100};
        float[] cornersY = { 0,100,100,0};
        int wallsNum = 4;
        Wall[] walls = new Wall[wallsNum];
        for (int i=0; i < wallsNum; ++i)
        {
            walls[i] = new Wall("wall" + Convert.ToString(i));
            walls[i].X =cornersX[i];
            walls[i].Y = cornersY[i];
            walls[i].X2 = cornersX[(i+1)%wallsNum];
            walls[i].Y2 = cornersY[(i+1)%wallsNum];
            scene.AddObject(walls[i]);
        }

        Ball ball = new Ball(30, 30, Convert.ToSingle(10), 1, 1);
        scene.AddObject(ball);

        Ecs ecs = new Ecs(scene);

        int n = 0;
        // Главный цикл
        while(n < 300)
        {
            n++;

            ecs.Update();
            Console.WriteLine("Ball Position: " + "X= " + ball.X + "; Y= " + ball.Y);
        }
    }
}