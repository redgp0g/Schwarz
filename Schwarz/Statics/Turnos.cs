namespace Schwarz.Statics
{
    public class Turnos
    {
        public const string ADM = "ADM";
        public const string Turno1 = "1° Turno";
        public const string Turno2 = "2° Turno";
        public const string Turno3 = "3° Turno";

        public static string[] GetTurnos()
        {
            return new string[] { ADM, Turno1, Turno2, Turno3 };
        }
    }
}
