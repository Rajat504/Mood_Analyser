using NUnit.Framework;
using Mood_Analyser;
using MySqlX.XDevAPI.Common;

namespace NUnitTestMoodAnalyser
{
    public class Tests
    {
        ///<summary>
        ///set the sad name message when analyze return null
        ///</summary>
        [Test]
        public void Given_Sad_Message_When_Analyse_Return_Sad_Test()
        {
            MoodAnalyser analyser = new MoodAnalyser();
            Assert.AreEqual("Sad", analyser.AnalyseMood());
        }
        ///<summary>
        ///set i am in any mood message when analyze return happy
        ///</summary>
        [Test]
        public void Given_Happy_Message_When_Analyse_Return_Happy_Test()
        {
            MoodAnalyser mood = new MoodAnalyser();
            Assert.AreEqual("Happy", mood.AnalyseMood());
        }
        ///<summary>
        ///TestCase 3.1/2.1
        ///set the null name message when analyze return null
        ///</summary>
        [Test]
        public void Given_Null_Exception_Message_when_Analyse_Return_Null()
        {
            MoodAnalyser mood1 = new MoodAnalyser();
            Assert.AreEqual("Null", mood1.AnalyseMood());
        }
        ///<summary>
        ///set the empty string message when analyze return empty
        ///</summary>
        [Test]
        public void Given_Empty_Message_When_Analyse_Return_Empty()
        {
            MoodAnalyser mood1 = new MoodAnalyser();
            Assert.AreEqual("Empty", mood1.AnalyseMood());
        }
        ///<summary>
        ///set the object name message when analyze return moodanalyser object
        ///</summary>
        [Test]
        public void Given_Class_Name_When_Analyse_MoodAnalyser_object()
        {
            MoodAnalyser mood = new MoodAnalyser();
            Assert.IsTrue(mood.Equals(mood));
        }
        ///<summary>
        ///set the wrong class name message when analyze returns no errors
        ///</summary>
        [Test]
        public void Given_No_Such_Class_Name_When_Analyse_Return_MoodAnalyser_No_Such_Class()
        {
            string s1 = MoodAnalyserReflector.Factory("No Such Class").ToString();
            Assert.AreEqual("No Such Class", s1);
        }
        ///<summary>
        ///set the hello name message when analyzed return zero
        ///</summary>
        [Test]
        public void Given_Constructor_With_Parameter_When_Analysed_Should_Return_MoodAnalyserObject()
        {
            MoodAnalyser mood = new MoodAnalyser("Hello");
            bool request = mood.Equals(mood);
            Assert.AreEqual(true,Result);
        }
        ///<summary>
        ///set wrong method name with reflector when analyse return no class error
        ///</summary>
        [Test]
        public void Given_NoSuch_Constructor_Name_When_Analysed_Return_MoodAnalyserNoSuchClass()
        {
            string s1 = MoodAnalyserReflector.Factory("No Such Class").ToString();
            MoodAnalyser obj1 = new MoodAnalyser("Hello");
            Assert.AreEqual("No Such Class", s1);
        }
        ///<summary>
        ///Set the happy message with reflector when analyze return happy..
        ///</summary>
        [Test]
        public void GivenInvokeMethod_WhenAnalysed_ShouldReturnMoodAnalyserHappy()
        {
            MoodAnalyser moodAnalyser = (MoodAnalyser)MoodAnalyserReflector.Factory("MoodAnalyser", "Happy");
            string actual = moodAnalyser.GetType().GetMethod("analyseMood").Invoke(moodAnalyser, null).ToString();
            Assert.AreEqual("Happy", actual);
        }
        /// <summary>
        /// Set the Wrong method name message with reflector when analyze return No Such Method Error.
        /// </summary>
        [Test]
        public void GivenNoSuchMethod_WhenAnalyse_ShouldReturnMoodAnalyserNoSuchMethod()
        {
            string error = MoodAnalyserReflector.WrongMethod("AnalyseMood");
            Assert.AreEqual("No Such Method", error);
        } /// <summary>
          /// TestCase-6.1(Refactor) 
          /// Set the happy message with reflector when analyze return happy.
          /// </summary>
        [Test]
        public void SetHappyMessage_WithReflector_WhenAnalyse_ReturnHappy()
        {
            MoodAnalyserReflector moodAnalyserReflector = (MoodAnalyserReflector)MoodAnalyserReflector.Factory("MoodAnalyserReflector");
            string[] parameters = new string[2];
            parameters[0] = "msg";
            parameters[1] = "Happy";
            string actual = moodAnalyserReflector.GetType().GetMethod("Setfield").Invoke(moodAnalyserReflector, parameters).ToString();
            Assert.AreEqual("Happy", actual);
        }
        /// <summary>
        ///Refactor 6.2
        /// Set the improper field with message when analyze return mood analysis exception.
        /// </summary>
        [Test]
        public void SetValueOnSetField_WhenAnalyse_ReturnMoodAnalysisException()
        {
            MoodAnalyserReflector moodAnalyserReflector = (MoodAnalyserReflector)MoodAnalyserReflector.Factory("MoodAnalyserReflector");
            string[] parameters = new string[2];
            parameters[0] = "anything";
            parameters[1] = "Happy";
            string actual = moodAnalyserReflector.GetType().GetMethod("Setfield").Invoke(moodAnalyserReflector, parameters).ToString();
            Assert.AreEqual("No Such Field", actual);
        }
        /// <summary>
        /// Set the null message with reflector when analyze return mood analysis exception.
        /// </summary>
        [Test]
        public void SetNullMessageWithReflector_WhenAnalyse_ReturnMoodAnalysisException()
        {
            MoodAnalyserReflector moodAnalyserReflector = (MoodAnalyserReflector)MoodAnalyserReflector.Factory("MoodAnalyserReflector");
            string[] parameters = new string[2];
            parameters[0] = "msg";
            parameters[1] = null;
            string actual = moodAnalyserReflector.GetType().GetMethod("Setfield").Invoke(moodAnalyserReflector, parameters).ToString();
            Assert.AreEqual("Null", actual);
        }




    }


}