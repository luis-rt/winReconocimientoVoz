using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Text;

namespace winReconocimientoVoz
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {


        private SpeechRecognitionEngine reconocedor = new SpeechRecognitionEngine();

        public RadForm1()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {


            reconocedor.SetInputToWaveFile(@"C:\temp\testllamada.wav"); //;.SetInputToDefaultAudioDevice();
            reconocedor.LoadGrammar(new DictationGrammar());//creamos un datagrama
            reconocedor.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(reconocedor_SpeechRecognized);
            reconocedor.RecognizeAsync(RecognizeMode.Multiple);



        }

        private void reconocedor_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)

        {
            foreach (RecognizedWordUnit word in e.Result.Words)
            {
                radRichTextEditor1.Text += word.Text + " ";
            }


        }
        private void SpeechHypothesizing(object sender, SpeechHypothesizedEventArgs e)

        {


        }


    }
}
