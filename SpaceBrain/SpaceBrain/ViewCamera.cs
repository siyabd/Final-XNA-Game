using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Text;


namespace SpaceBrain
{
    class ViewCamera
    {

        public Matrix Transform;
        Viewport view;
        Vector2 center;

        public ViewCamera(Viewport newView)
        {
            view = newView;
        }
        public void Update(GameTime game, Game1 go)
        {
            center = new Vector2(go.camera.X, go.camera.Y);
            Transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}
