using System.Media;
using System.Threading;

namespace ITSolution.Framework.Util
{
    public class SoundUtil
    {
        /// <summary>
        /// Alerta de atenção
        /// Gets the sound associated with the Beep program event in the current Windows sound scheme.
        /// </summary>
        public static void Beep()
        {
            SystemSounds.Beep.Play();
        }
        /// <summary>
        /// Alerta de tarefa
        /// Gets the sound associated with the Asterisk program event in the current Windows sound scheme.
        /// </summary>
        public static void Asterisk()
        {
            SystemSounds.Asterisk.Play();
        }

        /// <summary>
        /// Parecido com o alerta de mensagem recebida do windows live
        /// Gets the sound associated with the Exclamation program event in the current Windows sound scheme.
        /// </summary>
        public static void Exclamation()
        {
            SystemSounds.Exclamation.Play();
        }

        /// <summary>
        /// Alerta de erro "Pare"
        /// Gets the sound associated with the Hand program event in the current Windows sound scheme.
        /// </summary>
        public static void Hand()
        {
            SystemSounds.Hand.Play();
        }


        /// <summary>
        /// Não faz nada
        /// Gets the sound associated with the Question program event in the current Windows sound scheme.
        /// </summary>
        public static void Question()
        {
            SystemSounds.Question.Play();
        }


        /// <summary>
        /// Alerta duplo de tarefa
        /// Gets the sound associated with the Asterisk program event in the current Windows sound scheme.
        /// </summary>
        public static void DoubleAsterik()
        {
            SoundUtil.Asterisk();
            Thread.Sleep(500);
            SoundUtil.Asterisk();
        }

        /// <summary>
        /// Alerta duplo de atenção
        /// Gets the sound associated with the Beep program event in the current Windows sound scheme.
        /// </summary>
        public static void DoubleBeep()
        {
            SoundUtil.Beep();
            Thread.Sleep(500);
            SoundUtil.Beep();
        }

    }
}
