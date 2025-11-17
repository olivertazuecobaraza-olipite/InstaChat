using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace WhatsAppRealtime.Models.Static;

public class Utiles
{

    #region String

    // Ordenar y concatenar Nombres de usuario nombre-nombre
    public static string OrdenarConcatenar(string userSender, string userReceiver)
    {
        int comparacion = string.Compare(userSender, userReceiver, StringComparison.OrdinalIgnoreCase);
        return comparacion < 0 ? userSender + "-"+ userReceiver : userReceiver + "-"+userSender;
    }
    
    // serparar emails
    public static string SeparaUser(string username)
    {
        return username.Split("@")[0].Replace(".", "");
    }

    #endregion
    
    #region AlertasShell
    
    // exito
    public static async Task AlertasBuenaShell(string mensaje)
    {
        await Shell.Current.DisplayAlert("Exito", mensaje, "Ok");
    }
    // malo
    public static async Task AlertasMalasShell(string mensaje)
    {
        await Shell.Current.DisplayAlert("Error", mensaje, "Ok");
    }
    // pregunta
    public static async Task<bool> AlertaPreguntaShell(string mensaje)
    {
        return await Shell.Current.DisplayAlert("Elige", mensaje, "Si", "No");
    }
    // toast 
    public static void CrearToast(string mensaje)
    {
        var toast = Toast.Make(mensaje, ToastDuration.Long);
        toast.Show();
    }
    
    #endregion
    
    #region AlertasApp

    // exito
    public static async Task AlertasBuena(string mensaje)
    {
        await Application.Current!.Windows[0].Page!.DisplayAlert("Exito", mensaje, "Ok");
    }
    // malo
    public static async Task AlertasMalas(string mensaje)
    {
        await Application.Current!.Windows[0].Page!.DisplayAlert("Error", mensaje, "Ok");
    }
    // pregunta
    public static async Task<bool> AlertaPregunta(string mensaje)
    {
        return await Application.Current!.Windows[0].Page!.DisplayAlert("Elige", mensaje, "Si", "No");
    }

    // comprobar que se ha introducido valores y que las contraseñas coinciden
    public static bool TestPassword(string email,string password, string confirmPassword)
    {
        var r = false;
        if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password) || !string.IsNullOrWhiteSpace(confirmPassword))
        {
            if (password.Equals(confirmPassword))
            {
                r = true;
            }
        }
        return r;
    }
    #endregion
}