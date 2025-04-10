namespace FlyweightTask;

class NodeInfoFactory
{
    public List<LightElementNodeInfo> Particles { get; set; }

    public NodeInfoFactory()
    {
        Particles = [];
    }

    public LightElementNodeInfo GetParticle(LightElementNodeInfo particle)
    {
        var item = Particles.FirstOrDefault(particle);
        if (item != null) return item;
        Particles.Add(particle);
        return particle;
    }
    public IEnumerable<LightElementNodeInfo> ListParticles() => Particles;

}
