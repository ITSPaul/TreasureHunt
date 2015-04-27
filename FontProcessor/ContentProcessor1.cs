using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

// TODO: replace these with the processor input and output types.
using TInput = System.String;
using TOutput = System.String;

namespace FontProcessor
{
    /// <summary>
    /// This class will be instantiated by the XNA Framework Content Pipeline
    /// to apply custom processing to content data, converting an object of
    /// type TInput to TOutput. The input and output types may be the same if
    /// the processor wishes to alter data without changing its type.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    ///
    /// TODO: change the ContentProcessor attribute to specify the correct
    /// display name for this processor.
    /// </summary>
    //[ContentProcessor(DisplayName = "FontProcessor.ContentProcessor1")]
    //public class ContentProcessor1 : ContentProcessor<TInput, TOutput>
    //{
    //    public override TOutput Process(TInput input, ContentProcessorContext context)
    //    {
    //        // TODO: process the input object, and return the modified data.
    //        throw new NotImplementedException();
    //    }
    //}

    // Pre-multiplied alpha font content processor 
    [ContentProcessor(DisplayName = "Pre-Multiplied Alpha Font Texture Processor")]
    class PremultipliedAlphaFontTextureProcessor : FontTextureProcessor
    {
        public override SpriteFontContent Process(Texture2DContent p_Input, ContentProcessorContext p_Context)
        {
            p_Input.ConvertBitmapType(typeof(PixelBitmapContent<Color>));

            foreach (MipmapChain mipChain in p_Input.Faces)
            {
                foreach (PixelBitmapContent<Color> bitmap in mipChain)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            Color c = bitmap.GetPixel(x, y);

                            c.R = (byte)(c.R * c.A / 255);
                            c.G = (byte)(c.G * c.A / 255);
                            c.B = (byte)(c.B * c.A / 255);

                            bitmap.SetPixel(x, y, c);
                        }
                    }
                }
            }

            return base.Process(p_Input, p_Context);
        }
    } 
}