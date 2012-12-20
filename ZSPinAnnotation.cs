/**
 * Source code : https://github.com/nnhubbard/ZSPinAnnotation/blob/master/ZSPinAnnotation.m
 * 
 */

using System;
using System.Drawing;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

namespace Portsmouth
{
	public class ZSPinAnnotation
	{

		public ZSPinAnnotation ()
		{
		}

		public UIImage ImageWithColor(UIColor color){

			// Color Ball
			UIImage img = new UIImage(Config.PIN_COLOR);
			
			// begin a new image context, to draw our colored image onto
			UIGraphics.BeginImageContextWithOptions(img.Size, false, UIScreen.MainScreen.Scale);

			// get a reference to that context we created
			CGContext context = UIGraphics.GetCurrentContext();

			// set the fill color
			color.SetFill();

			// translate/flip the graphics context (for transforming from CG* coords to UI* coords
			context.TranslateCTM(0, img.Size.Height);
			context.ScaleCTM(1.0f, -1.0f);

			// set the blend mode, and the original image
			context.SetBlendMode(CGBlendMode.Normal);
			RectangleF rect = new RectangleF(0, 0, img.Size.Width, img.Size.Height);
			context.DrawImage(rect, img.CGImage);

			// set a mask that matches the shape of the image
			context.ClipToMask(rect, img.CGImage);
			context.AddRect(rect);
			context.DrawPath(CGPathDrawingMode.Fill);
			
			// generate a new UIImage from the graphics context we drew onto
			UIImage coloredImg = UIGraphics.GetImageFromCurrentImageContext();

			// End
			UIGraphics.EndImageContext();

			return coloredImg;
			
		}

		public UIImage PinAnnotationWithColor(UIColor color){
			// Build the colored ball
			UIImage coloredImg = this.ImageWithColor(color);

			// Shading
			UIImage shading = UIImage.FromFile(Config.PIN_SHADING);

			// Annotation Pin
			UIImage stick = UIImage.FromFile(Config.PIN_STICK);

			// Start new graphcs context
			UIGraphics.BeginImageContextWithOptions(stick.Size, false, UIScreen.MainScreen.Scale);
		
			RectangleF rectFull = new RectangleF(0, 0, stick.Size.Width, stick.Size.Height);

			// Draw Stick
			coloredImg.DrawAsPatternInRect(rectFull);
			//[coloredImg drawInRect:rectFull];
			
			// Draw Shading
			//[shading drawInRect:rectFull];
			shading.DrawAsPatternInRect(rectFull);

			// Draw Stick
			//[stick drawInRect:rectFull];
			stick.DrawAsPatternInRect(rectFull);

			//UIImage *pinImage = UIGraphicsGetImageFromCurrentImageContext();
			UIImage pinImage = UIGraphics.GetImageFromCurrentImageContext();

			// End
			//UIGraphicsEndImageContext();
			UIGraphics.EndImageContext();

			//return the image
			return pinImage;		
		}
	}
}

