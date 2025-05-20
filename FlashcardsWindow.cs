using System;
using Gtk;

using System.Collections.Generic;

namespace FlashcardsApp
{
public partial class FlashcardsWindow : Gtk.Window
    {
        public int ID;
        List<Flashcard> Flashcards;
        public FlashcardsWindow(string categoryName, int index, List<Flashcard> flashcards) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.Name = categoryName;
            this.ID = index;
            this.Flashcards = flashcards;

            this.NumOfFlashcardsButton.Changed += this.ChangeFlashcardsButtons;
            NumOfFlashcardsButton.Value = flashcards.Count;

            okButton.Clicked += (sender, e) =>
            {
                int numberOfFlashcards = this.NumOfFlashcardsButton.ValueAsInt;
                if(Flashcards.Count> numberOfFlashcards)
                    Flashcards.RemoveRange(numberOfFlashcards, Flashcards.Count - numberOfFlashcards);
                this.Destroy(); 
            };

        }

        protected void ChangeFlashcardsButtons(object sender, EventArgs e)
        {
            int numberOfFlashcards = this.NumOfFlashcardsButton.ValueAsInt;
            foreach (Widget child in this.VBoxFlashcards.Children)
            {
                this.VBoxFlashcards.Remove(child);
            }

            for (int i = 0; i < numberOfFlashcards; i++)
            {
                if (i >= Flashcards.Count)
                {
                    Flashcards.Add(new Flashcard("EmptyQuestion","EmptyAnswer"));
                }

                HBox FlashcardHBox = new HBox();
                Entry FlashcardQuestionEntry = new Entry(Flashcards[i].Question);
                FlashcardHBox.Homogeneous = true;

                Entry FlashcardAnswerEntry = new Entry(Flashcards[i].Answer);
                int index = i;
                FlashcardQuestionEntry.Changed += (sender2, e2) =>
                {
                    Flashcards[index].Question = FlashcardQuestionEntry.Text;
                };

                int index2 = i;
                FlashcardAnswerEntry.Changed += (sender3, e3) =>
                {
                    Flashcards[index2].Answer = FlashcardAnswerEntry.Text;
                };

                FlashcardHBox.PackStart(FlashcardQuestionEntry, true, true, 0);
                FlashcardHBox.PackStart(FlashcardAnswerEntry, true, true, 0);
                this.VBoxFlashcards.PackStart(FlashcardHBox, false, false, 0);
            }
            this.VBoxFlashcards.ShowAll();

        }
    }

}
