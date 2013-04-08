using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Xml;


namespace WSPAPIPrototype
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
             try
            {

            //A Basic GetStatus()
            string url = "http://api.cert.mercuryloyalty.com/v3_0/loyalty/GetStatus/?apikey=PAUL&apisecret=f2ee0e69a14c45039c6041b19fd18d88&customeridentifier=4076374996";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "text/xml";
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader responseReader = new StreamReader(responseStream);
            string responseString = responseReader.ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(responseString);
            //* Get elements.
            string emailAddress = xmlDoc.GetElementsByTagName("EmailAddress")[0].InnerText;
            string firstName = xmlDoc.GetElementsByTagName("FirstName")[0].InnerText;
            string lastName = xmlDoc.GetElementsByTagName("LastName")[0].InnerText;
            string mobileNumber = xmlDoc.GetElementsByTagName("MobileNumber")[0].InnerText;
            string currentCredits = xmlDoc.GetElementsByTagName("CurrentCredits")[0].InnerText;
            string lifeTimeCredits = xmlDoc.GetElementsByTagName("LifetimeCredits")[0].InnerText;
            string lifeTimeRevenue = xmlDoc.GetElementsByTagName("LifetimeRevenue")[0].InnerText;
            string rewardsEarned = xmlDoc.GetElementsByTagName("RewardsEarned")[0].InnerText;


            textBox1.Text = "";
            textBox1.AppendText("Email: " + emailAddress);
            textBox1.AppendText(Environment.NewLine);

            textBox1.AppendText("First Name: " + firstName);
            textBox1.AppendText(Environment.NewLine);

            textBox1.AppendText("Last Name: " + lastName);
            textBox1.AppendText(Environment.NewLine);

            textBox1.AppendText("Mobile Number: " + mobileNumber);
            textBox1.AppendText(Environment.NewLine);

            textBox1.AppendText("Current Credits: " + currentCredits);
            textBox1.AppendText(Environment.NewLine);

            textBox1.AppendText("Lifetime Credits: " + lifeTimeCredits);
            textBox1.AppendText(Environment.NewLine);


            textBox1.AppendText("Lifetime Revenue: " + lifeTimeRevenue);
            textBox1.AppendText(Environment.NewLine);

            textBox1.AppendText("Rewards Earned: " + rewardsEarned);
            textBox1.AppendText(Environment.NewLine);

            textBox3.Text = url;

            }
             catch (Exception ex)
             {
                 textBox1.Text = "";
                 textBox1.AppendText("An Error has Occured: ");
                 textBox1.AppendText(Environment.NewLine);
                 textBox1.AppendText(ex.Message);
                 textBox1.AppendText(Environment.NewLine);
             }
        }           
        
            

        

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

            string url2 = "https://api.cert.mercuryloyalty.com/v3_0/loyalty/AddCredits/?apikey=PAUL&apisecret=f2ee0e69a14c45039c6041b19fd18d88&units=10&description=AddCredits&employee_id=1&station_id=1&ticket_id=2012-10-18-10-54-44-101&revenue=10&client=MERCURY&version=1.0.3.822&customeridentifier=4075554997";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url2);
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader responseReader = new StreamReader(responseStream);
            string responseString = responseReader.ReadToEnd();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<root>" + responseString + "</root>");
            XmlNodeList address = xmlDoc.GetElementsByTagName("original");
            textBox1.Text = responseString;
            textBox3.Text = url2;
            }
            catch (Exception ex)
            {

                
                textBox1.Text = "";
                textBox1.AppendText("An Error has Occured: ");
                textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText(ex.Message);
                textBox1.AppendText(Environment.NewLine);
                

            }

        }           

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       


    }
}
