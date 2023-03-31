# HOWTO

## GUI-Setup

To set up a Graphical User Interface (GUI) in Visual Studio for an application written in C#, you can use the Windows Forms framework, which is a popular choice for creating desktop applications with a GUI on the Windows platform.

Here's a step-by-step guide to create a simple Windows Forms application in Visual Studio:

1. Open Visual Studio.
2. Click on `Create a new project` on the start screen or go to `File` > `New` > `Project` in the main menu.
3. In the `New Project` dialog, search for `Windows Forms App` in the search box.
4. Select the `Windows Forms App (.NET)` template for C# and click `Next.`
5. Give your project a name, choose a location to save it, and click `Create.`
6. Visual Studio will create a new Windows Forms project for you, and you'll see a default form (Form1.cs) in the designer view.

Now you can start designing your GUI by adding controls to the form:

1. Go to the `Toolbox` panel on the left side of the screen. If it's not visible, you can enable it by clicking on `View` > `Toolbox` in the main menu.
1. In the `Toolbox,` you'll see a list of available controls, such as buttons, labels, text boxes, and more. Click on a control and drag it onto your form.
1. Once you've added a control to your form, you can customize its properties (such as text, font, color, etc.) using the `Properties` panel, usually located on the bottom right side of the screen. If it's not visible, go to `View` > `Properties Window` in the main menu.

To add functionality to the controls, you can create event handlers for specific events, such as button clicks or text input. Here's how you can create an event handler:

1. Double-click on the control you want to create an event handler for (e.g., a button) in the designer view. This will automatically generate an event handler method in the Form1.cs code-behind file and open it in the code editor.
1. In the generated event handler method, write the code you want to execute when the event occurs. For example, if you have a button that should change the text of a label when clicked, your code may look like this:

    ```csharp
    private void button1_Click(object sender, EventArgs e)
    {
        label1.Text = "Hello, World!";
    }
    ```

1. Save your changes and press F5 or click the `Start` button in the toolbar to run your application. You should see your form with the added controls, and the functionality you added to the event handlers should work as expected.
Remember that you can create event handlers for various events and controls, allowing you to build a complex and interactive GUI for your C# application.

Once you have finished designing your GUI and implementing the desired functionality, you can build your application by clicking on `Build` > `Build Solution` in the main menu. This will compile your application into an executable (`.exe`) file, which you can distribute to users.
