﻿/*
 * Author: Thaddeus Thomas 
 * Date:
 * Project:
 * Solution: 
 *
 */

using System;
using System.Data;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace TextToSpeech
{
    public class SpeechSynthesizer
    {
        private readonly string SP_KEY;
        private readonly string SP_REG;

        public SpeechSynthesizer(string subscriptionKey, string region)
        {
            SP_KEY = subscriptionKey;
            SP_REG = region;
        }

        public async Task SynthesizeTextToSpeechAsync(string text, string outputFilePath)
        {
            var config = SpeechConfig.FromSubscription(SP_KEY, SP_REG);
            using var audioConfig = AudioConfig.FromWavFileOutput(outputFilePath);
            using var synthesizer = new SpeechSynthesizer(config, audioConfig);

            var result = await synthesizer.SpeakTextAsync(text);
            if (result.Reason != ResultReason.SynthesizingAudioCompleted)
            {
                throw new InvalidOperationException($"TTS failed: {result.ErrorDetails}");
            }
        }
    }
}
