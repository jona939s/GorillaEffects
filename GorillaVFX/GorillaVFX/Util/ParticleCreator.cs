using UnityEngine;

namespace GorillaVFX.Util
{
    internal static class ParticleCreator
    {
        internal static void BasicParticle(Vector3 Location, bool loop, float duration, float lifetime, float lifetimeMultiplier, float size, float speed, float emmission, int max, Color color)
        {
            (GameObject obj, ParticleSystem ps) obj = BasicParticle(loop, duration, lifetime, lifetimeMultiplier, size, speed, emmission, max, color);
            obj.obj.transform.position = Location;
            obj.ps.Play();
        }
        /// <summary>
        /// Creates a basic 2D particle system
        /// </summary>
        /// <param name="loop">Should loop</param>
        /// <param name="duration">How long the particle system should play if not looping (if looping just set this to 1)</param>
        /// <param name="lifetime">How long particles live</param>
        /// <param name="lifetimeMultiplier"></param>
        /// <param name="size">Particle size</param>
        /// <param name="speed">Particle move speed</param>
        /// <param name="emmission">The amount of particles to spawn</param>
        /// <param name="max">Max amount of particles at once</param>
        /// <param name="color">The color the basic particle should have</param>
        /// <returns></returns>
        internal static (GameObject obj, ParticleSystem ps) BasicParticle(
            bool loop,
            float duration,
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
            Sprite defSprite = Sprite.Create(new Texture2D(1, 1), new Rect(0, 0, 1, 1), Vector2.one / 2);

            eModule.rateOverTime = emmission;

            module.loop = loop;
            module.duration = duration;
            module.startLifetime = lifetime;
            module.startLifetimeMultiplier = lifetimeMultiplier;
            module.startSize = size;
            module.startSpeed = speed;
            module.maxParticles = max * (int)Main.ParticleMultiplier.Value;
            module.startColor = color;
            module.stopAction = ParticleSystemStopAction.Destroy; // Destroyes the particle system once it is no longer needed (Should take the GO with it)

            sModule.shapeType = ParticleSystemShapeType.Sprite;
            sModule.sprite = defSprite;

            return (go, ps);
        }

        /// <summary>
        /// Creates a basic 3D particle system
        /// </summary>
        /// <param name="type">Takes a UnityEngine PrimitiveType for the shape the particles are allowed to be emitted in</param>
        /// <param name="shapeT">Takes a ParticleSystemShapeType to get the mesh shape that the 3D particles should be in</param>
        /// <param name="loop">Should loop</param>
        /// <param name="duration">How long the particle system should play if not looping (if looping just set this to 1)</param>
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
            float duration,
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
            module.duration = duration;
            module.startLifetime = lifetime;
            module.startLifetimeMultiplier = lifetimeMultiplier;
            module.startSize = size;
            module.startSpeed = speed;
            module.maxParticles = max;
            module.stopAction = ParticleSystemStopAction.Destroy; // Destroyes the particle system once it is no longer needed (Should take the GO with it)

            return go;
        }

        internal static Mesh getMesh(PrimitiveType type)
        {
            GameObject obj = GameObject.CreatePrimitive(type);

            Mesh shapeMesh = obj.GetComponent<MeshFilter>().mesh;

            GameObject.Destroy(obj);

            return shapeMesh;
        }

        internal static Mesh getMesh(GameObject meshObj) // Method overloading :D This way we can use one function name and get primitives and custom meshes
        {
            if (meshObj.TryGetComponent(out MeshFilter filter))
            {
                Mesh mesh = filter.mesh;
                GameObject.Destroy(meshObj);
                return mesh;
            }
            else
            {
                "COULD NOT GET MESH FROM GAME OBJECT!".Log(BepInEx.Logging.LogLevel.Error);
                return null;
            }
        }
    }
}
