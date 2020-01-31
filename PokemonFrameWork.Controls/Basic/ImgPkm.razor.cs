using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Gabriel.Cat.Extension;
using Microsoft.AspNetCore.Components;

namespace PokemonFrameWork.Controls.Basic
{
    public class ImgPkmBase:ComponentBase
    {
        [Parameter] public PokemonGBAFrameWork.PokemonCompleto Pokemon { get; set; }
        [Parameter] public bool IsFrontalPic { get; set; } = true;
        [Parameter] public int FramePic { get; set; } = 0;//el primero esta por defecto
        [Parameter] public EventCallback OnClick { get; set; }

        [Parameter] public EventCallback OnDobleClick { get; set; }
        [Parameter] public EventCallback OnContextMenu { get; set; }
        [Parameter] public EventCallback OnMouseOver { get; set; }
        public string ImgActual
        {
            get
            {
                string url;
                PokemonGBAFrameWork.BloqueImagen img;
                if (Pokemon == null)
                    url = "missigno.png";
                else
                {
                    if (IsFrontalPic)
                    {
                        img = Pokemon.Sprites.SpritesFrontales.Sprites[FramePic];
                    }
                    else
                    {
                        img = Pokemon.Sprites.SpritesTraseros.Sprites[FramePic];
                    }
                    //creo una URL para el Bitmap
                    url = ((Bitmap)img).GetUrl().Result;
                }

                return url;
            }
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
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
