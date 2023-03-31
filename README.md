# Text-To-Voice

Redux:          #11
Author:         Thaddeus Thomas
Author:         Shelby Lynch
Date:           2023-03-27
Project:        Text-To-Voice
Cloud:          Azure

- [Text-To-Voice](#text-to-voice)
  - [Initial Setup Implementation](#initial-setup-implementation)
    - [Additional Requirements](#additional-requirements)
    - [Documentation](#documentation)
    - [Finalize your application](#finalize-your-application)
    - [Configuration](#configuration)
    - [Bundle libraries and dependencies](#bundle-libraries-and-dependencies)
    - [Create an executable](#create-an-executable)
    - [Create an installer](#create-an-installer)
    - [User prompts for configuration](#user-prompts-for-configuration)
    - [Testing](#testing)
  - [Defining the Structure](#defining-the-structure)
    - [Tree Structure](#tree-structure)
  - [Estimated Size](#estimated-size)
  - [C# Vs. Python](#c-vs-python)
    - [Python for .NET (Pythonnet)](#python-for-net-pythonnet)
    - [IronPython](#ironpython)
    - [Performance](#performance)
    - [Dependency management](#dependency-management)
    - [Debugging](#debugging)
  - [PowerPointScraper](#powerpointscraper)

## Initial Setup Implementation

I need to create an application in C# using multiple projects.

1. A project called TextToSpeech,
2. A project called PptxScraper:
    - Scrapes the text in the notes of a PowerPoint presentation or on the slides or both,
3. Project ExpansionScraper (future implementation of other data types),
4. Project tests (standard C# tests project)
5. Project TTS-GUI that holds the solution file.

### Additional Requirements

A rotating voice gallery that asks for neural paths before execution of the file. These neural paths would rotate who is speaking based on length of sentence. That is the least important part right now though.
My first question is am I missing anything for project files? Such as static files, authentication sections or is this a well-rounded initial application design?

---

Your initial application design seems to cover most of the main aspects of the project. However, I'll suggest a few more considerations to ensure a well-rounded design:

1. Configuration
   - You might want to include a project or folder for configuration files, where you can store settings related to the application, such as API keys, paths to neural voice models, or any other configuration information.
2. Libraries and dependencies
   - Ensure you have the necessary external libraries and NuGet packages for each project. For instance, you'll likely need a library to interact with PowerPoint files (e.g., GemBox.Presentation) for the PptxScraper project and a Text-to-Speech library (e.g., Microsoft.CognitiveServices.Speech) for the TextToSpeech project.
3. Common Utilities
   - You might want to create a separate project or folder for common utility classes and functions that can be shared across different projects. This can help with code reusability and maintainability.
4. Logging and Error Handling
   - Consider implementing a logging mechanism to track application execution and handle errors efficiently. This can be done using a dedicated logging library like NLog or Serilog, or by implementing your custom logging solution.
5. Security and Authentication
   - If your application needs to access secure resources or enforce user authentication, you should plan for implementing proper security measures. You can use built-in .NET Core Identity for user authentication and authorization.

### Documentation

Don't forget to include proper documentation for each project, such as README files, inline code comments, and XML documentation for public APIs.

To sum up, your initial application design is good, but you should consider including configuration, libraries and dependencies, common utilities, logging and error handling, security and authentication, and documentation for a more comprehensive design.

My goal for this project is to have an executable that could be installed by a user with the only need they would have for installation to be inputting the cognitive services endpoint or key
To achieve this goal, you'll need to create an installer for your application that takes care of bundling all the necessary components and simplifying the installation process for the end-user. Here's an outline of the steps you can follow:

### Finalize your application

Complete the development and testing of your application, ensuring all projects are working as expected.

### Configuration

Make sure the application's configuration settings (e.g., Cognitive Services endpoint or key) can be easily updated by the end-user. One approach is to store these settings in an appsettings.json file, which can be modified post-installation.

### Bundle libraries and dependencies

Ensure that all the required libraries and dependencies are included in your application's output. You can achieve this by setting "Copy Local" to "True" for all referenced assemblies in your projects.

### Create an executable

Build your solution in Release mode, and make sure the output contains an executable (.exe) file for your TTS-GUI project. You may want to use a tool like Fody/Costura to embed all dependencies into a single executable file for easier distribution.

### Create an installer

Use an installer creation tool, such as Inno Setup, NSIS, or Advanced Installer, to create an installer package for your application. These tools will help you to create a professional-looking installer, which will handle the installation process, create shortcuts, and optionally configure the app settings (like the Cognitive Services endpoint/key).

### User prompts for configuration

During the installation process, you can prompt the user for necessary configuration information (e.g., Cognitive Services endpoint or key) using the installer tool's built-in features. This way, the user won't have to edit the configuration file manually.

### Testing

Test the installer on different Windows versions and configurations to ensure that your application installs correctly and works as expected.

By following these steps, you'll be able to create an installer for your application that can be easily installed by the end-user. They will only need to input the required Cognitive Services endpoint or key during the installation process, and your application should work seamlessly.

## Defining the Structure

**TextToSpeech**: Handles the text-to-speech functionality.
**PptxScraper**: Scrapes the text from PowerPoint presentations.
**ExpansionScraper**: Future implementation for other data types.
**Tests**: Standard C# tests project.
**TTS-GUI**: The main GUI project that holds the solution file.
**Configuration**: Handles configuration files and settings.
**CommonUtilities**: A project for shared utility classes and functions.
**Logging**: Handles logging and error handling for the application.
**Security**: If required, you can create a separate project to handle security and authentication.
**DataModels**: You can create a separate project to define the data models and entities used in your application.
This structure, with a total of 8 to 10 projects, allows for more modular code organization, which should make it easier to debug, maintain, and expand your application. Each project can be focused on a specific aspect of the application, reducing complexity and improving code readability.

### Tree Structure

Folder structure to a depth of 3 from the solution file folder

```arduino
TTS-Solution
│   TTS-Solution.sln
│
├───TextToSpeech
│   ├───Properties
│   └───Services
│
├───PptxScraper
│   ├───Properties
│   └───Services
│
├───ExpansionScraper
│   ├───Properties
│   └───Services
│
├───Tests
│   ├───Properties
│   └───TestCases
│
├───TTS-GUI
│   ├───Properties
│   └───Views
│
├───Configuration
│   └───Settings
│
├───CommonUtilities
│   ├───Properties
│   └───Helpers
│
├───Logging
│   ├───Properties
│   └───Services
│
├───Security (optional)
│   ├───Properties
│   └───Services
│
└───DataModels (optional)
    ├───Properties
    └───Models
```

This structure includes folders for each project, with a "Properties" and "Services" (or other relevant) folder inside each project. You can further expand and customize the folder structure based on the specific requirements and organization of your application.

## Estimated Size

whats the estimated size of this project with all ten projects in the solution at completion of this project?
Estimating the size of a project at completion can be challenging without knowing the exact code, dependencies, and resources that will be used. However, I can provide you with a rough estimation based on the projects in the solution.
Typically, a moderately sized C# project with the structure you've described might range from a few hundred kilobytes to several megabytes in size, excluding external libraries and dependencies.

Here's a rough breakdown of the project sizes:

   1. Source code: The size of your source code files (C# files, XAML files, etc.) will depend on the complexity of your application. For a moderate-sized application, you can expect a few hundred kilobytes.
   2. Libraries and dependencies: External libraries (NuGet packages) can vary greatly in size. For example, GemBox.Presentation might be around 5-10 MB, while Microsoft.CognitiveServices.Speech could be around 20-30 MB. The total size of your libraries and dependencies might range from 30 MB to 100 MB, depending on your project's requirements.
   3. Resources: If your application includes multimedia files (images, audio files, etc.), their size will contribute to the overall size of your project. These can vary greatly depending on the quantity and quality of the resources used.
   4. Executables and build artifacts: The compiled executable files, including the main application and test projects, will also contribute to the project size. This could range from a few hundred kilobytes to several megabytes, depending on the complexity of your code and optimizations.

Based on these factors, the total size of your project could range from around 50 MB to a few hundred MB, considering libraries, dependencies, resources, and build artifacts. Keep in mind that these are rough estimates, and the actual size of your project may vary based on your specific implementation and requirements.

## C# Vs. Python

how difficult is it to integrate python into C#
Integrating Python into a C# application can be achieved using Python for .NET (Pythonnet) or IronPython. Both options allow you to run Python code within a .NET application and enable interaction between C# and Python code.

Here's a brief overview of both options:

### Python for .NET (Pythonnet)

Pythonnet is a package that provides a low-level bridge between C# and Python. It enables you to run CPython scripts from your .NET application and allows you to call Python libraries and functions from C# code.

To use Pythonnet, you can follow these steps:

1. Install Pythonnet via NuGet (Package name: Pythonnet.PyQt5).
1. Ensure that you have Python installed on your system and the environment variable PYTHONNET_PYTHON is set to your Python executable's path.
1. Here's a simple example of using Pythonnet in C#:

```csharp
using Python.Runtime;

class Program
{
    static void Main(string[] args)
    {
        using (Py.GIL()) // Acquire the Python GIL (Global Interpreter Lock)
        {
            dynamic np = Py.Import("numpy");
            double[] myArray = new double[] { 1, 2, 3, 4, 5 };
            dynamic npArray = np.array(myArray);
            Console.WriteLine(npArray);
        }
    }
}
```

### IronPython

IronPython is an open-source implementation of Python that runs on the .NET Framework. It allows you to seamlessly integrate Python code with .NET applications.

To use IronPython, you can follow these steps:

Install IronPython via NuGet (Package name: IronPython).
Install IronPython Standard Library via NuGet (Package name: IronPython.StdLib).
Here's a simple example of using IronPython in C#:

```csharp
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

class Program
{
    static void Main(string[] args)
    {
        ScriptEngine engine = Python.CreateEngine();
        ScriptScope scope = engine.CreateScope();

        engine.Execute("import math", scope);
        dynamic math = scope.GetVariable("math");
        double result = math.sqrt(4);

        Console.WriteLine(result); // Output: 2.0
    }
}
```

While integrating Python into C# is not overly difficult, there are some caveats to keep in mind:

### Performance

Running Python code in a C# application can introduce performance overhead, especially when frequently exchanging data between C# and Python.

### Dependency management

You may need to manage Python dependencies and ensure that they are available on the target system.

### Debugging

Debugging mixed C# and Python code can be more challenging compared to working with a single language.
If you decide to integrate Python into your C# application, be prepared to handle these challenges and consider whether the benefits of using Python outweigh the potential drawbacks.

## PowerPointScraper

This code defines a PowerPointScraper class that includes a method named ExtractTextFromPresentation. This method takes a file path as input and returns a list of strings containing the extracted text from the PowerPoint presentation. The method uses the DocumentFormat.OpenXml library to open the presentation and iterate through its slides and shapes, extracting the text content of each shape.

Here's a step-by-step explanation of the code:

1. A new class `PowerPointScraper` is defined.
2. The `ExtractTextFromPresentation` method is declared with a string parameter `filePath`.
3. A new list of strings named `textList` is created to store the extracted text.
4. The presentation document is opened using `PresentationDocument.Open`, and a `using` statement is used to ensure proper disposal of the file.
5. The `PresentationPart` of the presentation is retrieved.
6. If the `PresentationPart` is not null, the method iterates through the `SlideIdList` to access each slide in the presentation.
7. For each slide, the `SlidePart` is retrieved.
8. If the `SlidePart` is not null, the method iterates through the `Descendants<Shape>` to access each shape on the slide.
9. If the shape has a `TextBody`, the method iterates through the `Descendants<DocumentFormat.OpenXml.Drawing.Paragraph>` to access each paragraph in the shape.
10. The text content of the paragraph is retrieved using the InnerText property.
11. If the text is not empty or whitespace, it is added to the textList.
12. Once all slides and shapes have been processed, the method returns the textList, which contains the extracted text from the PowerPoint presentation.

To use this PowerPointScraper class in your application, you can create an instance of the class and call the ExtractTextFromPresentation method with the file path of the PowerPoint file you want to process. For example:

```csharp
using PptxScraper;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "path/to/your/presentation.pptx";
        PowerPointScraper powerPointScraper = new PowerPointScraper();
        IList<string> extractedTextList = powerPointScraper.ExtractTextFromPresentation(filePath);

        foreach (string text in extractedTextList)
        {
            Console.WriteLine(text);
        }
    }
}
```
