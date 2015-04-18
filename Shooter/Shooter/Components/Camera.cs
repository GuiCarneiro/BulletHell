using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Components
{
    public class Camera
    {
        protected float         zoom; // Camera Zoom
        private Matrix           transform; // Matrix Transform
        private Vector2          pos; // Camera Position
        protected float         rotation; // Camera Rotation
        Viewport viewport;
 
        public Camera()
        {
            zoom = 1.0f;
            rotation = 0.0f;
            pos = new Vector2(Globals.GameWidth / 2, Globals.GameHeight/2);
        }

        public float Zoom
        {
            get { return zoom; }
            set { zoom = value; if ( zoom < 0.1f) zoom = 0.1f; } // Negative zoom will flip image
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public Matrix Transform
        {
            get { return transform; }
        }


        public void Update()
        {
            transform = Matrix.CreateTranslation(new Vector3(-pos.X, -pos.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
                                         Matrix.CreateTranslation(new Vector3(viewport.Width * 0.5f, viewport.Height * 0.5f, 0));
        }
        public void setGraphics(Viewport nViewport)
        {
            viewport = nViewport;
        }
    }
}
