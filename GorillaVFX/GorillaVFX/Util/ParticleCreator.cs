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
        /// <param name="max">Max amount of particles at once</param>
        /// <param name="color">The color the basic particle should have</param>
        /// <returns></returns>
        internal static ParticleSystem BasicParticle(
            bool loop,
            float lifetime,
            float lifetimeMultiplier,
            float size, float speed,
            int max,
            Color color)
        {
            ParticleSystem ps = new ParticleSystem();
            ParticleSystem.MainModule module = ps.main;

            module.loop = loop;
            module.startLifetime = lifetime;
            module.startLifetimeMultiplier = lifetimeMultiplier;
            module.startSize = size;
            module.startSpeed = speed;
            module.maxParticles = max * Main.ParticleMultiplier.Value;
            module.startColor = color;

            return ps;
        }

        /// <summary>
        /// Creates a basic 3D particle system (MAY NOT WORK FOR NOW)
        /// </summary>
        /// <param name="type">Takes a UnityEngine PrimitiveType for a primitive shape</param>
        /// <param name="loop">Should loop</param>
        /// <param name="lifetime">How long the particles live</param>
        /// <param name="lifetimeMultiplier"></param>
        /// <param name="size">Particle size</param>
        /// <param name="speed">Particle move speed</param>
        /// <param name="max">max amount of particles at once</param>
        /// <param name="color">The color the basic 3D Mesh should have</param>
        /// <returns></returns>
        internal static ParticleSystem Basic3DParticle(
            PrimitiveType type,
            bool loop,
            float lifetime,
            float lifetimeMultiplier,
            float size, float speed,
            int max,
            Color color)
        { // Define and get mesh
            ParticleSystem ps = new ParticleSystem();
            ParticleSystem.MainModule module = ps.main;
            GameObject shape = GameObject.CreatePrimitive(type);
            Mesh mesh = shape.GetComponent<MeshFilter>().sharedMesh;
            GameObject.Destroy(shape);
            var psShape = ps.shape;

            Color[] colors = new Color[mesh.vertices.Length]; // Create array of colors with the length of the vertices array
            for (int i = 0; i < colors.Length; i++) // Loop through the array and set the color of each vertex
            {
                colors[i] = color;
            }

            // Make PS use the mesh
            psShape.enabled = true;
            psShape.shapeType = ParticleSystemShapeType.Mesh;
            psShape.mesh = mesh;
            psShape.mesh.colors = colors;
            psShape.useMeshColors = true;

            // PS settings
            module.loop = loop;
            module.startLifetime = lifetime;
            module.startLifetimeMultiplier = lifetimeMultiplier;
            module.startSize = size;
            module.startSpeed = speed;
            module.maxParticles = max;
            module.startColor = color;

            return ps;
        }
    }
}
