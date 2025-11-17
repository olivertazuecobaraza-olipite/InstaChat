using Firebase.Auth;
using Firebase.Auth.Providers;

namespace WhatsAppRealtime.Services.Firebase;

public class FireBaseAuth
{
    #region Instace
    
    public FirebaseAuthClient Instance = new FirebaseAuthClient(new FirebaseAuthConfig
        {
            ApiKey = "AIzaSyCieV0jgiuAdEgGg757M5RrDX5BCaH6Npw",
            AuthDomain = "whatsappmauioliver.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider()
            }
        }); 
    
    #endregion
    
    #region Constructor

    public FireBaseAuth(){}

    #endregion
    
    #region Metodos

    // iniciar sesion con Email y password
    public async Task<bool> IniciarSesion(string email, string password)
    {
        var s = false;
        try
        {
            await Instance.SignInWithEmailAndPasswordAsync(email, password);
            s = true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error, FireBaseAuth-IniciarSesion: " + e.Message);
        }
        return s;
    }
    
    // registrar

    public bool RegistrarUsuario(string email, string password)
    {
        var s = false;
        try
        {
            Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            s = true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error, FireBaseAuth-RegistrarUsuario: " + e.Message);
        }
        return s;
    }
    
    // Cerrar sesion
    public bool CerrarSesion()
    {
        var s = false;
        try
        {
            Instance.SignOut();
            s = true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error, FireBaseAuth-CerrarSesion: " + e.Message);
        }
        return s;
    }

    public string ObtenerEmail()
    {
        return Instance.User == null ? "Usuario logueado null" : Instance.User.Info.Email;
    }
    #endregion
    
}