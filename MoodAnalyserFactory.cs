using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyser
{
    /// <summary>
    /// defined mood analyser factory class
    /// </summary>
   public class MoodAnalyserFactory
   {
        /// <summary>
        /// defining mood analyser factory method with parameters
        /// </summary>
        /// <param name="className"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static object Factory(string className,params object[] para)
        {
            try
            {
                Type t = Type.GetType("NUnitMoodAnalyser" + className);
                if (t != null)
                {
                    object obj = Activator.CreateInstance(t, para);
                    return obj;
                }
                throw new MoodAnalysisException(MoodAnalysisException.TypeofException.No_Such_Class, "No Such Clas");
            }
            catch(MoodAnalysisException ex)
            {
                return ex.message;
            }

        }
        
   }
}
