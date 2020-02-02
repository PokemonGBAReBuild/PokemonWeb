using Microsoft.AspNetCore.Components;
using PokemonGBAFrameWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonFrameWork.Controls.Complex
{
    public class PkmListBase : ComponentBase
    {
        int index;

        [Parameter] public List<PokemonCompleto> List { get; set; }
        [Parameter] 
        public int Index 
        { get => index;
          set 
            {
                if (value < 0) Index = 0;
                else if (value > List.Count - 1) Index = List.Count - 1;
                else Index = value;
            } 
        }
        [Parameter] public bool ChangeIndexOnScroll { get; set; } = true;
        [Parameter] public EventCallback OnClick { get; set; }
        [Parameter] public EventCallback OnDobleClick { get; set; }
        [Parameter] public EventCallback OnContextMenu { get; set; }

        [Parameter] public EventCallback OnMouseOver { get; set; }

        [Parameter] public int TotalPrint { get; set; } = -1;
        [Parameter] public bool EsCircular { get; set; } = true;
        [Parameter] public bool Repetir { get; set; } = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (List == null)
                List = new List<PokemonCompleto>();
        }


        public void Next(int indexNextPosition = 1)
        {
            bool atras = Index < 0;
            int index = Index;
            index += indexNextPosition;

            if (EsCircular)
            {
                if (atras)
                {
                    index *= -1;

                }
                index %= List.Count;
                if (atras)
                    index = List.Count - index;
            }
            Index = index;

        }
        public void Previus(int indexPreviusPosition = 1)
        {
            Next(indexPreviusPosition * -1);
        }

        protected List<PokemonGBAFrameWork.PokemonCompleto> GetPokemon()
        {
            List<PokemonCompleto> lstPokemon = new List<PokemonCompleto>();
            int i = EsCircular ? List.Count / 2 : 0;
            if (TotalPrint != 0)
            {
                if (TotalPrint < 0)
                {

                    for (int j = 0; j < List.Count; j++, i++)
                    {
                        lstPokemon.Add(List[(Index + i) % List.Count]);
                    }
                }
                else
                {

                    for (int j = 0; j < TotalPrint && (Repetir || j < List.Count); j++)
                    {
                        lstPokemon.Add(List[(Index + j + i) % List.Count]);
                    }

                }


            }


            return lstPokemon;

        }

    }
}
