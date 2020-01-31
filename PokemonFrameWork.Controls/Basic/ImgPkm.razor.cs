using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonFrameWork.Controls.Basic
{
    public class ImgPkmBase:ComponentBase
    {
        [Parameter] public PokemonGBAFrameWork.PokemonCompleto Pokemon { get; set; }
        [Parameter] public bool IsFrontalPic { get; set; } = true;
        [Parameter] public int FramePic { get; set; } = 0;//el primero esta por defecto
        [Parameter] public EventCallBack Click { get; set; }
        //[Parameter] public float Height { get; set; }
        //[Parameter] public float Width { get; set; }

       protected Bitmap GetImg()
        {
            PokemonGBAFrameWork.BloqueImagen img;

            if (IsFrontalPic)
            {
                img = Pokemon.Sprites.SpritesFrontales.Sprites[FramePic];
            }
            else
            {
                img = Pokemon.Sprites.SpritesTraseros.Sprites[FramePic];
            }

            return img;
        }

        protected override void OnParameterSet()
        {
            if (Pokemon != null)
            {
                if (IsFrontalPic && FramePic >= Pokemon.Sprites.SpritesFrontales.Sprites.Count)
                    FramePic = Pokemon.Sprites.SpritesFrontales.Sprites.Count - 1;
                else if (!IsFrontalPic && FramePic >= Pokemon.Sprites.SpritesTraseros.Sprites.Count)
                    FramePic = Pokemon.Sprites.SpritesTraseros.Sprites.Count - 1;

                if (FramePic < 0)
                    FramePic = 0;
            }
        }
    }
}
