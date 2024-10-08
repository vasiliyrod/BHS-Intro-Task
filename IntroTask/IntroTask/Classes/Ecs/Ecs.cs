using IntroTask.ecslite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroTask.Classes.Ecs
{

    internal class Ecs
    {
        private EcsWorld world;
        private EcsSystems systems;

        public Ecs(Scene scene)
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);

            //добавляем системы
            systems
                .Add(new MoveSystem())
                .Add(new RedirectSystem())
                .Add(new CopyBallCompSystem())
                .Init();


            var wallPool = world.GetPool<WallComponent>();
            var ballPool = world.GetPool<BallComponent>();

            // Видимо foreach нужно записать в initSystem // Видимо нет :)
            foreach (var obj in scene.GetObjects())
            {
                if (obj is Wall wall)
                {
                    var entity = world.NewEntity();
                    ref var wallComponent = ref wallPool.Add(entity);
                    wallComponent.x1 = wall.X;
                    wallComponent.y1 = wall.Y;
                    wallComponent.x2 = wall.X2;
                    wallComponent.y2 = wall.Y2;
                    wallComponent.sceneWall = wall;

                }
                else if (obj is Ball ball)
                {
                    var entity = world.NewEntity();
                    ref var ballComponent = ref ballPool.Add(entity);
                    ballComponent.x = ball.X;
                    ballComponent.y = ball.Y;
                    ballComponent.radius = ball.Radius;
                    ballComponent.velocityX = ball.VelocityX;
                    ballComponent.velocityY = ball.VelocityY;
                    ballComponent.sceneBall = ball;
                }
            }
        }

        public void Update()
        {
            systems?.Run();
        }

        public void Destroy()
        {
            if (systems != null)
            {
                systems.Destroy();
                systems = null;
            }
            if (world != null)
            {
                world.Destroy();
                world = null;
            }
        }
    }
}