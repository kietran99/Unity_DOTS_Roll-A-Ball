using Unity.Entities;
using Unity.Jobs;

public class DeleteSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        EntityCommandBuffer cmdBuf = new EntityCommandBuffer(Unity.Collections.Allocator.TempJob);

        Entities
            .WithAll<Tombstone>()
            .ForEach((Entity entity) => cmdBuf.DestroyEntity(entity))
            .Run();

        cmdBuf.Playback(EntityManager);
        cmdBuf.Dispose();

        return default;
    }
}
