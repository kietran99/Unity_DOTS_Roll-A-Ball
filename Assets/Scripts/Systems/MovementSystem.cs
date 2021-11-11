using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using UnityEngine;

[AlwaysSynchronizeSystem]
public class MovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;
        float2 curInput = new float2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Entities.ForEach((ref PhysicsVelocity vel, in SpeedData speedData) =>
        {
            vel.Linear.xz += curInput * speedData.speed * deltaTime;
        }).Run();

        return default;
    }
}
