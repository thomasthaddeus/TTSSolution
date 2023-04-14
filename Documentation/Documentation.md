# TextToSpeech

## Program

This program uses the Microsoft Cognitive Services Speech SDK to perform text-to-speech synthesis. Users enter text which is then synthesized into speech and played back. Additionally, the program can generate an audio file with the synthesized speech.

### Class: TTS

#### Properties

1. `spKey`: The subscription key for Microsoft Cognitive Services Speech.
1. `spRegion`: The region for Microsoft Cognitive Services Speech.

#### Methods

1. `OutputSpeechSynthesisResult(SpeechSynthesisResult speechSynthesisResult, string text)`: Outputs the result of the speech synthesis process to the console.
1. `SynthesizeAudioAsync()`: Asynchronously synthesizes audio from text and saves it as a .wav file.
1. `GetSecretFromKeyVaultAsync(string keyVaultUrl, string secretName)`: Retrieves a secret from Azure Key Vault.
1. `Main()`: The entry point for the program. Retrieves the speech key and region from Azure Key Vault (if configured), prompts the user for input text, synthesizes speech, plays back the synthesized speech, and generates an audio file.

## PptxScraper

This program extracts text from PowerPoint presentations (`.pptx` files).

### Class: PowerPointScraper

#### Methods

1. `ExtractTextFromPresentation(string filePath)`: Extracts text from a PowerPoint presentation given its file path.

#### Usage

Create an instance of PowerPointScraper.
Call the ExtractTextFromPresentation method, passing the file path of the PowerPoint presentation as an argument.
The method returns an IList<string> containing the extracted text.

### Example

    ```csharp
    using System;

    namespace PptxScraperExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                string filePath = "path/to/your/presentation.pptx";
                var scraper = new PowerPointScraper();
                var extractedText = scraper.ExtractTextFromPresentation(filePath);

                Console.WriteLine("Extracted Text:");
                foreach (var text in extractedText)
                {
                    Console.WriteLine(text);
                }
            }
        }
    }
    ```

In this example, the `PowerPointScraper` class is used to extract text from a PowerPoint presentation. The extracted text is then displayed in the console.

Next, let's explain how to configure and run the TextToSpeech program.

## Configuring TextToSpeech

Before running the TextToSpeech program, you need to have valid credentials for Microsoft Cognitive Services Speech. You can either use environment variables or Azure Key Vault to store and retrieve the speech key and region.

### Environment Variables

`spKey`: The subscription key for Microsoft Cognitive Services Speech.
`spRegion`: The region for Microsoft Cognitive Services Speech.

### Azure Key Vault

1. Store the secrets (speech key and region) in Azure Key Vault.
1. Replace the keyVaultUrl variable in the Main method with the URL of your Azure Key Vault instance.
1. Set the environment variables AZURE_CLIENT_ID, AZURE_TENANT_ID, and AZURE_CLIENT_SECRET with the appropriate values for your Azure account when running the code locally.

## Running the TextToSpeech program

1. Build and run the TextToSpeech program.
1. Enter the text you want to convert to speech when prompted.
The program will synthesize the entered text and play it back.
An audio file with the synthesized speech will be created and saved as a .wav file.
Running the PptxScraper Example
Create a new console application and add the PowerPointScraper class to the project.

Make sure to install the DocumentFormat.OpenXml NuGet package:

    ```cs
    dotnet add package DocumentFormat.OpenXml
    ```

Replace the Program class with the provided example code.

Update the filePath variable in the example code with the path to a PowerPoint presentation file.

Build and run the PptxScraper example.

The extracted text from the PowerPoint presentation will be displayed in the console.

Integration of TextToSpeech and PptxScraper
If you want to integrate the TextToSpeech and PptxScraper programs, you can create a new application that extracts text from a PowerPoint presentation and then synthesizes speech for the extracted text.

Creating the Integrated Application
Create a new console application and add the PowerPointScraper and TTS classes to the project.

Make sure to install the required NuGet packages:

    ```csharp
    dotnet add package DocumentFormat.OpenXml
    dotnet add package Microsoft.CognitiveServices.Speech
    dotnet add package Azure.Identity
    dotnet add package Azure.Security.KeyVault.Secrets
    ```

Create a new class named Program and add the following code:

    ```csharp
    using System;
    using System.Threading.Tasks;

    namespace IntegratedApp
    {
        class Program
        {
            static async Task Main(string[] args)
            {
                // Extract text from the PowerPoint presentation.
                string filePath = "path/to/your/presentation.pptx";
                var scraper = new PowerPointScraper();
                var extractedText = scraper.ExtractTextFromPresentation(filePath);

                Console.WriteLine("Extracted Text:");
                foreach (var text in extractedText)
                {
                    Console.WriteLine(text);
                }

                // Synthesize speech for the extracted text.
                var tts = new TTS();

                foreach (var text in extractedText)
                {
                    var speechSynthesisResult = await tts.SynthesizeTextToSpeechAsync(text);
                    TTS.OutputSpeechSynthesisResult(speechSynthesisResult, text);
                }
            }
        }
    }
    ```

Update the filePath variable in the example code with the path to a PowerPoint presentation file.
Running the Integrated Application
Build and run the integrated application.
The program will extract text from the PowerPoint presentation and display it in the console.
The program will synthesize speech for each extracted text and play it back.
This integrated application demonstrates how to use both the TextToSpeech and PptxScraper programs together. The extracted text from a PowerPoint presentation is converted to speech and played back using the TextToSpeech program.