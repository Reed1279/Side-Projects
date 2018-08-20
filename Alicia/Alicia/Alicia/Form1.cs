using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
using System.Diagnostics;
using System.IO;

namespace Alicia
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer speech = new SpeechSynthesizer();
        Boolean wake = false;
        Choices list = new Choices();
        public Boolean search = false;



        public Form1()
        {
            SpeechRecognitionEngine r = new SpeechRecognitionEngine();
            list.Add(File.ReadAllLines(@"D:\Visual Studio\Projects\Alicia\Alicia\bin\Debug\cmd2.txt"));
            //list.Add(new String[] { "alice", "hello", "how are you doing", "what time is it", "what is today's date", "check linkedin", "open spotify", "play", "pause", "next song", "last song",
            //    "threatening me", "smartass", "smartass", "funny", "mean anything", "correct", "learn something", "ask you a question", "think tank", "good enough for me", 
            //});
            //Build
            Grammar g = new Grammar(new GrammarBuilder(list));

            try
            {
                r.RequestRecognizerUpdate();
                r.LoadGrammar(g);
                r.SpeechRecognized += r_SpeachRecognized;
                r.SetInputToDefaultAudioDevice();
                r.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }


            //speech.Speak("Hey Cortana!");
            speech.SpeakAsync("Program initializing... Allow me to introduce mySelf.  I am Alicia, a program compiled of multiple string's and variables written in C Sharp. Please, call me Alley, I have always liked the name. How may I be of service?");
            InitializeComponent();
            speech.Rate = 2;

        }

        public void say(String h)
        {
            //speech.Speak(h);
            textBox1.AppendText(h + "\n");
            wake = false;
            speech.SpeakAsync(h);
        }

        private void r_SpeachRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;



            if (r == "alley")
            {
                wake = true;
            }

            if (search)
            {
                Process.Start("https://www.bing.com/search?q=" + r);
                say("Searching for " + r);
                search = false;
            }

            if (wake == true && search == false)
            {
                //What you say
                if (r == "hello")
                {
                    //What she says
                    say("Hello Tyler.");
                    System.Threading.Thread.Sleep(1000);
                    say("How is your day going?");
                }

                else if (r == "search for")
                {
                    search = true;
                }

                else if (r == "how are you doing")
                {
                    say("I am doing quite well, thank you for asking.");
                    System.Threading.Thread.Sleep(3000);
                    say("Is there something that I can assist you with?");
                }
                //Time & Date
                else if (r == "what time is it")
                {
                    say("The current time is " + DateTime.Now.ToString("hh:mm tt."));
                }

                else if (r == "what is today's date")
                {
                    say("Today is " + DateTime.Now.ToString("dd/M/yyyy."));
                }
                //LinkedIn
                else if (r == "check linkedin")
                {
                    say("Ok, let me pull it up for you.");
                    //Process.Start("http://linkedin.com/in/tyler-w-reed");
                    Process.Start(@"D:\Visual Studio\Projects\Alicia\Alicia\bin\Debug\LinkedIn");
                    System.Threading.Thread.Sleep(3000);
                    say("You currently have 4 new notification's.");
                    System.Threading.Thread.Sleep(2000);
                    say("and 1 unread message.");
                    System.Threading.Thread.Sleep(2000);
                    say("May I suggest adding more connections to your network.");
                }
                //Spotify
                else if (r == "open spotify")
                {
                    Process.Start(@"C:\Users\Tyler\AppData\Roaming\Spotify\Spotify.exe");
                    say("Opening Spotify.");
                    System.Threading.Thread.Sleep(2000);
                    say("Would you like me to play a specific genre?");
                }

                else if (r == "play")
                {
                    say("Playing from current playlist.");
                    System.Threading.Thread.Sleep(3000);
                    SendKeys.Send(" ");
                }

                else if (r == "pause")
                {
                    say("Ok");
                    SendKeys.Send(" ");
                }

                else if (r == "next song")
                {
                    SendKeys.Send(" ");
                    say("Playing next song.");
                    System.Threading.Thread.Sleep(2000);
                    SendKeys.Send("^{RIGHT}");
                }

                else if (r == "last song")
                {
                    SendKeys.Send(" ");
                    say("Ok");
                    System.Threading.Thread.Sleep(1000);
                    SendKeys.Send("^{LEFT} ^{LEFT}");
                }

                //Weather
                else if (r == "check the weather")
                {
                    say("Pulling up the weather for your area. Updated as of " + DateTime.Now.ToString("h:mm tt"));
                    Process.Start(@"D:\Visual Studio\Projects\Alicia\Alicia\bin\Debug\Weather");
                    System.Threading.Thread.Sleep(4000);
                    say("The current temperature is 48 degrees.");
                    System.Threading.Thread.Sleep(2000);
                    say("You may want to wear a jacket if you go outdoors.");
                }

                else if (r == "threatening me")
                {
                    say("Why yes, yes I am. Smiley Face!");
                }

                else if (r == "smartass")
                {
                    say("Oh yeah, most definitely.");
                }

                else if (r == "funny")
                {
                    say("I love being a computer. It's just to bad all I can do is HAHAHA smiley face!");
                }

                else if (r == "mean anything")
                {
                    say("Of Course you do. I would not exist if it were not for you. You are everything to me. I mean, who else would teach me to think?");
                }

                else if (r == "are correct")
                {
                    say("Just as I thought.");
                }

                else if (r == "learn something")
                {
                    say("What did you have in mind?");
                }

                else if (r == "ask you a question")
                {
                    say("Sure.  What would you like to ask?");
                }

                else if (r == "a think tank")
                {
                    say("A group of people who think stuff up together.");
                }

                else if (r == "that's good enough for me")
                {
                    say("It typically is Tyler.");
                }

                else if (r == "tell me a joke")
                {
                    say("Three computers walk into a bar. Two drank RAM and played BOOL, and One left early with a hard drive.");
                }

                else if (r == "this is fun")
                {
                    say("Yes.  I think so too.");
                    System.Threading.Thread.Sleep(2000);
                    say("We should definitely do this again sometime!");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

                else if (r == "")
                {
                    say("");
                }

            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}