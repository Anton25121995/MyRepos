using Android.Speech.Tts;
using HelloMvxForms.Droid.Services;
using HelloMvxForms.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SpeechService))]
namespace HelloMvxForms.Droid.Services
{
    public class SpeechService : Java.Lang.Object, ISpeechService, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;
        
        public void Speak(string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                toSpeak = text;
                if (speaker == null)
                    speaker = new TextToSpeech(MainActivity.Instance, this);
                else
                {
                    speaker.Speak(toSpeak, QueueMode.Flush, null, null);
                }
            }
        }

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }
        #endregion
    }
}