using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroTask.Classes
{
    // класс - публичный, так как нужно было обеспечить доступ к нему в BallComponent
    public class Ball : SceneObject2d 
    {
        public float Radius { get; set; }
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }

        public Ball() { }

        public Ball(float _x, float _y, float _radius, float _velocityX, float _velocityY)
        {
            X = _x; Y = _y;
            Radius = _radius;
            VelocityX = _velocityX;
            VelocityY = _velocityY;
        }
    }
}