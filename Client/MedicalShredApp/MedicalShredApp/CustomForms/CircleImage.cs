﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;

namespace MedicalShredApp.CustomForms
{
    [DesignTimeVisible(true)]
    public class CircleImage:Image
    {
        BindableProperty RadiusProperty = BindableProperty.Create("Radius", typeof(float), typeof(CircleImage), (float)12);
        public float Radius
        {
            get => (float)base.GetValue(RadiusProperty);
            set => SetValue(RadiusProperty, value);
        }
    }
}
