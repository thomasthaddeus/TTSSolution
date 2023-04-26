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
    using Azure.Identity;
    using Azure.Security.KeyVault.Secrets;
    using Microsoft.CognitiveServices.Speech;
    using System.Diagnostics.CodeAnalysis;
    using Security;

    /// <summary>
    /// The tts.
    /// </summary>
    public class TextToSp
    {
        // https://westus.tts.speech.microsoft.com/cognitiveservices/voices/list
        // USe to get the voices list

        /// <summary>
        /// The output speech synthesis result.
        /// </summary>
        /// <param name="speechSynthesisResult">
        /// The speech synthesis result.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        private static void OutputSpeechSynthesisResult(SpeechSynthesisResult speechSynthesisResult, string text)
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
                case ResultReason.NoMatch:
                    break;
                case ResultReason.RecognizingSpeech:
                    break;
                case ResultReason.RecognizedSpeech:
                    break;
                case ResultReason.RecognizingIntent:
                    break;
                case ResultReason.RecognizedIntent:
                    break;
                case ResultReason.TranslatingSpeech:
                    break;
                case ResultReason.TranslatedSpeech:
                    break;
                case ResultReason.SynthesizingAudio:
                    break;
                case ResultReason.RecognizingKeyword:
                    break;
                case ResultReason.RecognizedKeyword:
                    break;
                case ResultReason.SynthesizingAudioStarted:
                    break;
                case ResultReason.TranslatingParticipantSpeech:
                    break;
                case ResultReason.TranslatedParticipantSpeech:
                    break;
                case ResultReason.TranslatedInstantMessage:
                    break;
                case ResultReason.TranslatedParticipantInstantMessage:
                    break;
                case ResultReason.EnrollingVoiceProfile:
                    break;
                case ResultReason.EnrolledVoiceProfile:
                    break;
                case ResultReason.RecognizedSpeakers:
                    break;
                case ResultReason.RecognizedSpeaker:
                    break;
                case ResultReason.ResetVoiceProfile:
                    break;
                case ResultReason.DeletedVoiceProfile:
                    break;
                case ResultReason.VoicesListRetrieved:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static async Task<string?> GetSecretFromKeyVaultAsync(string keyVaultUrl, string secretName)
        {
            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            var secretResponse = await client.GetSecretAsync(secretName);
            return secretResponse.Value.Value;
        }

        /// <summary>
        /// Synthesizes speech for output
        /// </summary>
        /// <returns>The wav file of the audio</returns>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static async Task SynthesizeAudioAsync()
        {
            speechConfig.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Riff48Khz16BitMonoPcm);

            using var speechSynthesizer = new SpeechSynthesizer(speechConfig, null);
            var result = await speechSynthesizer.SpeakTextAsync("I'm excited to try text-to-speech");

            using var stream = AudioDataStream.FromResult(result);
            await stream.SaveToWaveFileAsync($"%Documents%/PptxAudioFiles/audio_file.wav");
        }

        /// <summary>
        /// The main method of the class
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task Master()
        {
            // Replace with the URL of your Azure Key Vault instance.
            const string keyVaultUrl = "https://voiceresource.vault.azure.net/";

            // Retrieve the secrets from Azure Key Vault.
            spKey = await GetSecretFromKeyVaultAsync(keyVaultUrl, "spKey");
            spRegion = await GetSecretFromKeyVaultAsync(keyVaultUrl, "spRegion");

            var speechConfig = SpeechConfig.FromSubscription(spKey, spRegion);

            // The language of the voice that speaks.
            speechConfig.SpeechSynthesisVoiceName = "en-US-JennyNeural";

            using (var speechSynthesizer = new SpeechSynthesizer(speechConfig))
            {
                // Get text from the console and synthesize to the default speaker.
                Console.WriteLine("Enter some text that you want to speak >");
                var inputText = Console.ReadLine() ?? throw new InvalidOperationException();

                var speechSynthesisResult = await speechSynthesizer.SpeakTextAsync(inputText);
                OutputSpeechSynthesisResult(speechSynthesisResult, inputText);
            }

            // Call the SynthesizeAudioAsync method to create an audio file.
            await SynthesizeAudioAsync();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}