using Unity.Entities;
using Unity.Mathematics;
using Unity.Jobs; 
using Unity.Transforms;

[AlwaysSynchronizeSystem]
public class RotationSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;

        Entities.ForEach((ref Rotation rotation, in RotationSpeedData rotationSpeedData) =>
        {
            rotation.Value = math.mul(rotation.Value, quaternion.RotateX(math.radians(rotationSpeedData.speed * deltaTime)));
            rotation.Value = math.mul(rotation.Value, quaternion.RotateY(math.radians(rotationSpeedData.speed * deltaTime)));
            rotation.Value = math.mul(rotation.Value, quaternion.RotateZ(math.radians(rotationSpeedData.speed * deltaTime)));
        }).Run();

        return default;
    }
}
