using System;
using System.Collections.Generic;
using System.Text;


namespace Mood_Analyser
{
    /// <summary>
    /// Defined Mood Analyser Class
    /// </summary>
  public  class MoodAnalyser
  {
        ///<summary>
        ///Defining Global message
        ///</summary>
        string message = "i am in sad mood";
        ///<summary>
        ///Defined a null constructor for mood analyser
        ///</summary>
        public MoodAnalyser() 
        { }
        ///<summary>
        ///Defining a parametring constructor
        ///</summary>
        public MoodAnalyser( string message)
        {
            this.message = message;
        }
        ///<summary>
        ///defining the object get type method
        ///</summary>
        public override bool Equals(object obj)
        {
            object obj1 = MoodAnalyserReflector.Factory("MoodAnalyser", "Rajat");
            if (obj1.GetType() == obj.GetType())
            {
                return true;
            }
            return false;
        }
        ///<summary>
        ///Function for mood analyser
        ///</summary>
        public string AnalyseMood()
        {
            try
            {
                if (message == string.Empty)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.TypeofException.Empty, "Empty");
                }
                if (message == null)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.TypeofException.Null, "Null");
                }
                if (message.ToLower().Contains("sad"))
                {
                    return "Sad";
                }
            }
            catch(MoodAnalysisException ex)
            {
                return ex.message;
            }
            return "Happy";
        }
  }
}
