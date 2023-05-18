using UnityEngine;

namespace GorillaVFX.Util
{
    internal static class ParticleCreator
    {
        /// <summary>
        /// Creates a basic 2D particle system
        /// </summary>
        /// <param name="loop">Should loop</param>
        /// <param name="lifetime">How long particles live</param>
        /// <param name="lifetimeMultiplier"></param>
        /// <param name="size">Particle size</param>
        /// <param name="speed">Particle move speed</param>
        /// <param name="emmission">The amount of particles to spawn</param>
        /// <param name="max">Max amount of particles at once</param>
        /// <param name="color">The color the basic particle should have</param>
        /// <returns></returns>
        internal static GameObject BasicParticle(
            bool loop,
            float lifetime,
            float lifetimeMultiplier,
            float size,
            float speed,
            float emmission,
            int max,
            Color color)
        {
            GameObject go = new GameObject();
            ParticleSystem ps = go.AddComponent<ParticleSystem>();
            ParticleSystem.MainModule module = ps.main;
            ParticleSystem.EmissionModule eModule = ps.emission;
            ParticleSystem.ShapeModule sModule = ps.shape;
            Sprite defSprite = Resources.Load<Sprite>("");

            eModule.rateOverTime = emmission;

            module.loop = loop;
            module.startLifetime = lifetime;
            module.startLifetimeMultiplier = lifetimeMultiplier;
            module.startSize = size;
            module.startSpeed = speed;
            module.maxParticles = max * Main.ParticleMultiplier.Value;
            module.startColor = color;

            sModule.shapeType = ParticleSystemShapeType.Sprite;
            sModule.sprite = defSprite;

            return go;
        }

        /// <summary>
        /// Creates a basic 3D particle system (MAY NOT WORK FOR NOW)
        /// </summary>
        /// <param name="type">Takes a UnityEngine PrimitiveType for the shape the particles are allowed to be emitted in</param>
        /// <param name="shapeT">Takes a ParticleSystemShapeType to get the mesh shape that the 3D particles should be in</param>
        /// <param name="loop">Should loop</param>
        /// <param name="lifetime">How long the particles live</param>
        /// <param name="lifetimeMultiplier"></param>
        /// <param name="size">Particle size</param>
        /// <param name="speed">Particle move speed</param>
        /// <param name="emmission">The amount of particles to spawn</param>
        /// <param name="max">max amount of particles at once</param>
        /// <param name="color">The color the basic 3D Mesh should have</param>
        /// <returns></returns>
        internal static GameObject Basic3DParticle(
            Mesh shapeMesh,
            ParticleSystemShapeType shapeT,
            bool loop,
            float lifetime,
            float lifetimeMultiplier,
            float size,
            float speed,
            float emission,
            int max,
            Color color)
        {
            GameObject go = new GameObject();
            ParticleSystem ps = go.AddComponent<ParticleSystem>();
            ParticleSystem.MainModule module = ps.main;
            ParticleSystem.EmissionModule eModule = ps.emission;
            var psShape = ps.shape;

            // Make PS use the mesh
            psShape.enabled = true;
            psShape.shapeType = shapeT;

            Material mat = new Material(Shader.Find("Standard"));
            mat.color = color;

            var psr = ps.GetComponent<ParticleSystemRenderer>();

            psr.enabled = true;
            psr.renderMode = ParticleSystemRenderMode.Mesh;
            
            psr.mesh = shapeMesh;
            psr.material = mat;

            eModule.rateOverTime = emission;

            // PS settings
            module.cullingMode = ParticleSystemCullingMode.Automatic;
            module.playOnAwake = false;
            module.loop = loop;
            module.startLifetime = lifetime;
            module.startLifetimeMultiplier = lifetimeMultiplier;
            module.startSize = size;
            module.startSpeed = speed;
            module.maxParticles = max;
            
            return go;
        }

        internal static Mesh getMesh(PrimitiveType type)
        {
            GameObject obj = GameObject.CreatePrimitive(type);

            Mesh shapeMesh = obj.GetComponent<MeshFilter>().mesh;

            GameObject.Destroy(obj);

            return shapeMesh;
        }
    }
}
