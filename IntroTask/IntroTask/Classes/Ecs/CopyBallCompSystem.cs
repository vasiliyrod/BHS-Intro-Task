using IntroTask.ecslite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroTask.Classes.Ecs
{
    internal class CopyBallCompSystem : IEcsInitSystem, IEcsRunSystem
    {
        EcsFilter _filter;
        EcsPool<BallComponent> _pool;

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            _filter = world.Filter<BallComponent>().End();
            _pool = world.GetPool<BallComponent>();
        }

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter)
            {
                BallComponent ballComp = _pool.Get(entity);
                ballComp.sceneBall.X = ballComp.x;
                ballComp.sceneBall.Y = ballComp.y;
                ballComp.sceneBall.VelocityX = ballComp.velocityX;
                ballComp.sceneBall.VelocityY = ballComp.velocityY;
                ballComp.sceneBall.Radius = ballComp.radius;
            }
        }
    }
}
