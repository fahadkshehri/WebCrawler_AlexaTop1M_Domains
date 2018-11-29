using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace TopDomains {

    class MyWebCralwer {

        static void Main(string[] args) {
                try {

                    using (var sr = new StreamReader("AlexaTopDomains.txt")) {

                    int counter = 0;
                        while (!sr.EndOfStream) {

                            string currentLine = sr.ReadLine();

                                if (IsLinkWorking(currentLine) == true) {
                            counter++;
                                        Console.WriteLine(counter + ") " + currentLine);
                                }                               
                        }
                    }
                }
                catch (Exception e)
                {

                }
        }

        static bool IsLinkWorking(string url) {

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            //You can set some parameters in the "request" object...
            request.AllowAutoRedirect = true;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return true;
            }
            catch // this will make you avoid crashing and exiting the program 
            { //TODO: Check for the right exception here
                return false;
            }
        }

    }
}
