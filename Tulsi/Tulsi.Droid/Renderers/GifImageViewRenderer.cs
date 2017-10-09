﻿using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Tulsi.Controls;
using Tulsi.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GifImage), typeof(GifImageViewRenderer))]
namespace Tulsi.Droid.Renderers {
    public sealed class GifImageViewRenderer : ImageRenderer {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

        Felipecsl.GifImageViewLibrary.GifImageView gif;
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e) {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
                return;

            gif = new Felipecsl.GifImageViewLibrary.GifImageView(Forms.Context);

            SetNativeControl(gif);
        }

        static async Task<byte[]> GetBytesFromStreamAsync(Stream stream) {
            using (stream) {
                if (stream == null || stream.Length == 0)
                    return null;

                var bytes = new byte[stream.Length];
                if (await stream.ReadAsync(bytes, 0, (int)stream.Length) > 0)
                    return bytes;
            }

            return null;
        }

        bool loaded;
        protected override async void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            byte[] bytes = null;

            var s = Element.Source;
            if (s is UriImageSource) {
                using (var client = new HttpClient())
                    bytes = await client.GetByteArrayAsync(((UriImageSource)s).Uri);
            } else if (s is StreamImageSource) {
                bytes = await GetBytesFromStreamAsync(await ((StreamImageSource)s).Stream(default(CancellationToken)));
            } else if (s is FileImageSource) {
                bytes = await GetBytesFromStreamAsync(File.OpenRead(((FileImageSource)s).File));
            }

            if (bytes == null)
                return;

            try {
                gif.StopAnimation();
                gif.SetBytes(bytes);
                gif.StartAnimation();
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine("Unable to load gif: " + ex.Message);
            }
        }
    }
}