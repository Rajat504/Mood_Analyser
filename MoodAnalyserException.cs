using System;
using System.Collections.Generic;
using System.Text;

namespace Mood_Analyser
{
    /// <summary>
    /// creating MoodAnalyserException class
    /// </summary>
  public  class MoodAnalysisException : Exception
  {
        public string message;

        public TypeofException type;
 
        ///<summary>
        ///creating enum method
        ///</summary>
        public enum TypeofException
        {
            Null , Empty , No_Such_Class , No_Such_Method ,No_Such_Field
        }
        ///<summary>
        ///
        ///</summary>
        public MoodAnalysisException(TypeofException type_,string error)
        {
            type = type_;
            message = error;
        }
        ///<summary>
        ///gets a message that describes the current exception
        ///</summary>
        public override string Message
        {
            get
            {
                return this.message;
            }
        }

    }
}
