using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace SharpSpecs.UI
{
    public class AnimatedGif : Image
    {

        public int FrameIndex
        {
            get { return (int)GetValue(FrameIndexProperty); }
            set { SetValue(FrameIndexProperty, value); }
        }

        public static readonly DependencyProperty FrameIndexProperty =
            DependencyProperty.Register("FrameIndex", typeof(int), typeof(AnimatedGif), new UIPropertyMetadata(0, ChangingFrameIndex));

        static void ChangingFrameIndex(DependencyObject obj, DependencyPropertyChangedEventArgs ev)
        {
            AnimatedGif ob = obj as AnimatedGif;
            ob.Source = ob.gf.Frames[(int)ev.NewValue];
            ob.InvalidateVisual();
        }
        GifBitmapDecoder gf;
        Int32Animation anim;
        public string ImagePath
        {
            set
            {
                SetValue(ImagePathProperty, value);
            }
        }
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register("ImagePath", typeof(string), typeof(AnimatedGif), new UIPropertyMetadata(string.Empty, ImagePathPropertyChanged));

        private static void ImagePathPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AnimatedGif ob = d as AnimatedGif;
            ob.gf = new GifBitmapDecoder(new Uri(e.NewValue.ToString(), UriKind.Relative), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            ob.anim = new Int32Animation(0, ob.gf.Frames.Count - 1, new Duration(new TimeSpan(0, 0, 0, ob.gf.Frames.Count / 10, (int)((ob.gf.Frames.Count / 10.0 - ob.gf.Frames.Count / 10) * 1000))));
            ob.anim.RepeatBehavior = RepeatBehavior.Forever;
            ob.Source = ob.gf.Frames[0];
        }

        bool animationIsWorking = false;

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            if (!animationIsWorking)
            {
                BeginAnimation(FrameIndexProperty, anim);
                animationIsWorking = true;
            }
        }
    }

}
