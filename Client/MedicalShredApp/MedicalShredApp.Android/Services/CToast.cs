﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MedicalShredApp.Droid.Services;
using MedicalShredApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(CToast))]
namespace MedicalShredApp.Droid.Services
{
    public class CToast : IToast
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}