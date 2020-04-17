using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Mood_Analyser
{
    /// <summary>
    /// MoodAnalyserReflector class.
    /// </summary>
    public class MoodAnalyserReflector
    {
        public static string msg;

        /// <summary>
        /// Factories the specified class name.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <param name="para">The para.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnaylser.MoodAnalysisException">No Such Class</exception>
        public static object Factory(string className)
        {
            try
            {
                Type t = Type.GetType("NUnitMoodAnalyser." + className);
                if (t != null)
                {
                    Object obj = Activator.CreateInstance(t);
                    return obj;
                }
                throw new MoodAnalysisException(MoodAnalysisException.TypeofException.No_Such_Class, "No Such Class");
            }
            catch (MoodAnalysisException ex)
            {
                return ex.message;
            }
        }

        public static object Factory(string className, string message)
        {
            try
            {
                Type t = Type.GetType("NUnitMoodAnalyser." + className);
                if (t != null)
                {
                    object[] args = { message };
                    Object obj = Activator.CreateInstance(t, args);
                    return obj;
                }
                throw new MoodAnalysisException(MoodAnalysisException.TypeofException.No_Such_Class, "No Such Class");
            }
            catch (MoodAnalysisException ex)
            {
                return ex.message;
            }

        }
    }
    /// <summary>
    /// Wrongs the method.
    /// </summary>
    /// <param name="method">The method.</param>
    /// <returns></returns>
    /// <exception cref="MoodAnaylser.MoodAnalysisException">No Such Method</exception>
    public static string WrongMethod(string method)
    {
        MoodAnalyser moodAnalyser = (MoodAnalyser)MoodAnalyserReflector.Factory("MoodAnalyser", "Happy");
        MethodInfo methodInfo = moodAnalyser.GetType().GetMethod(method);
        try
        {
            if (methodInfo == null)
            {
                throw new MoodAnalysisException(MoodAnalysisException.TypeofException.No_Such_Method, "No Such Method");

            }
            return method;
        }
        catch (MoodAnalysisException ex)
        {
            return ex.Message;
        }
    }
    public string Setfield(string msgfield, string message)
    {
        try
        {
            if (msgfield == "msg")
            {
                msgfield = message;
                if (msgfield == null)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.TypeofException.Null, "Null");
                }
                // MoodAnalyserReflector reflector = (MoodAnalyserReflector)MoodAnalyserReflector.Factory("MoodAnalyserReflector");
                FieldInfo field = typeof(MoodAnalyserReflector).GetField("msg");
                return field.GetValue(null).ToString();
            }

            throw new MoodAnalysisException(MoodAnalysisException.TypeofException.No_Such_Field, "No Such Field");
        }
        catch (MoodAnalysisException ex)
        {
            return ex.Message;
        }
    }
}

