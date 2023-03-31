/*
 * Author:      Thaddeus Thomas
 * Date:        20230327
 * Project:     TextToSpeech
 * Solution:    TTS-Solution
 *
 * Notes:
 *
 */

namespace TextToSpeech
{
    using System.Diagnostics;

    using Microsoft.CognitiveServices.Speech;
    using Microsoft.CognitiveServices.Speech.Audio;

    /// <summary>
    /// The tts.
    /// </summary>
    public class TTS
    {
        /// <summary>
        /// This example requires environment variables named "spKey"
        /// </summary>
        private static string spKey = Environment.GetEnvironmentVariable("spKey");

        /// <summary>
        /// Environment variable "spRegion"
        /// </summary>
        private static string spRegion = Environment.GetEnvironmentVariable("spRegion");

        /// <summary>
        /// The output speech synthesis result.
        /// </summary>
        /// <param name="speechSynthesisResult">
        /// The speech synthesis result.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        public static void OutputSpeechSynthesisResult(SpeechSynthesisResult speechSynthesisResult, string text)
        {
            switch (speechSynthesisResult.Reason)
            {
                case ResultReason.SynthesizingAudioCompleted:
                    Console.WriteLine($"Speech synthesized for text: [{text}]");
                    break;
                case ResultReason.Canceled:
                    var cancellation = SpeechSynthesisCancellationDetails.FromResult(speechSynthesisResult);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");
                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails=[{cancellation.ErrorDetails}]");
                        Console.WriteLine($"CANCELED: Did you set the speech resource key and region values?");
                    }

                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task SynthesizeAudioAsync()
        {
            var speechConfig = SpeechConfig.FromSubscription(spKey, spRegion);
            speechConfig.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Riff24Khz16BitMonoPcm);

            using var speechSynthesizer = new SpeechSynthesizer(speechConfig, null);
            var result = await speechSynthesizer.SpeakTextAsync("I'm excited to try text-to-speech");

            using var stream = AudioDataStream.FromResult(result);
            await stream.SaveToWaveFileAsync("path/to/write/file.wav");
        }


        /// <summary>
        /// The main method of the class
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task Main()
        {
            var speechConfig = SpeechConfig.FromSubscription(spKey, spRegion);      

            // The language of the voice that speaks.
            speechConfig.SpeechSynthesisVoiceName = "en-US-JennyNeural"; 

            using (var speechSynthesizer = new SpeechSynthesizer(speechConfig))
            {
                // Get text from the console and synthesize to the default speaker.
                Console.WriteLine("Enter some text that you want to speak >");
                var inputText = Console.ReadLine() ?? throw new InvalidOperationException();

                var speechSynthesisResult = await speechSynthesizer.SpeakTextAsync(inputText);
                Debug.Assert(inputText != null, nameof(inputText) + " != null");
                OutputSpeechSynthesisResult(speechSynthesisResult, inputText);
            }

            // Call the SynthesizeAudioAsync method to create an audio file.
            await SynthesizeAudioAsync();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}