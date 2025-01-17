﻿using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeeMind.Controls.Native
{
    public class BorderlessEntry : MauiControls.Entry
    {
        public BorderlessEntry()
        {
        }

        public static void Configure()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("BorderlessEntry", (handler, view) =>
            {
                if (view is BorderlessEntry)
                {
#if ANDROID
                    handler.PlatformView.SetSelectAllOnFocus(true);
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    handler.PlatformView.FocusChange += (s, e) =>
                    {
                        if (!e.HasFocus &&
                            Microsoft.Maui.ApplicationModel.Platform.CurrentActivity != null)
                            Microsoft.Maui.ApplicationModel.Platform.CurrentActivity.HideKeyboard(handler.PlatformView);
                    };
                    //handler.PlatformView.SetHighlightColor(Android.Graphics.Color.Argb(255, 0, 255, 209));
                    //handler.PlatformView.SetHintTextColor(Android.Graphics.Color.Argb(255, 0, 255, 209));
                    //handler.PlatformView.TextCursorDrawable?.SetTint(Android.Graphics.Color.Argb(255, 0, 255, 209));
                    //handler.PlatformView.TextSelectHandle?.SetTint(Android.Graphics.Color.Argb(255, 0, 255, 209));
                    //handler.PlatformView.TextSelectHandleLeft?.SetTint(Android.Graphics.Color.Argb(255, 0, 255, 209));
                    //handler.PlatformView.TextSelectHandleRight?.SetTint(Android.Graphics.Color.Argb(255, 0, 255, 209));


#elif IOS || MACCATALYST
                    handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
                    handler.PlatformView.EditingDidBegin += (s, e) =>
                    {
                        handler.PlatformView.PerformSelector(new ObjCRuntime.Selector("selectAll"), null, 0.0f);
                    };
#elif WINDOWS
                    handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
                    handler.PlatformView.Background = null;
                    
                    handler.PlatformView.GotFocus += (s, e) =>
                    {
                        handler.PlatformView.SelectAll();
                    };
#endif
                }
            });
        }
    }
}

namespace KeeMind.Controls
{
    [Scaffold(typeof(Native.BorderlessEntry))]
    public partial class BorderlessEntry { }
}

namespace KeeMind.Controls.Native
{
    public class TrasparentContentPage : MauiControls.ContentPage
    {
        public static void Configure()
        {
            Microsoft.Maui.Handlers.PageHandler.Mapper.AppendToMapping("TrasparentContentPage", (handler, view) =>
            {
                if (view is TrasparentContentPage)
                {
#if ANDROID
                    //handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Red);
                    

#elif IOS || MACCATALYST
#elif WINDOWS
#endif
                }
            });
        }
    }
}

namespace KeeMind.Controls
{
    [Scaffold(typeof(Native.TrasparentContentPage))]
    public partial class TrasparentContentPage { }
}


