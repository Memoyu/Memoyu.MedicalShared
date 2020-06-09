using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalShredApp.Services
{
    public interface IToast
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
