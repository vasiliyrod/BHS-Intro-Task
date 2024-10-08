using IntroTask.ecslite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroTask.Classes.Ecs
{
    internal class MoveSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter _filter;
        private EcsPool<BallComponent> _balls;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            _filter = world.Filter<BallComponent>().End();
            _balls = world.GetPool<BallComponent>();

        }
        public void Run(IEcsSystems systems)
        {
            foreach (int entity in _filter)
            {
                ref BallComponent ballComp = ref _balls.Get(entity);
                ballComp.x += ballComp.velocityX;
                ballComp.y += ballComp.velocityY;
                //ballComp.sceneBall.X += ballComp.velocityX;
                //ballComp.sceneBall.Y += ballComp.velocityY;
            }
        }
    }
}
