using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroTask.Classes
{
    public class Wall : SceneObject2d
    {
        public string Id { get; } 
        public float X2 { get; set; }
        public float Y2 { get; set; }

        public Wall(string id) 
        {
            Id = id;
        }

        public Wall(string id,float _x1, float _y1, float _x2, float _y2)
        {
            Id = id;
            X = _x1; Y = _y1;
            X2 = _x2; Y2 = _y2;
        }
    }
}
