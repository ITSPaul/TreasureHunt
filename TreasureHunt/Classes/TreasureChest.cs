using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace TreasureHunt.Classes
{
    class TreasureChest :SimpleSprite
    {
        public LinkedList<Collectable> Collected = new LinkedList<Collectable>();
        public int score = 0;
        public bool emptied = false;

        public TreasureChest(Game g, Texture2D tx, Vector2 startPos) :base(g,tx,startPos)
        {


        }

        public void insert(Collectable c)
        {
            if(Collected.Count == 0)
                Collected.AddFirst(c);
            else
            {
                LinkedListNode<Collectable> current = Collected.First;
                while (current != null && c.value <= current.Value.value)
                    current = current.Next;
                if (current == null)
                    Collected.AddLast(c);
                else 
                    Collected.AddBefore(current,c);

            }
        }

        internal void Empty()
        {
            if (Collected.Count > 0)
            {
                while (Collected.Count > 0)
                {
                    Collectable c = Collected.First();
                    score += c.value;
                    new TextEffect(Game, c.value.ToString(),
                        this.Position + new Vector2(this.Image.Width / 2, this.Image.Height / 2)
                        + new Vector2(Utility.NextRandom(0, this.Image.Width),
                            Utility.NextRandom(0, this.Image.Height)));
                    Collected.RemoveFirst();
                    c.Dispose();
                }
                emptied = true;
            }

        }
    }
}
