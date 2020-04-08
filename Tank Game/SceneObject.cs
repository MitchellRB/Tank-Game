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

        public List<SceneObject> Children { get => children; }

        public SceneObject Parent { get => parent; }

        protected Vector2 globalPosition = new Vector2();

        public Vector2 GlobalPosition { get => globalPosition; }

        protected Vector2 localPosition = new Vector2();

        protected float globalRotation;

        public float GlobalRotation { get => globalRotation; }

        protected float localRotation;

        public float LocalRotation { get => localRotation; }

        public readonly string name;

        public Box localBox = new Box();

        public Box globalBox = new Box();

        public SceneObject()
        {

        }

        public SceneObject(string _name)
        {
            name = _name;
        }

        public SceneObject AddChild(SceneObject child)
        {
            children.Add(child);
            child.parent = this;
            return child;
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
            if (parent != null)
            {
                globalPosition = localPosition + parent.globalPosition;
                globalRotation = localRotation + parent.globalRotation;
            }
            else
            {
                globalPosition = localPosition;
                globalRotation = localRotation;
            }

                globalBox.min = localBox.min + globalPosition;
                globalBox.max = localBox.max + globalPosition;

            foreach (var child in children)
            {
                child.UpdateTransform();
            }
        }

        public void SetPosition(float x, float y)
        {
            localPosition.x = x;
            localPosition.y = y;
            UpdateTransform();
        }

        public void Translate(float x, float y)
        {
            localPosition.x += x;
            localPosition.y += y;
            UpdateTransform();
        }

        public void SetRotate(float rotation)
        {
            localRotation = rotation;
            UpdateTransform();
        }

        public void Rotate(float rotation)
        {
            localRotation += rotation;   
            UpdateTransform();
        }

        public void MoveForeward(float distance)
        {
            Translate((float)Math.Cos(Conversions.DegToRad(localRotation - 90)) * distance, (float)Math.Sin(Conversions.DegToRad(localRotation - 90)) * distance);
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
            if (localRotation >= 360)
            {
                localRotation -= 360;
            }

            if (localRotation < 0)
            {
                localRotation += 360;
            }

            if (globalRotation >= 360)
            {
                globalRotation -= 360;
            }

            if (globalRotation < 0)
            {
                globalRotation += 360;
            }

            UpdateTransform();
        }

        public void Update()
        {
            OnUpdate();

            for (int i = 0; i < children.Count; i++)
            {
                children[i].Update();
            }
        }

        public virtual void OnDraw()
        {
            if (Program.debug)
            {
                DrawRectangle((int)globalPosition.x - 2, (int)globalPosition.y - 2, 5, 5, rl.Color.RED);
                DrawRectangleLines((int)globalBox.min.x, (int)globalBox.min.y, (int)globalBox.max.x - (int)globalBox.min.x, (int)globalBox.max.y - (int)globalBox.min.y,rl.Color.RED);
            }
        }

        public void Draw()
        {
            OnDraw();

            foreach (var child in children)
            {
                child.Draw();
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
