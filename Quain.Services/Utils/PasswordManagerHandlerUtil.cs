namespace Quain.Services.Utils
{
	using Microsoft.AspNetCore.Identity;

	public class PasswordManagerHandlerUtil
	{
		public static IEnumerable<string> GetErrors(IEnumerable<IdentityError> errors)
			=> errors.Select(e => GetTranslatedMessage(e.Code));

		public static string GetTranslatedMessage(string errorCode)
		{
			switch (errorCode)
			{
				case "PasswordRequiresNonAlphanumeric":
					return "La contraseña debe contener al menos 1 (un) carácter espécial.";
				case "PasswordRequiresDigit":
					return "La contraseña debe contener al menos 1 (un) dígito.";
				case "PasswordRequiresUpper":
					return "La contraseña debe contener al menos 1 (una) mayúscula.";
				default:
					return "No se pudo crear el usuario, intentelo de nuevo.";
			}
		}
	}
}
