using System;
using Gtk;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;

public class Flashcard
{
    public Flashcard(string question, string answer)
    {
        Question = question;
        Answer = answer;
    }

    public string Question { get; set; }
    public string Answer { get; set; }
}

public partial class MainWindow : Gtk.Window
{
    public List<string> ListOfCategoryNames = new List<string>();

    public List<List<Flashcard>> ListOfCategories = new List<List<Flashcard>>();

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        this.NumOfCatButton.Changed += this.ChangeCategoryButtons;
        this.LoadButton.Clicked += this.LoadData;
        this.entryUSBPort.Text = "/dev/ttyACM0";
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    protected void ChangeCategoryButtons(object sender, EventArgs e)
    {
        int numberOfCategories = this.NumOfCatButton.ValueAsInt;
        foreach (Widget child in this.vboxCategories.Children)
        {
            this.vboxCategories.Remove(child);
        }

        for (int i = 0; i<numberOfCategories; i++)
        {
            if (i >= ListOfCategoryNames.Count)
            {
                ListOfCategoryNames.Add("Empty");
                ListOfCategories.Add(new List<Flashcard>());
            }

            HBox CategoryHBox = new HBox();
            Entry CategoryEntry = new Entry(ListOfCategoryNames[i]);
            int index = i;
            CategoryEntry.Changed += (sender2, e2) =>
            {
                ListOfCategoryNames[index] = CategoryEntry.Text;
            };

            Button SetFlashcards = new Button("Set Flashcards...");

            SetFlashcards.Clicked += (sender3, e3) =>
            {
                new FlashcardsApp.FlashcardsWindow(ListOfCategoryNames[index], index, ListOfCategories[index]);
            };

            CategoryHBox.PackStart(new Label($"Category nr. {i}"), false, false, 0);
            CategoryHBox.PackStart(CategoryEntry, false, false, 0);
            CategoryHBox.PackStart(SetFlashcards, false, false, 0);
            CategoryHBox.PackStart(new Label($"Number: {ListOfCategories[i].Count}"), false, false, 0);
            this.vboxCategories.PackStart(CategoryHBox, false, false, 0);
        }
        this.vboxCategories.ShowAll();

    }

    protected void LoadData(object sender, EventArgs e)
    {
        string portName = this.entryUSBPort.Text;

        using (var serialPort = new SerialPort(portName, 115200))
        {
            serialPort.Open();

            //string text = "mammamija";
            //byte[] textBytes = System.Text.Encoding.Unicode.GetBytes(text);
            List<byte[]> dataToSend = new List<byte[]>();
            try
            {
                dataToSend = ConvertData();
            }
            catch (Exception ex)
            {
                LogException(ex);
            }

            foreach(byte[]  dataPackage in dataToSend)
                SendData(serialPort, dataPackage);
            serialPort.Close();
        }
    }

    protected void SendData(System.IO.Ports.SerialPort port, byte[] dataToSend)
    {
        byte[] data = new byte[1024];
        Array.Copy(dataToSend, data, dataToSend.Length);
        port.Write(data, 0, data.Length);

        string logRawFilePath = "logRaw.txt";
        using (StreamWriter writer = new StreamWriter(logRawFilePath))
        {
            foreach (byte b in data)
            {
                string line = $"Dec: {b}   Hex: 0x{b:X2}";
                writer.WriteLine(line);
            }
        }

        string logFilePath = "log.txt";
        using (StreamWriter writer = new StreamWriter(logFilePath))
        {
            writer.WriteLine(System.Text.Encoding.Unicode.GetString(data));
        }
    }

    static void LogException(Exception ex)
    {
        string logFilePath = "logException.txt";

        using (StreamWriter writer = new StreamWriter(logFilePath, append: true))
        {
            writer.WriteLine("===== Exception =====");
            writer.WriteLine("Time: " + DateTime.Now);
            writer.WriteLine("Message: " + ex.Message);
            writer.WriteLine("StackTrace: " + ex.StackTrace);
            writer.WriteLine();
        }
    }

    protected List<byte[]> ConvertData()
    {
        List<byte[]> outputData = new List<byte[]>();
        byte[] combined;
        using (var ms = new MemoryStream())
        {
            for (int i = 0; i < this.NumOfCatButton.ValueAsInt; i++)
            {
                ms.Write(new byte[]{ 0x01, 0x00}, 0, 2);
                byte[] textBytes = System.Text.Encoding.Unicode.GetBytes(ListOfCategoryNames[i]);
                ms.Write(textBytes, 0, textBytes.Length);
                foreach(Flashcard flashcard in ListOfCategories[i])
                {
                    ms.Write(new byte[] { 0x02, 0x00 }, 0, 2);
                    byte[] questionBytes = System.Text.Encoding.Unicode.GetBytes(flashcard.Question);
                    ms.Write(questionBytes, 0, questionBytes.Length);
                    ms.Write(new byte[] {0x03, 0x00 }, 0, 2);
                    byte[] answerBytes = System.Text.Encoding.Unicode.GetBytes(flashcard.Answer);
                    ms.Write(answerBytes, 0, answerBytes.Length);
                }
            }
            ms.Write(new byte[] { 0x04, 0x00 }, 0, 2);
            combined = ms.ToArray();
        }

        int numberOfPages = (combined.Length / 1024)+1;
        for(int i = 0; i<numberOfPages; i++)
        {
            outputData.Add(new byte[1024]);

            Array.Copy(combined, 1024*i, outputData[i], 0, Math.Min(1024, combined.Length-1024*i));
        }
        outputData[numberOfPages - 1][1023] = 0x04;
        return outputData;
    }

}
