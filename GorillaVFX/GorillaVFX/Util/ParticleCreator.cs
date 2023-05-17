using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GorillaVFX.Util
{
    internal class ParticleCreator
    {
        private static ParticleSystem ps = new ParticleSystem();

        private static ParticleSystem.MainModule getModule()
        {
            return ps.main;
        }

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
        internal static ParticleSystem BasicParticle( bool loop, float lifetime, float lifetimeMultiplier, float size, float speed, int max, Color color)
        {
            ParticleSystem.MainModule module = getModule();

            module.loop = loop;
            module.startLifetime = lifetime;
            module.startLifetimeMultiplier = lifetimeMultiplier;
            module.startSize = size;
            module.startSpeed = speed;
            module.maxParticles = max;
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
        internal static ParticleSystem Basic3DParticle(PrimitiveType type, bool loop, float lifetime, float lifetimeMultiplier, float size, float speed, int max, Color color)
        { // Define and get mesh
            ParticleSystem.MainModule module = getModule();
            GameObject shape = GameObject.CreatePrimitive(type);
            Mesh mesh = shape.GetComponent<MeshFilter>().sharedMesh;
            GameObject.Destroy(shape);
            var psShape = ps.shape;

            // Make PS use the mesh
            psShape.enabled = true;
            psShape.shapeType = ParticleSystemShapeType.Mesh;
            psShape.mesh = mesh;
            psShape.useMeshColors = true; // Not sure if the main 3D settings is in psShape or in module. May be a combo? Also we cant use a Color for a mesh like this

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
