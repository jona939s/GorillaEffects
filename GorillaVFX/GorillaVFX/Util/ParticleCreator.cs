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

        internal static ParticleSystem BasicParticle( bool loop, float lifetime, float lifetimeMultiplier, float size, float speed, Color color)
        {
            ParticleSystem.MainModule module = getModule();

            module.loop = loop;
            module.startLifetime = lifetime;
            module.startLifetimeMultiplier = lifetimeMultiplier;
            module.startSize = size;
            module.startSpeed = speed;
            module.startColor = color;

            return ps;
        }

        internal static ParticleSystem Basic3DParticle(PrimitiveType type, bool loop, float lifetime, float lifetimeMultiplier, float size, float speed, Color color)
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

            // PS settings
            module.loop = loop;
            module.startLifetime = lifetime;
            module.startLifetimeMultiplier = lifetimeMultiplier;
            module.startSize = size;
            module.startSpeed = speed;
            module.startColor = color;

            return ps;
        }
    }
}
