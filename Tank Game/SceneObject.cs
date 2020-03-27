using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClasses;
using rl = Raylib;
using static Raylib.Raylib;

namespace Tank_Game
{
    class SceneObject
    {
        protected SceneObject parent = null;
        protected List<SceneObject> children = new List<SceneObject>();

        public SceneObject Parent { get => parent; }

        protected Matrix3 localTransform = new Matrix3();
        protected Matrix3 globalTransform = new Matrix3();

        public Matrix3 LocalTranform { get => localTransform; }
        public Matrix3 GlobalTransform { get => globalTransform; }

        rl.Texture2D texture = new rl.Texture2D();
        rl.Image image = new rl.Image();

        public float Width { get => texture.width; }
        public float Height { get => texture.height; }

        public SceneObject()
        {

        }

        public void AddChild(SceneObject child)
        {
            children.Add(child);
            child.parent = this;
        }

        public void RemoveChild(SceneObject child)
        {
            if (children.Remove(child))
            {
                child.parent = null;
            }
        }

        public int GetChildCount()
        {
            return children.Count;
        }

        public SceneObject GetChild(int index)
        {
            return children[index];
        }

        public void UpdateTransform()
        {
            if (parent == null)
            {
                globalTransform = parent.globalTransform * localTransform;
            }
            else
            {
                globalTransform = localTransform;
            }

            foreach (var child in children)
            {
                child.UpdateTransform();
            }
        }

        public void Load(string path)
        {
            image = LoadImage(path);
            texture = LoadTextureFromImage(image);
        }

        ~SceneObject()
        {
            if (parent != null)
            {
                parent.RemoveChild(this);
            }

            foreach(var so in children)
            {
                so.parent = null;
            }
        }

        public virtual void OnUpdate()
        {

        }

        public void Update()
        {
            OnUpdate();

            foreach (var child in children)
            {
                child.Update();
            }
        }

        public virtual void OnDraw()
        {

        }

        public void Draw()
        {
            OnDraw();

            foreach (var child in children)
            {
                child.Draw();
            }
        }
    }
}
