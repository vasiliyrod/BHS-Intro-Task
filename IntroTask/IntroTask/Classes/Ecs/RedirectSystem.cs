// Здесь описывается как мячик будет отскакивать от стен
using IntroTask.ecslite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroTask.Classes.Ecs
{
    internal class RedirectSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter _filterBalls;
        private EcsFilter _filterWalls;
        private EcsPool<WallComponent> _walls;
        private EcsPool<BallComponent> _balls;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filterBalls = world.Filter<BallComponent>().End();
            _filterWalls = world.Filter<WallComponent>().End();
            
            _walls = world.GetPool<WallComponent>();
            _balls = world.GetPool<BallComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entityBall in _filterBalls)
            {
                ref BallComponent ballComp = ref _balls.Get(entityBall);

                foreach (var entityWall in _filterWalls)
                {
                    ref WallComponent wallComp = ref _walls.Get(entityWall);

                    float _x1 = wallComp.x1;
                    float _x2 = wallComp.x2;
                    float _y1 = wallComp.y1;
                    float _y2 = wallComp.y2;
                    if (wallComp.x1 > wallComp.x2)
                    {
                        _x1 = wallComp.x2;
                        _x2 = wallComp.x1;
                    }
                    if (wallComp.y1 > wallComp.y2)
                    {
                        _y1 = wallComp.y2;
                        _y2 = wallComp.y1;
                    }

                    // Условия соприкосновения 
                    // касается сверху или снизу
                    // мб сделать <=
                    if ((( (_x1 <= ballComp.x) && (ballComp.x <= _x2) ) && ( (_y1 == ballComp.y + ballComp.radius) && (ballComp.y + ballComp.radius == _y2) )) ||
                        (((_x1 <= ballComp.x) && (ballComp.x <= _x2)) && ((_y1 == ballComp.y - ballComp.radius) && (ballComp.y - ballComp.radius == _y2))))
                    {
                        ballComp.velocityY *= -1;
                        Console.WriteLine("    Ball hit: " + wallComp.sceneWall.Id + " !");
                    }
                    // касается справа или слева
                    if ((((_x1 == ballComp.x + ballComp.radius) && (ballComp.x + ballComp.radius == _x2)) && ((_y1 <= ballComp.y) && (ballComp.y <= _y2))) ||
                        (((_x1 == ballComp.x - ballComp.radius) && (ballComp.x - ballComp.radius == _x2)) && ((_y1 <= ballComp.y) && (ballComp.y <= _y2))))
                    {
                        ballComp.velocityX *= -1;
                    }

                }
            }
        }
    }
}