
// This file has been generated by the GUI designer. Do not modify.
namespace FlashcardsApp
{
	public partial class FlashcardsWindow
	{
		private global::Gtk.VBox vbox1;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label labelNumOfFlashcards;

		private global::Gtk.SpinButton NumOfFlashcardsButton;

		private global::Gtk.HBox hbox1;

		private global::Gtk.Label labelQuestion;

		private global::Gtk.Label labelAnswer;

		private global::Gtk.VBox VBoxFlashcards;

		private global::Gtk.VSeparator vseparator1;

		private global::Gtk.Button okButton;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget FlashcardsApp.FlashcardsWindow
			this.Name = "FlashcardsApp.FlashcardsWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("FlashcardsWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child FlashcardsApp.FlashcardsWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.labelNumOfFlashcards = new global::Gtk.Label();
			this.labelNumOfFlashcards.Name = "labelNumOfFlashcards";
			this.labelNumOfFlashcards.LabelProp = global::Mono.Unix.Catalog.GetString("Number of Flashcards: ");
			this.hbox2.Add(this.labelNumOfFlashcards);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.labelNumOfFlashcards]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.NumOfFlashcardsButton = new global::Gtk.SpinButton(0D, 100D, 1D);
			this.NumOfFlashcardsButton.CanFocus = true;
			this.NumOfFlashcardsButton.Name = "NumOfFlashcardsButton";
			this.NumOfFlashcardsButton.Adjustment.PageIncrement = 10D;
			this.NumOfFlashcardsButton.ClimbRate = 1D;
			this.NumOfFlashcardsButton.Numeric = true;
			this.hbox2.Add(this.NumOfFlashcardsButton);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.NumOfFlashcardsButton]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			this.vbox1.Add(this.hbox2);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox2]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Homogeneous = true;
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelQuestion = new global::Gtk.Label();
			this.labelQuestion.Name = "labelQuestion";
			this.labelQuestion.LabelProp = global::Mono.Unix.Catalog.GetString("Question");
			this.hbox1.Add(this.labelQuestion);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelQuestion]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelAnswer = new global::Gtk.Label();
			this.labelAnswer.Name = "labelAnswer";
			this.labelAnswer.LabelProp = global::Mono.Unix.Catalog.GetString("Answer");
			this.hbox1.Add(this.labelAnswer);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.labelAnswer]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox1.Add(this.hbox1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.hbox1]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.VBoxFlashcards = new global::Gtk.VBox();
			this.VBoxFlashcards.Name = "VBoxFlashcards";
			this.VBoxFlashcards.Spacing = 6;
			this.vbox1.Add(this.VBoxFlashcards);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.VBoxFlashcards]));
			w7.Position = 2;
			// Container child vbox1.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator();
			this.vseparator1.Name = "vseparator1";
			this.vbox1.Add(this.vseparator1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.vseparator1]));
			w8.Position = 3;
			// Container child vbox1.Gtk.Box+BoxChild
			this.okButton = new global::Gtk.Button();
			this.okButton.CanFocus = true;
			this.okButton.Name = "okButton";
			this.okButton.UseUnderline = true;
			this.okButton.Label = global::Mono.Unix.Catalog.GetString("Ok");
			this.vbox1.Add(this.okButton);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.okButton]));
			w9.Position = 4;
			w9.Expand = false;
			w9.Fill = false;
			this.Add(this.vbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show();
		}
	}
}
