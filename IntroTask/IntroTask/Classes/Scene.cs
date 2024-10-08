using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroTask.Classes
{
    internal class Scene
    {
        private List<SceneObject2d> sceneObjects = new List<SceneObject2d>();

        public void AddObject(SceneObject2d obj)
        {
            sceneObjects.Add(obj);
        }

        public List<SceneObject2d> GetObjects()
        {
            return sceneObjects;
        }
    }
}
