using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections;

namespace HaarbyTennis.Utilities
{
    public static class Shared
    {


        public const string FORMAT_DATE = "dd-MM-yyyy";
        public const string FORMAT_TIME = "HH:mm";
        public const string FORMAT_DATE_TIME = FORMAT_DATE + " " + FORMAT_TIME;
        /// <summary>
        /// Henter en dato ud af en string.
        /// </summary>
        /// <param name="dateString">Tekststringen der skal parses</param>
        /// <param name="defaultDate">Hvis det ikke lykkedes skal denne dato benyttes</param>
        /// <returns>Gyldig dato værdi</returns>
        internal static DateTime ParseDate(string dateString, DateTime defaultDate)
        {
            DateTime result;

            DateTime resultingDate;
            System.Globalization.CultureInfo daDK = new System.Globalization.CultureInfo("da-DK");

            if (DateTime.TryParseExact(dateString, FORMAT_DATE, daDK, System.Globalization.DateTimeStyles.None, out resultingDate))
            {
                result = resultingDate;
            }
            else
            {
                result = defaultDate;
            }
            return result;
        }

        /// <summary>
        /// Check om tidspunkt findes på formen HH:mm
        /// </summary>
        /// <param name="value">Tekst string der skal testes.</param>
        /// <returns>True/False</returns>
        internal static bool IsValidTime(string value)
        {
            var checktime = new Regex(@"(([0-1][0-9])|([2][0-3])):([0-5][0-9])");

            return checktime.IsMatch(value);
        }

        /// <summary>
        /// Konverterer tids string til dato-tid
        /// </summary>
        /// <param name="value">Tid på formatet HH:mm.</param>
        /// <returns>Dato værdi.</returns>
        internal static DateTime ParseTime(string value)
        {
            return DateTime.Parse("1/1/0001 " + value);
        }

       

        /// <summary>
        /// Begrændser længden på en tekst.
        /// </summary>
        /// <param name="value">Den originale tekst</param>
        /// <param name="maxLengt">Maisimal længde</param>
        /// <returns>Den returnerede tekst</returns>
        internal static string LimitText(string value, int maxLengt)
        {
            string result = value;

            if (value.Length > maxLengt)
            {
                result = value.Remove(maxLengt) + "...";
            }

            return result;
        }

        /// <summary>
        /// Beregner ugenummer efter dansk standard
        /// </summary>
        /// <param name="dtPassed"></param>
        /// <returns>Ugenummer som tal</returns>
        public static int GetWeekNumber(DateTime dtPassed)
        {
            //CultureInfo ciCurr = CultureInfo.CurrentCulture;
            CultureInfo ciCurr = new CultureInfo("da");
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        /// <summary>
        /// Checker om en email er gyldig.
        /// </summary>
        /// <param name="email">Email der skal testes.</param>
        /// <returns>Ja/Nej</returns>
        public static bool IsEmail(string email)
        {
            //Denne regex var for restriktiv. Kunne ikke accepctere mail-adressen: tbe@c.dk
            return Regex.IsMatch(email, "^(([A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+(\\.[A-Za-z0-9!#$%&'*+/=?^_`{|}~-]+)*)|(\"([ !#-\\[\\]-~]|\\\\[ -~])*\"))@((([a-zA-Z0-9][a-zA-Z0-9-]*[a-zA-Z0-9])(\\.[a-zA-Z0-9][a-zA-Z0-9-]*[a-zA-Z0-9])*)|(\\[[0-9]{1,3}(\\.[0-9]{1,3}){3}\\])|(\\[IPv6:[0-9a-fA-F:]+(:\\[[0-9]{1,3}(\\.[0-9]{1,3}){3}\\])?\\]))$");
            //return Regex.IsMatch(email, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            //                            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            //                            RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        /// <summary>
        /// Formatterer tekst pænt med stort begyndelsesbogstav.
        /// </summary>
        /// <param name="value">Tekst der skal formatteres</param>
        /// <returns>Den formatterede tekst.</returns>
        public static string ProperCase(string value)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(value);        
        }

        public static string IndsaetCPRSeparator(string input)
        {
            if (ErCPRGyldig(input) && !input.Contains("-"))
            {
                return input.Substring(0, 6) + "-" + input.Substring(6, 4);
            }
            else
            {
                return input;
            }
        }
        public static bool ErCPRGyldig(string input)
        {
            input = input.Replace("-", string.Empty);

            if (input.Length != 10)
            {
                return false;
            }

            // Datoerne 010165 og 010166 overholder ikke altid modulus 11,
            // hvorved tjek ikke skal udføres på disse (KMD-nyt nr. 108) /SJG
            string ddmmYY = input.Substring(0, 6);

            if (ddmmYY.Equals("010165") || ddmmYY.Equals("010166"))
            {
                return true;
            }

            ArrayList cifre = new ArrayList();

            int chksum = 0;

            for (int i = 0; i < 10; i++)
            {
                cifre.Add(int.Parse(input.Substring(i, 1)));
            }

            for (int i = 1; i < 4; i++)
            {
                chksum = chksum + (5 - i) * (int)cifre[i - 1];
            }

            for (int i = 4; i < 11; i++)
            {
                chksum = chksum + (11 - i) * (int)cifre[i - 1];
            }

            return (chksum % 11 == 0) ? true : false;
        }
               
    }
}