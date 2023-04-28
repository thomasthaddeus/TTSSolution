/*
 * Author:      Thaddeus Thomas
 * Date:        20230327
 * Project:     TextToSpeech
 * Solution:    TTS-Solution
 *
 * Notes:
 *
 */

using System.Diagnostics.CodeAnalysis;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.CognitiveServices.Speech;

namespace TextToSpeech
{
    /// <summary>
    ///     The TextToSpeech class.
    /// </summary>
    public class TextToSpeech
    {
        /// <summary>
        ///     The output speech synthesis result.
        /// </summary>
        /// <param name="speechSynthesisResult">
        ///     The speech synthesis result.
        /// </param>
        /// <param name="text">
        ///     The text.
        /// </param>
        /// <param name="argumentOutOfRangeException"></param>
        private static void OutputSpeechSynthesisResult(SpeechSynthesisResult speechSynthesisResult, string text, ArgumentOutOfRangeException argumentOutOfRangeException)
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
                        Console.WriteLine("CANCELED: Did you set the speech resource key and region values?");
                    }

                    break;

                default:
                    throw argumentOutOfRangeException;
                   // throw new ArgumentOutOfRangeException(nameof(speechSynthesisResult.Reason), speechSynthesisResult.Reason, null);
            }
        }

        private static async Task<string?> GetSecretFromKeyVaultAsync(string keyVaultUrl, string secretName)
        {
            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            var secretResponse = await client.GetSecretAsync(secretName);
            return secretResponse.Value.Value;
        }

        /// <summary>
        ///     Synthesizes speech for output
        /// </summary>
        /// <returns>The wav file of the audio</returns>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static async Task SynthesizeAudioAsync()
        {
            var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);
            speechConfig.SetSpeechSynthesisOutputFormat(SpeechSynthesisOutputFormat.Riff48Khz16BitMonoPcm);

            using var speechSynthesizer = new SpeechSynthesizer(speechConfig, null);
            var result = await speechSynthesizer.SpeakTextAsync("I'm excited to try text-to-speech");

            using var stream = AudioDataStream.FromResult(result);
            await stream.SaveToWaveFileAsync("%Documents%/PptxAudioFiles/audio_file.wav");
        }

        /// <summary>
        ///     The main method of the class
        /// </summary>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public static async Task Master()
        {
            // Replace with the URL of your Azure Key Vault instance.
            const string keyVaultUrl = @"https://ttvkeyvault.vault.azure.net/";

            // Retrieve the secrets from Azure Key Vault.
            speechKey = await GetSecretFromKeyVaultAsync(keyVaultUrl, "speechKey");
            speechRegion = await GetSecretFromKeyVaultAsync(keyVaultUrl, "speechRegion");

            var speechConfig = SpeechConfig.FromSubscription(speechKey, speechRegion);

            // The language of the voice that speaks.
            speechConfig.SpeechSynthesisVoiceName = "en-US-JennyNeural";
            using (var speechSynthesizer = new SpeechSynthesizer(speechConfig))
            {
                // Get text from the console and synthesize to the default speaker.
                Console.WriteLine("Enter some text that you want to speak >");
                var inputText = Console.ReadLine() ?? throw new InvalidOperationException();

                var speechSynthesisResult = await speechSynthesizer.SpeakTextAsync(inputText);
                OutputSpeechSynthesisResult(speechSynthesisResult, inputText, new ArgumentOutOfRangeException(nameof(speechSynthesisResult.Reason),
                    speechSynthesisResult.Reason, null));
            }

            // Call the SynthesizeAudioAsync method to create an audio file.
            await SynthesizeAudioAsync();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}